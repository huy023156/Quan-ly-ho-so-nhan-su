using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Authorization;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class PhuCapController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PhuCapController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<PhuCap> phuCapTable = _unitOfWork.PhuCapTable.GetAll().ToList();

            return View(phuCapTable);
        }

        public ActionResult Upsert(int? id)
        {
            PhuCap phuCap = new PhuCap();

            if (id == 0 || id == null)
            {
            }
            else
            {
                phuCap = _unitOfWork.PhuCapTable.Get(u => u.Id == id);
            }

            return View(phuCap);
        }

        [HttpPost]
        public ActionResult Upsert(PhuCap phuCap)
        {
            if (ModelState.IsValid)
            {
                if (phuCap.Id == 0)
                {
                    _unitOfWork.PhuCapTable.Add(phuCap);
                    TempData["success"] = "Tạo danh mục phụ cấp thành công";
                }
                else
                {
                    _unitOfWork.PhuCapTable.Update(phuCap);
                    TempData["success"] = "Sửa danh mục phụ cấp thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(phuCap);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<PhuCap> phuCapTable = _unitOfWork.PhuCapTable.GetAll().ToList();
            return Json(new { data = phuCapTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            PhuCap phuCapToDelete = _unitOfWork.PhuCapTable.Get(u => u.Id == id);

            if (phuCapToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.PhuCapTable.Remove(phuCapToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var phuCap = _unitOfWork.PhuCapTable.Get(u => u.Id == id);
            if (phuCap == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy phụ cấp" });
            }

            phuCap.IsApplied = !phuCap.IsApplied;
            _unitOfWork.PhuCapTable.Update(phuCap);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}

