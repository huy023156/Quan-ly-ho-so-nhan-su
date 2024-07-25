using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class DisciplinaryActionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DisciplinaryActionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            DisciplinaryActionVM disciplinaryActionVM = new DisciplinaryActionVM
            {
                DisciplinaryAction = new DisciplinaryAction(),
                EmployeeList = _unitOfWork.EmployeeTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name + " " + q.Email,
                    Value = q.Id.ToString()
                }),
                ViolationTypeList = Enum.GetValues(typeof(SD.ViolationType)).Cast<SD.ViolationType>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString()
                }),
                ActionTakenTypeList = Enum.GetValues(typeof(SD.ActionTakenType)).Cast<SD.ActionTakenType>()
                .Select(a => new SelectListItem
                {
                    Text = a.ToString(),
                    Value = a.ToString(),
                })
            };



            if (id == 0 || id == null)
            {
            }
            else
            {
                disciplinaryActionVM.DisciplinaryAction = _unitOfWork.DisciplinaryActionTable.Get(u => u.Id == id);
            }

            return View(disciplinaryActionVM);
        }

        [HttpPost]
        public ActionResult Upsert(DisciplinaryActionVM disciplinaryActionVM)
        {
            if (ModelState.IsValid)
            {
                if (disciplinaryActionVM.DisciplinaryAction.Id == 0)
                {
                    _unitOfWork.DisciplinaryActionTable.Add(disciplinaryActionVM.DisciplinaryAction);
                    TempData["success"] = "Thêm kỷ luật thành công";
                }
                else
                {
                    _unitOfWork.DisciplinaryActionTable.Update(disciplinaryActionVM.DisciplinaryAction);
                    TempData["success"] = "Sửa kỷ luật thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                disciplinaryActionVM.EmployeeList = _unitOfWork.EmployeeTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                disciplinaryActionVM.ViolationTypeList = Enum.GetValues(typeof(SD.ViolationType)).Cast<SD.ViolationType>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString()
                });
                disciplinaryActionVM.ActionTakenTypeList = Enum.GetValues(typeof(SD.ActionTakenType)).Cast<SD.ActionTakenType>()
                .Select(a => new SelectListItem
                {
                    Text = a.ToString(),
                    Value = a.ToString(),
                });
            }

            return View(disciplinaryActionVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var reward = _unitOfWork.DisciplinaryActionTable.GetAll(includeProperties: "Employee").Select(u => new
            {
                u.Id,
                Name = u.Employee.Name + " " + u.Employee.Email,
                u.ViolationDate,
                u.ViolationType,
                u.Evidence,
                u.Remarks,
                u.Description,
                u.ActionTakenType,
            });
            return Json(new { data = reward });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DisciplinaryAction disciplinaryActionToDelete = _unitOfWork.DisciplinaryActionTable.Get(u => u.Id == id);

            if (disciplinaryActionToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.DisciplinaryActionTable.Remove(disciplinaryActionToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        #endregion

    }
}
