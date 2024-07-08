using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
	public class PhongBanController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public PhongBanController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<PhongBan> phongBanTable = _unitOfWork.PhongBanTable.GetAll().ToList();

			return View(phongBanTable);
		}

		public ActionResult Upsert(int? id)
		{
			PhongBan phongBan = new PhongBan();

			if (id == 0 || id == null)
			{
			}
			else
			{
				phongBan = _unitOfWork.PhongBanTable.Get(u => u.Id == id);
			}

			return View(phongBan);
		}

		[HttpPost]
		public ActionResult Upsert(PhongBan phongBan)
		{
			if (ModelState.IsValid)
			{
				if (phongBan.Id == 0)
				{
					_unitOfWork.PhongBanTable.Add(phongBan);
					TempData["success"] = "Tạo danh mục phòng ban thành công";
				}
				else
				{
					_unitOfWork.PhongBanTable.Update(phongBan);
					TempData["success"] = "Sửa danh mục phòng ban thành công";
				}

				_unitOfWork.Save();
				return RedirectToAction("Index");
			}

			return View(phongBan);
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			List<PhongBan> phongBanTable = _unitOfWork.PhongBanTable.GetAll().ToList();
			return Json(new { data = phongBanTable });
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

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var phongBan = _unitOfWork.PhongBanTable.Get(u => u.Id == id);
            if (phongBan == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy hợp đồng" });
            }

            phongBan.IsApplied = !phongBan.IsApplied;
            _unitOfWork.PhongBanTable.Update(phongBan);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
