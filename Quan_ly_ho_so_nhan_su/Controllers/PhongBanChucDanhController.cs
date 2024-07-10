using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
	public class PhongBanChucDanhController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public PhongBanChucDanhController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index(int id)
		{
			PhongBanChucDanhVM phongBanChucDanhVM = new PhongBanChucDanhVM()
			{
				PhongBan = _unitOfWork.PhongBanTable.Get(u => u.Id == id)
			};

			return View(phongBanChucDanhVM);
		}

		public IActionResult Add(int phongBanId)
		{
			PhongBanChucDanhVM phongBanChucDanhVM = new PhongBanChucDanhVM()
			{
				PhongBan = _unitOfWork.PhongBanTable.Get(u => u.Id == phongBanId),
				ChucDanhList = _unitOfWork.ChucDanhTable.GetAll()
				.Select(cd => new SelectListItem
				{
					Text = cd.Name,
					Value = cd.Id.ToString()
				})
			};

			return View(phongBanChucDanhVM);
		}

		[HttpPost]
		public IActionResult Add(PhongBanChucDanhVM phongBanChucDanhVM)
		{
			if (ModelState.IsValid)
			{
				var chucDanhIds = _unitOfWork.PhongBanChucDanhTable.GetAll()
					.Where(u => u.PhongBanId == phongBanChucDanhVM.PhongBan.Id)
					.Select(pbc => pbc.ChucDanhId).ToList();

				if (!chucDanhIds.Contains(phongBanChucDanhVM.ChucDanhId))
				{
					PhongBanChucDanh phongBanChucDanh = new PhongBanChucDanh()
					{
						PhongBanId = phongBanChucDanhVM.PhongBan.Id,
						ChucDanhId = phongBanChucDanhVM.ChucDanhId
					};

					_unitOfWork.PhongBanChucDanhTable.Add(phongBanChucDanh);
					_unitOfWork.Save();
					TempData["success"] = "Thêm chức danh vào phòng ban thành công";
					return RedirectToAction("Index", new { id = phongBanChucDanhVM.PhongBan.Id });
				}
			}
			else
			{
				phongBanChucDanhVM.ChucDanhList = _unitOfWork.ChucDanhTable.GetAll()
				.Select(cd => new SelectListItem
				{
					Text = cd.Name,
					Value = cd.Id.ToString()
				});
			}

			TempData["error"] = "Thêm chức danh vào phòng ban thất bại. Chức danh trùng hoặc không tồn tại!";
			return RedirectToAction("Index", new { id = phongBanChucDanhVM.PhongBan.Id });
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
		public IActionResult Delete(int phongBanId, int chucDanhId)
		{
			PhongBanChucDanh phongBanChucDanh = _unitOfWork.PhongBanChucDanhTable.Get(u => u.ChucDanhId == chucDanhId && u.PhongBanId == phongBanId);

			if (phongBanChucDanh == null)
			{
				return Json(new { success = false, Message = "Delete failed" });
			}

			_unitOfWork.PhongBanChucDanhTable.Remove(phongBanChucDanh);
			_unitOfWork.Save();
			return Json(new { success = true, Message = "Delete successful" });
		}

		#endregion
	}
}