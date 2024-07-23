using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class QuanHuyenController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuanHuyenController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<QuanHuyen> quanHuyenTable = _unitOfWork.QuanHuyenTable.GetAll(includeProperties: "TinhThanh").ToList();

            return View(quanHuyenTable);
        }

        public ActionResult Upsert(int? id)
        {
            QuanHuyenVM quanHuyenVM = new QuanHuyenVM
            {
                QuanHuyen = new QuanHuyen(),
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
                quanHuyenVM.QuanHuyen = _unitOfWork.QuanHuyenTable.Get(u => u.Id == id);
                TinhThanh tinhThanh = _unitOfWork.TinhThanhTable.Get(u => u.Id == quanHuyenVM.QuanHuyen.TinhThanhId);
                quanHuyenVM.QuocGiaId = tinhThanh.QuocGiaId;

                quanHuyenVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.Id == tinhThanh.Id).Select(
                    t => new SelectListItem
                    {
                        Text = t.Name,
                        Value = t.Id.ToString()
                    });

                quanHuyenVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(
                    q => new SelectListItem
                    {
                        Text = q.Name,
                        Value = q.Id.ToString()
                    });
            }

            return View(quanHuyenVM);
        }

        [HttpPost]
        public ActionResult Upsert(QuanHuyenVM quanHuyenVM)
        {
            if (ModelState.IsValid)
            {
                if (quanHuyenVM.QuanHuyen.Id == 0)
                {
                    _unitOfWork.QuanHuyenTable.Add(quanHuyenVM.QuanHuyen);
                    TempData["success"] = "Thêm quận huyện thành công";
                }
                else
                {
                    _unitOfWork.QuanHuyenTable.Update(quanHuyenVM.QuanHuyen);
                    TempData["success"] = "Sửa quận huyện thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                quanHuyenVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name
                });
            }

            return View(quanHuyenVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<QuanHuyen> quanHuyenTable = _unitOfWork.QuanHuyenTable.GetAll(includeProperties: "TinhThanh").Where(q =>
                UtilClass.AreDependenciesValid(q, _unitOfWork)
            ).ToList();
            return Json(new { data = quanHuyenTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            QuanHuyen quanHuyenToDelete = _unitOfWork.QuanHuyenTable.Get(u => u.Id == id);

            if (quanHuyenToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.QuanHuyenTable.Remove(quanHuyenToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var quanHuyen = _unitOfWork.QuanHuyenTable.Get(u => u.Id == id);
            if (quanHuyen == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy quận huyện" });
            }

            quanHuyen.IsApplied = !quanHuyen.IsApplied;
            _unitOfWork.QuanHuyenTable.Update(quanHuyen);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
