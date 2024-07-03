using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;

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
                NganHangList = _unitOfWork.NganHangTable.GetAll().Select(n => new SelectListItem
				{
					Value = n.Id.ToString(),
					Text = n.Name
				}),
				QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
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
                chiNhanhNganHangVM.QuanHuyen = _unitOfWork.QuanHuyenTable.Get(u => u.Id == chiNhanhNganHangVM.ChiNhanhNganHang.XaPhuong.QuanHuyenId, includeProperties: "TinhThanh");
                chiNhanhNganHangVM.QuanHuyenId = chiNhanhNganHangVM.QuanHuyen.Id;
                chiNhanhNganHangVM.XaPhuongList = _unitOfWork.XaPhuongTable.GetAll(u => u.QuanHuyenId == chiNhanhNganHangVM.QuanHuyenId).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );

                chiNhanhNganHangVM.TinhThanh = _unitOfWork.TinhThanhTable.Get(u => u.Id == chiNhanhNganHangVM.QuanHuyen.TinhThanhId, includeProperties: "QuocGia");
                chiNhanhNganHangVM.TinhThanhId = chiNhanhNganHangVM.TinhThanh.Id;
                chiNhanhNganHangVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(u => u.TinhThanhId == chiNhanhNganHangVM.TinhThanhId).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );

                chiNhanhNganHangVM.QuocGia = _unitOfWork.QuocGiaTable.Get(u => u.Id == chiNhanhNganHangVM.TinhThanh.QuocGiaId);
                chiNhanhNganHangVM.QuocGiaId = chiNhanhNganHangVM.QuocGia.Id;
                chiNhanhNganHangVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.QuocGiaId == chiNhanhNganHangVM.QuocGiaId).Select(
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
            List<ChiNhanhNganHang> chiNhanhNganHangTable = _unitOfWork.ChiNhanhNganHangTable.GetAll(includeProperties: "NganHang,XaPhuong").ToList();
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

        #endregion
    }
}
