using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;
using System.Security.Claims;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.ROLE_ADMIN)]
	public class AdminResignationController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public AdminResignationController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			return View();
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var resignationList = _unitOfWork.ResignationTable.GetAll(includeProperties: "Employee,IdentityUser").Select(u => new
			{
				u.Id,
				User = u.IdentityUser.Email,
				Name = u.Employee.Name + " - " + u.Employee.Email,
				u.Reason,
				u.CreatedDate,
				u.UpdatedDate,
				u.Status,
			});
			return Json(new { data = resignationList });
		}

        [HttpPost]
        public IActionResult Accept(int id)
        {
            Resignation resignation = _unitOfWork.ResignationTable.Get(u => u.Id == id, includeProperties: "Employee");

            if (resignation == null)
            {
                return Json(new { success = false, Message = "Failed" });
            }

			if (resignation.Status == SD.Status.Accepted.ToString())
			{
                return Json(new { success = false, Message = "Already accepted" });

            }

            resignation.Employee.IsWorking = false;
            resignation.Status = SD.Status.Accepted.ToString();

            EmployeeResignationDate employeeResignationDate = new EmployeeResignationDate() { 
                EmployeeId = resignation.EmployeeId,
                ResignationDate = resignation.ResignationDate
            };
            
            _unitOfWork.EmployeeResignationDateTable.Add(employeeResignationDate);

			_unitOfWork.EmployeeTable.Update(resignation.Employee);
            _unitOfWork.ResignationTable.Update(resignation);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Chấp nhận thành công" });
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            Resignation resignation = _unitOfWork.ResignationTable.Get(u => u.Id == id, includeProperties: "Employee");

            if (resignation == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            if(resignation.Status == SD.Status.Rejected.ToString())
            {
                return Json(new { success = false, Message = "Already rejected" });

            }

            resignation.Employee.IsWorking = true;
            resignation.Status = SD.Status.Rejected.ToString();

            EmployeeResignationDate employeeResignationDate = _unitOfWork.EmployeeResignationDateTable.Get(u => u.EmployeeId == resignation.EmployeeId);

            if (employeeResignationDate != null)
            {
                _unitOfWork.EmployeeResignationDateTable.Remove(employeeResignationDate);
            }


			_unitOfWork.EmployeeTable.Update(resignation.Employee);
            _unitOfWork.ResignationTable.Update(resignation);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Từ chối thành công" });
        }
        #endregion
    }
}
