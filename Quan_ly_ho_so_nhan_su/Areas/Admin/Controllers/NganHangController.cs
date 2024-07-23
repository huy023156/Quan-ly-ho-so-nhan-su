using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NganHangController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NganHangController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<NganHang> nganHangTable = _unitOfWork.NganHangTable.GetAll().ToList();

            return View(nganHangTable);
        }

        public ActionResult Upsert(int? id)
        {
            NganHang nganHang = new NganHang();

            if (id == 0 || id == null)
            {
            }
            else
            {
                nganHang = _unitOfWork.NganHangTable.Get(u => u.Id == id);
            }

            return View(nganHang);
        }

        [HttpPost]
        public ActionResult Upsert(NganHang nganHang)
        {
            if (ModelState.IsValid)
            {
                if (nganHang.Id == 0)
                {
                    _unitOfWork.NganHangTable.Add(nganHang);
                    TempData["success"] = "Tạo danh mục ngân hàng thành công";
                }
                else
                {
                    _unitOfWork.NganHangTable.Update(nganHang);
                    TempData["success"] = "Sửa danh mục ngân hàng thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(nganHang);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<NganHang> nganHangTable = _unitOfWork.NganHangTable.GetAll().ToList();
            return Json(new { data = nganHangTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            NganHang nganHangToDelete = _unitOfWork.NganHangTable.Get(u => u.Id == id);

            if (nganHangToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.NganHangTable.Remove(nganHangToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        public IActionResult ToggleApply(int id)
        {
            var nganHang = _unitOfWork.NganHangTable.Get(u => u.Id == id);
            if (nganHang == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy quận huyện" });
            }

            nganHang.IsApplied = !nganHang.IsApplied;
            _unitOfWork.NganHangTable.Update(nganHang);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
