using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HopDongController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HopDongController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<HopDong> hopDongTable = _unitOfWork.HopDongTable.GetAll().ToList();

            return View(hopDongTable);
        }

        public ActionResult Upsert(int? id)
        {
            HopDong hopDong = new HopDong();

            if (id == 0 || id == null)
            {
            }
            else
            {
                hopDong = _unitOfWork.HopDongTable.Get(u => u.Id == id);
            }

            return View(hopDong);
        }

        [HttpPost]
        public ActionResult Upsert(HopDong hopDong)
        {
            if (ModelState.IsValid)
            {
                if (hopDong.Id == 0)
                {
                    _unitOfWork.HopDongTable.Add(hopDong);
                    TempData["success"] = "Tạo danh mục hợp đồng thành công";
                }
                else
                {
                    _unitOfWork.HopDongTable.Update(hopDong);
                    TempData["success"] = "Sửa danh mục hợp đồng thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(hopDong);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<HopDong> hopDongTable = _unitOfWork.HopDongTable.GetAll().ToList();
            return Json(new { data = hopDongTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            HopDong hopDongToDelete = _unitOfWork.HopDongTable.Get(u => u.Id == id);

            if (hopDongToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.HopDongTable.Remove(hopDongToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var hopDong = _unitOfWork.HopDongTable.Get(u => u.Id == id);
            if (hopDong == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy hợp đồng" });
            }

            hopDong.IsApplied = !hopDong.IsApplied;
            _unitOfWork.HopDongTable.Update(hopDong);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
