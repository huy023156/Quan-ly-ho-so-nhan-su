using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;
using Utility;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
	[Area("User")]
	[Authorize]
	public class EmployeeTaiSanCapPhatController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public EmployeeTaiSanCapPhatController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Detail(int id)
		{
			Employee employee = _unitOfWork.EmployeeTable.Get(u => u.Id == id);

			return View(employee);
		}

		public IActionResult Add(int id)
		{
			EmployeeTaiSanCapPhatVM employeeTaiSanCapPhatVM = new EmployeeTaiSanCapPhatVM()
			{
				EmployeeId = id,
				TaiSanCapPhatList = _unitOfWork.TaiSanCapPhatTable.GetAll().Select(u => new SelectListItem
				{
					Value = u.Id.ToString(),
					Text = u.Name,
				})
			};

			return View(employeeTaiSanCapPhatVM);
		}

		[HttpPost]
		public IActionResult Add(EmployeeTaiSanCapPhatVM employeeTaiSanCapPhatVM)
		{
			if (ModelState.IsValid)
			{
				EmployeeTaiSanCapPhat employeeTaiSanCapPhat = _unitOfWork.EmployeeTaiSanCapPhatTable.Get(u => u.EmployeeId == employeeTaiSanCapPhatVM.EmployeeId && u.TaiSanCapPhatId == employeeTaiSanCapPhatVM.TaiSanCapPhatId);

				if (employeeTaiSanCapPhat != null) {
					employeeTaiSanCapPhat.Amount += employeeTaiSanCapPhatVM.Amount;
					_unitOfWork.EmployeeTaiSanCapPhatTable.Update(employeeTaiSanCapPhat);
				} else
				{
					employeeTaiSanCapPhat = new EmployeeTaiSanCapPhat()
					{
						EmployeeId = employeeTaiSanCapPhatVM.EmployeeId,
						TaiSanCapPhatId = employeeTaiSanCapPhatVM.TaiSanCapPhatId,
						Amount = employeeTaiSanCapPhatVM.Amount,
					};

					_unitOfWork.EmployeeTaiSanCapPhatTable.Add(employeeTaiSanCapPhat);
				}

				_unitOfWork.Save();
				return RedirectToAction("Detail", new { id = employeeTaiSanCapPhatVM.EmployeeId });

			} else
			{
				employeeTaiSanCapPhatVM.TaiSanCapPhatList = _unitOfWork.TaiSanCapPhatTable.GetAll().Select(u => new SelectListItem
				{
					Value = u.Id.ToString(),
					Text = u.Name,
				});

				return View();
			}

		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var employeeTaiSanCapPhatViewList = _unitOfWork.EmployeeTable.GetAll()
				.Select(e => new
				{
					e.Id,
					e.Name,
					List = UtilClass.GetTaiSanCapPhatListByEmployeeId(e.Id, _unitOfWork)
				});
			return Json(new { data = employeeTaiSanCapPhatViewList });
		}

		public IActionResult GetTaiSanCapPhatByEmployeeId(int id)
		{
			var taiSanCapPhatList = _unitOfWork.EmployeeTaiSanCapPhatTable.GetAll(u => u.EmployeeId == id, includeProperties: "TaiSanCapPhat")
				.Select(u => new
				{
					u.TaiSanCapPhatId,
					u.TaiSanCapPhat.Name,
					u.Amount
				});

			return Json(new { data = taiSanCapPhatList });
		}

		[HttpPost]
		public IActionResult UpdateAmount(int employeeId, int tscpId, int newAmount)
		{
			EmployeeTaiSanCapPhat employeeTaiSanCapPhat = _unitOfWork.EmployeeTaiSanCapPhatTable.Get(u => u.EmployeeId == employeeId && u.TaiSanCapPhatId == tscpId);

			if (employeeTaiSanCapPhat == null)
			{
				return Json(new { success = false, message = "Không tìm thấy tài sản cấp phát." });
			}

			// Cập nhật số lượng tài sản
			employeeTaiSanCapPhat.Amount = newAmount;

			if (employeeTaiSanCapPhat.Amount < 0)
			{
				return Json(new { success = false, message = "Số lượng không được âm" });
			}

			_unitOfWork.EmployeeTaiSanCapPhatTable.Update(employeeTaiSanCapPhat);
			_unitOfWork.Save();
			return Json(new { success = true });

		}

		[HttpDelete]
		public IActionResult Delete(int employeeId, int tscpId)
		{
			var employeeTaiSanCapPhat = _unitOfWork.EmployeeTaiSanCapPhatTable.Get(u => u.EmployeeId == employeeId && u.TaiSanCapPhatId == tscpId);

			if (employeeTaiSanCapPhat == null)
			{
				return Json(new { success = false, Message = "Delete failed" });
			}

			_unitOfWork.EmployeeTaiSanCapPhatTable.Remove(employeeTaiSanCapPhat);
			_unitOfWork.Save();

			return Json(new { success = true, Message = "Delete successful" });
		}

		#endregion

	}
}
