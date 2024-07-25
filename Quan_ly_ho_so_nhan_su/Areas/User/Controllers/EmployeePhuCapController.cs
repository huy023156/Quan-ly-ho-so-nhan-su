using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class EmployeePhuCapController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

        public EmployeePhuCapController(IUnitOfWork unitOfWork)
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

        #region API CALLS
        [HttpGet]
		public IActionResult GetAll()
		{
			var employeeTaiSanCapPhatViewList = _unitOfWork.EmployeeTable.GetAll()
				.Select(e => new
				{
					e.Id,
					e.Name,
					List = UtilClass.GetPhuCapListByEmployeeId(e.Id, _unitOfWork) 
				});
			return Json(new { data = employeeTaiSanCapPhatViewList });
		}

		public IActionResult GetPhuCapListByEmployeeId(int id)
		{
			var hoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.EmployeeId == id);

			var phuCapIdList = _unitOfWork.PhuCapTable.GetAll().Select(u => u.Id).ToList();

			var phuCapList = _unitOfWork.HoSoLuongPhuCapTable.GetAll(u => u.HoSoLuongId == hoSoLuong.Id, includeProperties: "PhuCap")
				.Select(u => new
				{
					u.PhuCapId,
					u.PhuCap.Name,
					u.Amount
				}).ToList();

			foreach(var phuCap in phuCapList)
			{
				phuCapIdList.Remove(phuCap.PhuCapId);
			}

			if (phuCapIdList.Count > 0) { 
				foreach (var phuCapId in phuCapIdList)
				{
					phuCapList.Add(new { 
						PhuCapId = phuCapId,
						Name = _unitOfWork.PhuCapTable.Get(u => u.Id == phuCapId).Name,
						Amount = 0
					});
				}
			}

			return Json(new { data = phuCapList });
		}

		[HttpPost]
		public IActionResult UpdateAmount(int employeeId, int phuCapId, int newAmount)
		{
			var hoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.EmployeeId == employeeId);


            HoSoLuongPhuCap hoSoLuongPhuCap = _unitOfWork.HoSoLuongPhuCapTable.Get(u => u.HoSoLuongId == hoSoLuong.Id && u.PhuCapId == phuCapId);

			if (hoSoLuongPhuCap == null)
			{
				return Json(new { success = false, message = "Không tìm thấy tài sản cấp phát." });
			}

			// Cập nhật số lượng tài sản
			hoSoLuongPhuCap.Amount = newAmount;

			if (hoSoLuongPhuCap.Amount < 0)
			{
				return Json(new { success = false, message = "Số lượng không được âm" });
			}

			_unitOfWork.HoSoLuongPhuCapTable.Update(hoSoLuongPhuCap);
			_unitOfWork.Save();
			return Json(new { success = true });

		}

        #endregion

    }
}
