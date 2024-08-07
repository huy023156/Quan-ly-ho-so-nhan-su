﻿using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.AspNetCore.Authorization;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.ROLE_ADMIN)]
    public class CheDoPhucLoiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheDoPhucLoiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<CheDoPhucLoi> cheDoPhucLoiTable = _unitOfWork.CheDoPhucLoiTable.GetAll().ToList();

            return View(cheDoPhucLoiTable);
        }

        public ActionResult Upsert(int? id)
        {
            CheDoPhucLoi cheDoPhucLoi = new CheDoPhucLoi();

            if (id == 0 || id == null)
            {
            }
            else
            {
                cheDoPhucLoi = _unitOfWork.CheDoPhucLoiTable.Get(u => u.Id == id);
            }

            return View(cheDoPhucLoi);
        }

        [HttpPost]
        public ActionResult Upsert(CheDoPhucLoi cheDoPhucLoi)
        {
            if (ModelState.IsValid)
            {
                if (cheDoPhucLoi.Id == 0)
                {
                    _unitOfWork.CheDoPhucLoiTable.Add(cheDoPhucLoi);
                    TempData["success"] = "Tạo danh mục chế độ phúc lợi thành công";
                }
                else
                {
                    _unitOfWork.CheDoPhucLoiTable.Update(cheDoPhucLoi);
                    TempData["success"] = "Sửa danh mục chế độ phúc lợi công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(cheDoPhucLoi);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CheDoPhucLoi> cheDoPhucLoi = _unitOfWork.CheDoPhucLoiTable.GetAll().ToList();
            return Json(new { data = cheDoPhucLoi });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            CheDoPhucLoi cheDoPhucLoiToDelete = _unitOfWork.CheDoPhucLoiTable.Get(u => u.Id == id);

            if (cheDoPhucLoiToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.CheDoPhucLoiTable.Remove(cheDoPhucLoiToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var cheDoPhucLoi = _unitOfWork.CheDoPhucLoiTable.Get(u => u.Id == id);
            if (cheDoPhucLoi == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy chế độ phúc lợi" });
            }

            cheDoPhucLoi.IsApplied = !cheDoPhucLoi.IsApplied;
            _unitOfWork.CheDoPhucLoiTable.Update(cheDoPhucLoi);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
