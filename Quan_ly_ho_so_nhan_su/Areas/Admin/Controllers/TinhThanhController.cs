using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TinhThanhController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TinhThanhController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<TinhThanh> tinhThanhTable = _unitOfWork.TinhThanhTable.GetAll(includeProperties: "QuocGia").ToList();

            return View(tinhThanhTable);
        }

        public ActionResult Upsert(int? id)
        {
            TinhThanhVM tinhThanhVM = new TinhThanhVM
            {
                TinhThanh = new TinhThanh(),
                QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                })
            };



            if (id == 0 || id == null)
            {
            }
            else
            {
                tinhThanhVM.TinhThanh = _unitOfWork.TinhThanhTable.Get(u => u.Id == id);
            }

            return View(tinhThanhVM);
        }

        [HttpPost]
        public ActionResult Upsert(TinhThanhVM tinhThanhVM)
        {
            if (ModelState.IsValid)
            {
                if (tinhThanhVM.TinhThanh.Id == 0)
                {
                    _unitOfWork.TinhThanhTable.Add(tinhThanhVM.TinhThanh);
                    TempData["success"] = "Thêm tỉnh thành thành công";
                }
                else
                {
                    _unitOfWork.TinhThanhTable.Update(tinhThanhVM.TinhThanh);
                    TempData["success"] = "Sửa tỉnh thành thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                tinhThanhVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
            }

            return View(tinhThanhVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<TinhThanh> tinhThanhTable = _unitOfWork.TinhThanhTable.GetAll(includeProperties: "QuocGia").Where(
                t => UtilClass.AreDependenciesValid(t, _unitOfWork)
            ).ToList();
            return Json(new { data = tinhThanhTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TinhThanh tinhThanhToDelete = _unitOfWork.TinhThanhTable.Get(u => u.Id == id);

            if (tinhThanhToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.TinhThanhTable.Remove(tinhThanhToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var tinhThanh = _unitOfWork.TinhThanhTable.Get(u => u.Id == id);
            if (tinhThanh == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy tỉnh thành" });
            }

            tinhThanh.IsApplied = !tinhThanh.IsApplied;
            _unitOfWork.TinhThanhTable.Update(tinhThanh);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
