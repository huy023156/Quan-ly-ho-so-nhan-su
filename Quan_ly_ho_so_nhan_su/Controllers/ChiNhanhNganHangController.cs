using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
    public class ChiNhanhNganHangController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChiNhanhNganHangController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<ChiNhanhNganHang> chiNhanhNganHangTable = _unitOfWork.ChiNhanhNganHangTable.GetAll().ToList();

            return View(chiNhanhNganHangTable);
        }

        public ActionResult Upsert(int? id)
        {
            ChiNhanhNganHangVM chiNhanhNganHangVM = new ChiNhanhNganHangVM() { 
                ChiNhanhNganHang = new ChiNhanhNganHang(),
                NganHangList = _unitOfWork.NganHangTable.GetAll(/*n => n.IsApplied == true*/).Select(n => new SelectListItem
				{
					Value = n.Id.ToString(),
					Text = n.Name
				}),
				QuocGiaList = _unitOfWork.QuocGiaTable.GetAll(/*q => q.IsApplied == true*/).Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name
                })
            };

            if (id == 0 || id == null)
            {
            }
            else
            {
				chiNhanhNganHangVM.ChiNhanhNganHang = _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == id, includeProperties: "XaPhuong");
                QuanHuyen quanHuyen = _unitOfWork.QuanHuyenTable.Get(u => u.Id == chiNhanhNganHangVM.ChiNhanhNganHang.XaPhuong.QuanHuyenId && u.IsApplied == true);
                TinhThanh tinhThanh = _unitOfWork.TinhThanhTable.Get(u => u.Id == quanHuyen.TinhThanhId/* && u.IsApplied == true*/);
                chiNhanhNganHangVM.QuanHuyenId = quanHuyen.Id;
				chiNhanhNganHangVM.TinhThanhId = tinhThanh.Id;
                chiNhanhNganHangVM.QuocGiaId = tinhThanh.QuocGiaId;

				chiNhanhNganHangVM.XaPhuongList = _unitOfWork.XaPhuongTable.GetAll(u => u.QuanHuyenId == chiNhanhNganHangVM.QuanHuyenId/* && u.IsApplied == true*/).Select(
	                u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
	                );
				chiNhanhNganHangVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(u => u.TinhThanhId == tinhThanh.Id/* && u.IsApplied == true*/).Select(
	                u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
	                );
				chiNhanhNganHangVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.QuocGiaId == chiNhanhNganHangVM.QuocGiaId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
            }

            return View(chiNhanhNganHangVM);
        }

        [HttpPost]
        public ActionResult Upsert(ChiNhanhNganHangVM chiNhanhNganHangVM)
        {
            if (ModelState.IsValid)
            {
                if (chiNhanhNganHangVM.ChiNhanhNganHang.Id == 0)
                {
                    _unitOfWork.ChiNhanhNganHangTable.Add(chiNhanhNganHangVM.ChiNhanhNganHang);
                    TempData["success"] = "Tạo chi nhanh ngân hàng thành công";
                }
                else
                {
                    _unitOfWork.ChiNhanhNganHangTable.Update(chiNhanhNganHangVM.ChiNhanhNganHang);
                    TempData["success"] = "Sửa chi nhánh ngân hàng thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            } else
            {
                chiNhanhNganHangVM.NganHangList = _unitOfWork.NganHangTable.GetAll().Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                });
                chiNhanhNganHangVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name
                });
            };

            return View(chiNhanhNganHangVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ChiNhanhNganHang> chiNhanhNganHangTable = _unitOfWork.ChiNhanhNganHangTable.GetAll(includeProperties: "NganHang,XaPhuong").Where(
                cn => UtilClass.AreDependenciesValid(cn, _unitOfWork)
                ).ToList();
            return Json(new { data = chiNhanhNganHangTable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ChiNhanhNganHang chiNhanhNganHangToDelete = _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == id);

            if (chiNhanhNganHangToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.ChiNhanhNganHangTable.Remove(chiNhanhNganHangToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var chiNhanh = _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == id);
            if (chiNhanh == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy tỉnh thành" });
            }

            chiNhanh.IsApplied = !chiNhanh.IsApplied;
            _unitOfWork.ChiNhanhNganHangTable.Update(chiNhanh);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
