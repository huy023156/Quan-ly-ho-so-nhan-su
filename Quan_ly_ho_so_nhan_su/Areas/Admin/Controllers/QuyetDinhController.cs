using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Utility;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class QuyetDinhController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuyetDinhController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Upsert(int? id)
        {
            QuyetDinh quyetDinh = new QuyetDinh();

            if (id == 0 || id == null)
            {
            }
            else
            {
                quyetDinh = _unitOfWork.QuyetDinhTable.Get(u => u.Id == id);
            }

            return View(quyetDinh);
        }

        [HttpPost]
        public ActionResult Upsert(QuyetDinh quyetDinh)
        {
            if (ModelState.IsValid)
            {
                if (quyetDinh.Id == 0)
                {
                    _unitOfWork.QuyetDinhTable.Add(quyetDinh);
                    TempData["success"] = "Tạo danh mục hợp đồng thành công";
                }
                else
                {
                    _unitOfWork.QuyetDinhTable.Update(quyetDinh);
                    TempData["success"] = "Sửa danh mục hợp đồng thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(quyetDinh);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<QuyetDinh> quyetDinhList = _unitOfWork.QuyetDinhTable.GetAll().ToList();
            return Json(new { data = quyetDinhList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            QuyetDinh quyetDinhToDelete = _unitOfWork.QuyetDinhTable.Get(u => u.Id == id);

            if (quyetDinhToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.QuyetDinhTable.Remove(quyetDinhToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var quyetDinh = _unitOfWork.QuyetDinhTable.Get(u => u.Id == id);
            if (quyetDinh == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy danh mục quyết định" });
            }

            quyetDinh.IsApplied = !quyetDinh.IsApplied;
            _unitOfWork.QuyetDinhTable.Update(quyetDinh);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }
        #endregion
    }
}
