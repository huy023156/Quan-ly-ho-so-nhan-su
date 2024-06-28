using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
    public class QuocGiaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuocGiaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<QuocGia> quocGiaTable = _unitOfWork.QuocGiaTable.GetAll().ToList();

            return View(quocGiaTable);
        }

        public ActionResult Upsert(int? id)
        {
            QuocGia quocGia = new QuocGia();

            if (id == 0 || id == null)
            {
            }
            else
            {
                quocGia = _unitOfWork.QuocGiaTable.Get(u => u.Id == id);
            }

            return View(quocGia);
        }

        [HttpPost]
        public ActionResult Upsert(QuocGia quocGia)
        {
            if (ModelState.IsValid)
            {
                if (quocGia.Id == 0)
                {
                    _unitOfWork.QuocGiaTable.Add(quocGia);
                    TempData["success"] = "Tạo quốc gia thành công";
                }
                else
                {
                    _unitOfWork.QuocGiaTable.Update(quocGia);
                    TempData["success"] = "Sửa quốc gia thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(quocGia);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<QuocGia> quocGiaTable = _unitOfWork.QuocGiaTable.GetAll().ToList();
            return Json(new { data = quocGiaTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            QuocGia quocGiaToDelete = _unitOfWork.QuocGiaTable.Get(u => u.Id == id);

            if (quocGiaToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.QuocGiaTable.Remove(quocGiaToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        #endregion
    }
}
