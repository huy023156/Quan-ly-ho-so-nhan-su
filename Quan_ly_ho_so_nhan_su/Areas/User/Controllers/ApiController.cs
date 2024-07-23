using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    public class ApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetChiNhanhListByNganHangId(int id)
        {
            if (_unitOfWork.ChiNhanhNganHangTable.Get(u => u.NganHangId == id, includeProperties: "DiaChi") == null)
            {
                return Json(new { });
            }

            int xpIndex = _unitOfWork.ChiNhanhNganHangTable.Get(u => u.NganHangId == id, includeProperties: "DiaChi").DiaChi.XaPhuongId;

            var chiNhanhList = _unitOfWork.ChiNhanhNganHangTable.GetAll(cn => cn.NganHangId == id)
                .Select(c => new
                {
                    c.Id,
                    Name = UtilClass.GetNameByTypeAndId(typeof(XaPhuong), _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == c.Id, includeProperties: "DiaChi").DiaChi.XaPhuongId, _unitOfWork)
                })
                .ToList();

            return Json(new { data = chiNhanhList });
        }

        [HttpGet]
        public IActionResult GetChucDanhListByPhongBanId(int id)
        {
            var chucDanhIdList = _unitOfWork.PhongBanChucDanhTable.GetAll(u => u.PhongBanId == id).Select(c => c.ChucDanhId);

            var chucDanhList = _unitOfWork.ChucDanhTable.GetAll(t => chucDanhIdList.Contains(t.Id))
                .Select(t => new { t.Id, t.Name })
                .ToList();

            return Json(new { data = chucDanhList });
        }

        [HttpGet]
        public IActionResult GetTinhThanhListByQuocGiaId(int id)
        {
            var tinhThanhList = _unitOfWork.TinhThanhTable.GetAll(t => t.QuocGiaId == id)
                .Select(t => new { t.Id, t.Name })
                .ToList();

            return Json(new { data = tinhThanhList });
        }

        [HttpGet]
        public IActionResult GetQuanHuyenListByTinhThanhId(int id)
        {
            var quanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(q => q.TinhThanhId == id)
                .Select(q => new { q.Id, q.Name })
                .ToList();

            return Json(new { data = quanHuyenList });
        }

        [HttpGet]
        public IActionResult GetXaPhuongListByQuanHuyenId(int id)
        {
            var xaPhuongList = _unitOfWork.XaPhuongTable.GetAll(x => x.QuanHuyenId == id)
                .Select(x => new { x.Id, x.Name })
                .ToList();

            return Json(new { data = xaPhuongList });
        }
    }
}
