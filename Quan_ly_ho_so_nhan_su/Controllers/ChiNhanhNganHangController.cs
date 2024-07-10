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
                chiNhanhNganHangVM.ChiNhanhNganHang = _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == id);
                DiaChi diaChi = _unitOfWork.DiaChiTable.Get(u => u.Id == chiNhanhNganHangVM.ChiNhanhNganHang.DiaChiId, includeProperties:"QuocGia,TinhThanh,QuanHuyen,XaPhuong");

                chiNhanhNganHangVM.QuocGiaId = diaChi.QuocGiaId;
                chiNhanhNganHangVM.TinhThanhId = diaChi.TinhThanhId;
                chiNhanhNganHangVM.QuanHuyenId = diaChi.QuanHuyenId;
                chiNhanhNganHangVM.XaPhuongId = diaChi.XaPhuongId;

                chiNhanhNganHangVM.XaPhuongList = _unitOfWork.XaPhuongTable.GetAll(u => u.QuanHuyenId == diaChi.QuanHuyenId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                chiNhanhNganHangVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(u => u.TinhThanhId == diaChi.TinhThanhId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                chiNhanhNganHangVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.QuocGiaId == diaChi.QuocGiaId/* && u.IsApplied == true*/).Select(
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
                    DiaChi diaChi = new DiaChi()
                    {
                        QuocGiaId = chiNhanhNganHangVM.QuocGiaId,
                        TinhThanhId = chiNhanhNganHangVM.TinhThanhId,
                        QuanHuyenId = chiNhanhNganHangVM.QuanHuyenId,
                        XaPhuongId = chiNhanhNganHangVM.XaPhuongId
                    };

                    _unitOfWork.DiaChiTable.Add(diaChi);
                    _unitOfWork.Save();

                    chiNhanhNganHangVM.ChiNhanhNganHang.DiaChiId = diaChi.Id;

                    _unitOfWork.ChiNhanhNganHangTable.Add(chiNhanhNganHangVM.ChiNhanhNganHang);
                    TempData["success"] = "Tạo chi nhanh ngân hàng thành công";
                }
                else
                {
                    DiaChi diachiToUpdate = _unitOfWork.DiaChiTable.Get(d => d.Id == chiNhanhNganHangVM.ChiNhanhNganHang.DiaChiId);

                    diachiToUpdate.QuocGiaId = chiNhanhNganHangVM.QuocGiaId;
                    diachiToUpdate.TinhThanhId = chiNhanhNganHangVM.TinhThanhId;
                    diachiToUpdate.QuanHuyenId = chiNhanhNganHangVM.QuanHuyenId;
                    diachiToUpdate.XaPhuongId = chiNhanhNganHangVM.XaPhuongId;

                    _unitOfWork.DiaChiTable.Update(diachiToUpdate);
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
            List<ChiNhanhNganHangView> chinhanhnganhangtable = _unitOfWork.ChiNhanhNganHangTable.GetAll(includeProperties: "NganHang,DiaChi")
                .Select(c => new ChiNhanhNganHangView
                {
                    Id = c.Id,
                    NganHangName = c.NganHang.Name,
                    XaPhuongName = _unitOfWork.XaPhuongTable.Get(u => u.Id == c.DiaChi.XaPhuongId).Name,
                    DiaChi = c.DiaChiDetail,
                    IsApplied = c.IsApplied,
                }).ToList();
            return Json(new { data = chinhanhnganhangtable });
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
