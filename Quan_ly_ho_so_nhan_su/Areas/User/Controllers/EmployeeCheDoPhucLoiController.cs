using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.ROLE_MANAGER + "," + SD.ROLE_ADMIN)]
    public class EmployeeCheDoPhucLoiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeCheDoPhucLoiController(IUnitOfWork unitOfWork)
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
            var employeeCheDoPhucLoiViewList = _unitOfWork.EmployeeTable.GetAll()
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    List = UtilClass.GetCheDoPhucLoiListByEmployeeId(e.Id, _unitOfWork)
                });
            return Json(new { data = employeeCheDoPhucLoiViewList });
        }

        public IActionResult GetCheDoPhucLoiListByEmployeeId(int id)
        {
            var hoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.EmployeeId == id);

            var cheDoPhucLoiIdList = _unitOfWork.CheDoPhucLoiTable.GetAll().Select(u => u.Id).ToList();

            var cheDoPhucLoiList = _unitOfWork.HoSoLuongCheDoPhucLoiTable.GetAll(u => u.HoSoLuongId == hoSoLuong.Id, includeProperties: "CheDoPhucLoi")
                .Select(u => new
                {
                    u.CheDoPhucLoiId,
                    u.CheDoPhucLoi.Name,
                    u.Amount
                }).ToList();

            foreach (var cheDoPhucLoi in cheDoPhucLoiList)
            {
                cheDoPhucLoiIdList.Remove(cheDoPhucLoi.CheDoPhucLoiId);
            }

            if (cheDoPhucLoiIdList.Count > 0)
            {
                foreach (var cheDoPhucLoiId in cheDoPhucLoiIdList)
                {
                    cheDoPhucLoiList.Add(new
                    {
                        CheDoPhucLoiId = cheDoPhucLoiId,
                        Name = _unitOfWork.CheDoPhucLoiTable.Get(u => u.Id == cheDoPhucLoiId).Name,
                        Amount = 0
                    });
                }
            }

            return Json(new { data = cheDoPhucLoiList });
        }

        [HttpPost]
        public IActionResult UpdateAmount(int employeeId, int cheDoPhucLoiId, int newAmount)
        {
            var hoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.EmployeeId == employeeId);


            HoSoLuongCheDoPhucLoi hoSoLuongCheDoPhucLoi = _unitOfWork.HoSoLuongCheDoPhucLoiTable.Get(u => u.HoSoLuongId == hoSoLuong.Id && u.CheDoPhucLoiId == cheDoPhucLoiId);

            if (hoSoLuongCheDoPhucLoi == null)
            {
                return Json(new { success = false, message = "Không tìm thấy chế độ phúc lợi." });
            }

            // Cập nhật số lượng tài sản
            hoSoLuongCheDoPhucLoi.Amount = newAmount;

            if (hoSoLuongCheDoPhucLoi.Amount < 0)
            {
                return Json(new { success = false, message = "Số lượng không được âm" });
            }

            _unitOfWork.HoSoLuongCheDoPhucLoiTable.Update(hoSoLuongCheDoPhucLoi);
            _unitOfWork.Save();
            return Json(new { success = true });
        }

        #endregion

    }
}
