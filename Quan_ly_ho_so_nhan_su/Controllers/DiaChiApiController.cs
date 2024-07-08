using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
	public class DiaChiApiController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public DiaChiApiController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
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
