using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using System.Security.Claims;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class ResignationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

		public ResignationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            ResignationVM resignationVM = new ResignationVM
            {
                Resignation = new Resignation(),
                EmployeeList = _unitOfWork.EmployeeTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name + " - " + q.Email,
                    Value = q.Id.ToString()
                }),
            };



            if (id == 0 || id == null)
            {
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				resignationVM.Resignation.Status = SD.Status.Pending.ToString();
                resignationVM.Resignation.IdentityUserId = userId;
            }
            else
            {
                resignationVM.Resignation = _unitOfWork.ResignationTable.Get(u => u.Id == id);
            }

            return View(resignationVM);
        }

        [HttpPost]
        public ActionResult Upsert(ResignationVM resignationVM)
        {
            if (ModelState.IsValid)
            {
				if (resignationVM.Resignation.Id == 0)
                {
					var claimsIdentity = (ClaimsIdentity)User.Identity;
					var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

					Resignation resignation = _unitOfWork.ResignationTable.Get(u => u.IdentityUserId == userId);

					if (resignation != null)
					{
						TempData["error"] = "Bạn chỉ có thể gửi một đơn xin việc, hãy xóa đơn xin việc cũ";
						return RedirectToAction("Index");
					}

					resignationVM.Resignation.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
					_unitOfWork.ResignationTable.Add(resignationVM.Resignation);
                    TempData["success"] = "Thêm đơn thôi việc thành công";
                }
                else
                {
                    resignationVM.Resignation.UpdatedDate = DateOnly.FromDateTime(DateTime.Now);
                    _unitOfWork.ResignationTable.Update(resignationVM.Resignation);
                    TempData["success"] = "Sửa đơn thôi việc thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                resignationVM.EmployeeList = _unitOfWork.EmployeeTable.GetAll().Select(q => new SelectListItem
                {
					Text = q.Name + " - " + q.Email,
					Value = q.Id.ToString()
                });
            }

            return View(resignationVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var resignationList = _unitOfWork.ResignationTable.GetAll(includeProperties: "Employee").Where(r => r.IdentityUserId == userId).Select(u => new
            {
                u.Id,
                Name = u.Employee.Name + " - " + u.Employee.Email,
                u.Reason,
                u.CreatedDate,
                u.ResignationDate,
                u.UpdatedDate,
                u.Status,
            });
            return Json(new { data = resignationList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Resignation resignationToDelete = _unitOfWork.ResignationTable.Get(u => u.Id == id);

            if (resignationToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.ResignationTable.Remove(resignationToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        
        #endregion
    }
}
