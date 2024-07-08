using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
    public class TaiSanCapPhatController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaiSanCapPhatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<TaiSanCapPhat> taiSanCapPhatTable = _unitOfWork.TaiSanCapPhatTable.GetAll().ToList();

            return View(taiSanCapPhatTable);
        }

        public ActionResult Upsert(int? id)
        {
            TaiSanCapPhat taiSanCapPhat = new TaiSanCapPhat();

            if (id == 0 || id == null)
            {
            }
            else
            {
                taiSanCapPhat = _unitOfWork.TaiSanCapPhatTable.Get(u => u.Id == id);
            }

            return View(taiSanCapPhat);
        }

        [HttpPost]
        public ActionResult Upsert(TaiSanCapPhat taiSanCapPhat)
        {
            if (ModelState.IsValid)
            {
                if (taiSanCapPhat.Id == 0)
                {
                    _unitOfWork.TaiSanCapPhatTable.Add(taiSanCapPhat);
                    TempData["success"] = "Tạo tài sản cấp phát thành công";
                }
                else
                {
                    _unitOfWork.TaiSanCapPhatTable.Update(taiSanCapPhat);
                    TempData["success"] = "Sửa tài sản cấp phát thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(taiSanCapPhat);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TaiSanCapPhat> taiSanCapPhatTable = _unitOfWork.TaiSanCapPhatTable.GetAll().ToList();
            return Json(new { data = taiSanCapPhatTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TaiSanCapPhat taiSanCapPhatToDelete = _unitOfWork.TaiSanCapPhatTable.Get(u => u.Id == id);

            if (taiSanCapPhatToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.TaiSanCapPhatTable.Remove(taiSanCapPhatToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var taiSanCapPhat = _unitOfWork.TaiSanCapPhatTable.Get(u => u.Id == id);
            if (taiSanCapPhat == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy tài sản cấp phát" });
            }

            taiSanCapPhat.IsApplied = !taiSanCapPhat.IsApplied;
            _unitOfWork.TaiSanCapPhatTable.Update(taiSanCapPhat);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
