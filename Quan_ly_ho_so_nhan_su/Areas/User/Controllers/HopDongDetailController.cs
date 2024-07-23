using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    public class HopDongDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HopDongDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Upsert(int? id)
        {
            List<int> hoSoLuongOwnedIds = _unitOfWork.HopDongDetailTable.GetAll().Select(x => x.HoSoLuongId).ToList();

            HopDongDetailVM hopDongDetailVM = new HopDongDetailVM()
            {
                HopDongDetail = new HopDongDetail(),
                QuyetDinhDetailList = _unitOfWork.QuyetDinhDetailTable.GetAll(includeProperties: "QuyetDinh").Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.QuyetDinh.Name + " " + n.NoiDung
                }),
                HopDongList = _unitOfWork.HopDongTable.GetAll().Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name,
                }),
            };

            if (id == 0 || id == null)
            {
                hopDongDetailVM.HoSoLuongList = _unitOfWork.HoSoLuongTable.GetAll(u => !hoSoLuongOwnedIds.Contains(u.Id), includeProperties: "Employee").Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Employee.Name + " " + n.Employee.Email,
                });
            }
            else
            {
                hopDongDetailVM.HopDongDetail = _unitOfWork.HopDongDetailTable.Get(u => u.Id == id);
                hoSoLuongOwnedIds.Remove(hopDongDetailVM.HopDongDetail.HoSoLuongId);

                hopDongDetailVM.HoSoLuongList = _unitOfWork.HoSoLuongTable.GetAll(u => !hoSoLuongOwnedIds.Contains(u.Id), includeProperties: "Employee").Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Employee.Name + " " + n.Employee.Email,
                });
            }

            return View(hopDongDetailVM);
        }

        [HttpPost]
        public ActionResult Upsert(HopDongDetailVM hopDongDetailVM)
        {
            if (ModelState.IsValid)
            {
                if (hopDongDetailVM.HopDongDetail.Id == 0)
                {
                    hopDongDetailVM.HopDongDetail.EmployeeId = _unitOfWork.HoSoLuongTable.Get(u => u.Id == hopDongDetailVM.HopDongDetail.HoSoLuongId).EmployeeId;

                    _unitOfWork.HopDongDetailTable.Add(hopDongDetailVM.HopDongDetail);
                    TempData["success"] = "Tạo hợp đồng thành công";
                }
                else
                {
                    hopDongDetailVM.HopDongDetail.EmployeeId = _unitOfWork.HoSoLuongTable.Get(u => u.Id == hopDongDetailVM.HopDongDetail.HoSoLuongId).EmployeeId;
                    _unitOfWork.HopDongDetailTable.Update(hopDongDetailVM.HopDongDetail);
                    TempData["success"] = "Sửa hợp đồng thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                hopDongDetailVM.QuyetDinhDetailList = _unitOfWork.QuyetDinhTable.GetAll().Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                });

                List<int> hoSoLuongOwnedIds = _unitOfWork.HopDongDetailTable.GetAll().Select(x => x.HoSoLuongId).ToList();

                hopDongDetailVM.HoSoLuongList = _unitOfWork.HoSoLuongTable.GetAll(u => !hoSoLuongOwnedIds.Contains(u.Id), includeProperties: "Employee").Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Employee.Name + " " + n.Employee.Email,
                });

                hopDongDetailVM.HopDongList = _unitOfWork.HopDongTable.GetAll().Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name,
                });
            }

            return View(hopDongDetailVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var hopDongDetailList = _unitOfWork.HopDongDetailTable.GetAll(includeProperties: "HopDong,Employee").ToList();
            return Json(new { data = hopDongDetailList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            HopDongDetail hopDongToDelete = _unitOfWork.HopDongDetailTable.Get(u => u.Id == id);

            if (hopDongToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.HopDongDetailTable.Remove(hopDongToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var hopDongDetail = _unitOfWork.HopDongDetailTable.Get(u => u.Id == id);
            if (hopDongDetail == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy hợp đồng" });
            }

            hopDongDetail.IsApplied = !hopDongDetail.IsApplied;
            _unitOfWork.HopDongDetailTable.Update(hopDongDetail);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
