using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;
using Utility;
using Microsoft.AspNetCore.Authorization;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.ROLE_MANAGER + "," + SD.ROLE_ADMIN)]
    public class RewardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RewardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            RewardVM rewardVM = new RewardVM
            {
                Reward = new Reward(),
                EmployeeList = _unitOfWork.EmployeeTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name + " " + q.Email,
                    Value = q.Id.ToString()
                }),
                RewardTypeList = Enum.GetValues(typeof(SD.RewardType)).Cast<SD.RewardType>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString()
                }),
            };



            if (id == 0 || id == null)
            {
            }
            else
            {
                rewardVM.Reward = _unitOfWork.RewardTable.Get(u => u.Id == id);
            }

            return View(rewardVM);
        }

        [HttpPost]
        public ActionResult Upsert(RewardVM rewardVM)
        {
            if (ModelState.IsValid)
            {
                if (rewardVM.Reward.Id == 0)
                {
                    _unitOfWork.RewardTable.Add(rewardVM.Reward);
                    TempData["success"] = "Thêm khen thưởng thành công";
                }
                else
                {
                    _unitOfWork.RewardTable.Update(rewardVM.Reward);
                    TempData["success"] = "Sửa khen thưởng thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                rewardVM.EmployeeList = _unitOfWork.EmployeeTable.GetAll().Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
                rewardVM.RewardTypeList = Enum.GetValues(typeof(SD.RewardType)).Cast<SD.RewardType>()
                .Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = v.ToString()
                });
            }

            return View(rewardVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var rewardList = _unitOfWork.RewardTable.GetAll(includeProperties: "Employee").Select(u => new
            {
                u.Id,
                Name = u.Employee.Name + " " + u.Employee.Email,
                u.RewardDate,
                u.RewardType,
                u.Reason,
                u.Remarks,
                u.Description,
            });
            return Json(new { data = rewardList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Reward rewardToDelete = _unitOfWork.RewardTable.Get(u => u.Id == id);

            if (rewardToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.RewardTable.Remove(rewardToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }
        #endregion

    }
}
