using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
    public class NoiKhamChuaBenhController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NoiKhamChuaBenhController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<NoiKhamChuaBenh> chiNhanhNganHangTable = _unitOfWork.NoiKhamChuaBenhTable.GetAll().ToList();

            return View(chiNhanhNganHangTable);
        }

        public ActionResult Upsert(int? id)
        {
            NoiKhamChuaBenhVM noiKhamChuaBenhVM = new NoiKhamChuaBenhVM()
            {
                NoiKhamChuaBenh = new NoiKhamChuaBenh(),
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
                noiKhamChuaBenhVM.NoiKhamChuaBenh = _unitOfWork.NoiKhamChuaBenhTable.Get(u => u.Id == id);
                DiaChi diaChi = _unitOfWork.DiaChiTable.Get(u => u.Id == noiKhamChuaBenhVM.NoiKhamChuaBenh.DiaChiId, includeProperties: "QuocGia,TinhThanh,QuanHuyen,XaPhuong");

                noiKhamChuaBenhVM.QuocGiaId = diaChi.QuocGiaId;
                noiKhamChuaBenhVM.TinhThanhId = diaChi.TinhThanhId;
                noiKhamChuaBenhVM.QuanHuyenId = diaChi.QuanHuyenId;
                noiKhamChuaBenhVM.XaPhuongId = diaChi.XaPhuongId;

                noiKhamChuaBenhVM.XaPhuongList = _unitOfWork.XaPhuongTable.GetAll(u => u.QuanHuyenId == diaChi.QuanHuyenId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                noiKhamChuaBenhVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(u => u.TinhThanhId == diaChi.TinhThanhId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                noiKhamChuaBenhVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.QuocGiaId == diaChi.QuocGiaId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
            }

            return View(noiKhamChuaBenhVM);
        }

        [HttpPost]
        public ActionResult Upsert(NoiKhamChuaBenhVM noiKhamChuaBenhVM)
        {
            if (ModelState.IsValid)
            {
                if (noiKhamChuaBenhVM.NoiKhamChuaBenh.Id == 0)
                {
                    DiaChi diaChi = new DiaChi()
                    {
                        QuocGiaId = noiKhamChuaBenhVM.QuocGiaId,
                        TinhThanhId = noiKhamChuaBenhVM.TinhThanhId,
                        QuanHuyenId = noiKhamChuaBenhVM.QuanHuyenId,
                        XaPhuongId = noiKhamChuaBenhVM.XaPhuongId
                    };

                    _unitOfWork.DiaChiTable.Add(diaChi);
                    _unitOfWork.Save();

                    noiKhamChuaBenhVM.NoiKhamChuaBenh.DiaChiId = diaChi.Id;

                    _unitOfWork.NoiKhamChuaBenhTable.Add(noiKhamChuaBenhVM.NoiKhamChuaBenh);
                    TempData["success"] = "Tạo nơi khám chữa bệnh thành công";
                }
                else
                {
                    DiaChi diachiToUpdate = _unitOfWork.DiaChiTable.Get(d => d.Id == noiKhamChuaBenhVM.NoiKhamChuaBenh.DiaChiId);

                    diachiToUpdate.QuocGiaId = noiKhamChuaBenhVM.QuocGiaId;
                    diachiToUpdate.TinhThanhId = noiKhamChuaBenhVM.TinhThanhId;
                    diachiToUpdate.QuanHuyenId = noiKhamChuaBenhVM.QuanHuyenId;
                    diachiToUpdate.XaPhuongId = noiKhamChuaBenhVM.XaPhuongId;

                    _unitOfWork.DiaChiTable.Update(diachiToUpdate);
                    _unitOfWork.NoiKhamChuaBenhTable.Update(noiKhamChuaBenhVM.NoiKhamChuaBenh);
                    TempData["success"] = "Sửa nơi khám chữa bệnh thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                noiKhamChuaBenhVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name
                });
            };

            return View(noiKhamChuaBenhVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var chinhanhnganhangtable = _unitOfWork.NoiKhamChuaBenhTable.GetAll()
                .Select(n => new
                {
                    Id = n.Id,
                    Name = n.Name,
                    DiaChi = n.DiaChiDetail + ", " + UtilClass.GetDiaChiFull(n.DiaChiId, _unitOfWork),
                    IsApplied = n.IsApplied,
                }).ToList();
            return Json(new { data = chinhanhnganhangtable });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            NoiKhamChuaBenh noiKhamChuaBenhToDelete = _unitOfWork.NoiKhamChuaBenhTable.Get(u => u.Id == id);

            if (noiKhamChuaBenhToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.NoiKhamChuaBenhTable.Remove(noiKhamChuaBenhToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var noiKhamChuaBenh = _unitOfWork.NoiKhamChuaBenhTable.Get(u => u.Id == id);
            if (noiKhamChuaBenh == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy tỉnh thành" });
            }

            noiKhamChuaBenh.IsApplied = !noiKhamChuaBenh.IsApplied;
            _unitOfWork.NoiKhamChuaBenhTable.Update(noiKhamChuaBenh);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
