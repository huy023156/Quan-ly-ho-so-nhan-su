using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Authorization;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class ChucDanhController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChucDanhController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ChucDanh> chucDanhTable = _unitOfWork.ChucDanhTable.GetAll().ToList();

            return View(chucDanhTable);
        }

        public ActionResult Upsert(int? id)
        {
            ChucDanh company = new ChucDanh();

            if (id == 0 || id == null)
            {
            }
            else
            {
                company = _unitOfWork.ChucDanhTable.Get(u => u.Id == id);
            }

            return View(company);
        }

        [HttpPost]
        public ActionResult Upsert(ChucDanh chucDanh)
        {
            if (ModelState.IsValid)
            {
                if (chucDanh.Id == 0)
                {
                    _unitOfWork.ChucDanhTable.Add(chucDanh);
                    TempData["success"] = "Tạo chức danh thành công";
                }
                else
                {
                    _unitOfWork.ChucDanhTable.Update(chucDanh);
                    TempData["success"] = "Sửa chức danh thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(chucDanh);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChucDanh> chucDanhTable = _unitOfWork.ChucDanhTable.GetAll().ToList();
            return Json(new { data = chucDanhTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ChucDanh chucDanhToDelete = _unitOfWork.ChucDanhTable.Get(u => u.Id == id);

            if (chucDanhToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.ChucDanhTable.Remove(chucDanhToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var chucDanh = _unitOfWork.ChucDanhTable.Get(u => u.Id == id);
            if (chucDanh == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy chức danh" });
            }

            chucDanh.IsApplied = !chucDanh.IsApplied;
            _unitOfWork.ChucDanhTable.Update(chucDanh);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
