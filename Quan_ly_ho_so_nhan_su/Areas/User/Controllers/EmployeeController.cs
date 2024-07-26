using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;
using Microsoft.AspNetCore.Authorization;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.ROLE_MANAGER + "," + SD.ROLE_ADMIN)]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Employee> employeeList = _unitOfWork.EmployeeTable.GetAll().ToList();

            return View(employeeList);
        }

        public ActionResult Upsert(int? id)
        {
            EmployeeVM employeeVM = new EmployeeVM()
            {
                Employee = new Employee(),
                NganHangList = _unitOfWork.NganHangTable.GetAll(/*n => n.IsApplied == true*/).Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }),
                QuocGiaList = _unitOfWork.QuocGiaTable.GetAll(/*q => q.IsApplied == true*/).Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name
                }),
                PhongBanList = _unitOfWork.PhongBanTable.GetAll().Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }),
                GenderList = new List<SelectListItem>() {
                    new SelectListItem
                    {
                        Value = "true",
                        Text = "Nam"
                    },
                    new SelectListItem
                    {
                        Value= "false",
                        Text = "Nữ"
                    }
                }
            };

            if (id == 0 || id == null)
            {
                employeeVM.Employee.IsWorking = true;
            }
            else
            {
                employeeVM.Employee = _unitOfWork.EmployeeTable.Get(u => u.Id == id);
                DiaChi diaChi = _unitOfWork.DiaChiTable.Get(u => u.Id == employeeVM.Employee.DiaChiId, includeProperties: "QuocGia,TinhThanh,QuanHuyen,XaPhuong");

                employeeVM.QuocGiaId = diaChi.QuocGiaId;
                employeeVM.TinhThanhId = diaChi.TinhThanhId;
                employeeVM.QuanHuyenId = diaChi.QuanHuyenId;
                employeeVM.XaPhuongId = diaChi.XaPhuongId;
                employeeVM.NganHangId = _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == employeeVM.Employee.ChiNhanhNganHangId, includeProperties: "NganHang").NganHang.Id;

                employeeVM.XaPhuongList = _unitOfWork.XaPhuongTable.GetAll(u => u.QuanHuyenId == diaChi.QuanHuyenId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                employeeVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(u => u.TinhThanhId == diaChi.TinhThanhId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                employeeVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.QuocGiaId == diaChi.QuocGiaId/* && u.IsApplied == true*/).Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                employeeVM.ChucDanhList = _unitOfWork.PhongBanChucDanhTable.GetAll(u => u.PhongBanId == employeeVM.Employee.PhongBanId, includeProperties: "ChucDanh")
                    .Select(cd => cd.ChucDanh)
                    .Select(
                    u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name }
                    );
                employeeVM.ChiNhanhNganHangList = _unitOfWork.ChiNhanhNganHangTable.GetAll(u => u.NganHangId == employeeVM.NganHangId).Select(
                    c => new SelectListItem { Value = c.Id.ToString(), Text = UtilClass.GetNameByTypeAndId(typeof(XaPhuong), _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == c.Id, includeProperties: "DiaChi").DiaChi.XaPhuongId, _unitOfWork) }
                    );
                employeeVM.ChiNhanhNganHangList = _unitOfWork.ChiNhanhNganHangTable.GetAll(u => u.NganHangId == employeeVM.NganHangId).Select(
                    c => new SelectListItem { Value = c.Id.ToString(), Text = UtilClass.GetNameByTypeAndId(typeof(XaPhuong), _unitOfWork.ChiNhanhNganHangTable.Get(u => u.Id == c.Id, includeProperties: "DiaChi").DiaChi.XaPhuongId, _unitOfWork) }
                    );

            }

            return View(employeeVM);
        }

        [HttpPost]
        public ActionResult Upsert(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                if (employeeVM.Employee.Id == 0)
                {
                    DiaChi diaChi = new DiaChi()
                    {
                        QuocGiaId = employeeVM.QuocGiaId,
                        TinhThanhId = employeeVM.TinhThanhId,
                        QuanHuyenId = employeeVM.QuanHuyenId,
                        XaPhuongId = employeeVM.XaPhuongId
                    };

                    employeeVM.Employee.NgayTao = DateTime.Now;

                    _unitOfWork.DiaChiTable.Add(diaChi);
                    _unitOfWork.Save();

                    employeeVM.Employee.DiaChiId = diaChi.Id;

                    _unitOfWork.EmployeeTable.Add(employeeVM.Employee);
                    TempData["success"] = "Tạo nhân viên thành công";
                }
                else
                {
                    DiaChi diachiToUpdate = _unitOfWork.DiaChiTable.Get(d => d.Id == employeeVM.Employee.DiaChiId);

                    diachiToUpdate.QuocGiaId = employeeVM.QuocGiaId;
                    diachiToUpdate.TinhThanhId = employeeVM.TinhThanhId;
                    diachiToUpdate.QuanHuyenId = employeeVM.QuanHuyenId;
                    diachiToUpdate.XaPhuongId = employeeVM.XaPhuongId;

                    employeeVM.Employee.NgayUpdate = DateTime.Now;

                    _unitOfWork.DiaChiTable.Update(diachiToUpdate);
                    _unitOfWork.EmployeeTable.Update(employeeVM.Employee);
                    TempData["success"] = "Sửa nhân viên thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                employeeVM.NganHangList = _unitOfWork.NganHangTable.GetAll().Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                });
                employeeVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
                {
                    Value = q.Id.ToString(),
                    Text = q.Name
                });
                employeeVM.PhongBanList = _unitOfWork.PhongBanTable.GetAll().Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                });
                employeeVM.GenderList = new List<SelectListItem>() {
                    new SelectListItem
                    {
                        Value = "true",
                        Text = "Nam"
                    },
                    new SelectListItem
                    {
                        Value= "false",
                        Text = "Nữ"
                    }
                };
            };

            return View(employeeVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var employeeViewList = _unitOfWork.EmployeeTable.GetAll(includeProperties: "ChucDanh,PhongBan")
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    e.Email,
                    Gender = e.Gender ? "Nam" : "Nữ",
                    DiaChi = e.DiaChiDetail + ", " + UtilClass.GetDiaChiFull(e.DiaChiId, _unitOfWork),
                    ChucDanh = e.ChucDanh.Name,
                    PhongBan = e.PhongBan.Name,
                    e.PhoneNumber,
                    IsWorking = e.IsWorking ? "Đang làm việc" : "Đã nghỉ việc" ,
                    e.IsApplied,
                }).ToList();
            return Json(new { data = employeeViewList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Employee employeeToDelete = _unitOfWork.EmployeeTable.Get(u => u.Id == id);

            if (employeeToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.EmployeeTable.Remove(employeeToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var employee = _unitOfWork.EmployeeTable.Get(u => u.Id == id);
            if (employee == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy nhân viên" });
            }

            employee.IsApplied = !employee.IsApplied;
            _unitOfWork.EmployeeTable.Update(employee);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
