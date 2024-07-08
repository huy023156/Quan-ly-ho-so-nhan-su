using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
	public class PhongBanDetailsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public PhongBanDetailsController(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id)
		{
			return View();
		}

		public IActionResult Add()
		{
			return View();
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetChucDanhList(int id)
		{
			List<ChucDanh> chucDanhList = _unitOfWork.PhongBanChucDanhTable.GetAll(u => u.PhongBanId == id).Select(
				u => _unitOfWork.ChucDanhTable.Get(c => c.Id == u.ChucDanhId)).ToList();
			return Json(new { data = chucDanhList });
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			PhongBan phongBanToDelete = _unitOfWork.PhongBanTable.Get(u => u.Id == id);

			if (phongBanToDelete == null)
			{
				return Json(new { success = false, Message = "Delete failed" });
			}

			_unitOfWork.PhongBanTable.Remove(phongBanToDelete);
			_unitOfWork.Save();
			return Json(new { success = true, Message = "Delete successful" });
		}

		#endregion
	}
}
