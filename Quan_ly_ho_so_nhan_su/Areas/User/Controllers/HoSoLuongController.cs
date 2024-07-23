using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;
using Utility;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.ROLE_ADMIN + "," + SD.ROLE_EMPLOYEE)]
    public class HoSoLuongController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HoSoLuongController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Upsert(int? id)
        {
            List<int> employeeIdHasHoSoLuong = _unitOfWork.HoSoLuongTable.GetAll().Select(x => x.EmployeeId).ToList();
            Dictionary<int, string> phuCapNameDictionary = new Dictionary<int, string>();
            Dictionary<int, int?> phuCapDictionary = new Dictionary<int, int?>();

            var phuCapTableArray = _unitOfWork.PhuCapTable.GetAll().ToArray();



            HoSoLuongVM hoSoLuongVM = new HoSoLuongVM()
            {
                HoSoLuong = new HoSoLuong(),
                EmployeeList = _unitOfWork.EmployeeTable.GetAll(u => !employeeIdHasHoSoLuong.Contains(u.Id)).Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name + " " + e.Email,
                })
            };

            if (id == 0 || id == null)
            {
                for (int i = 0; i < phuCapTableArray.Length; i++)
                {
                    phuCapNameDictionary[phuCapTableArray[i].Id] = phuCapTableArray[i].Name;
                    phuCapDictionary[phuCapTableArray[i].Id] = null;
                }

                hoSoLuongVM.PhuCapDictionary = phuCapDictionary;
                hoSoLuongVM.PhuCapNameDictionary = phuCapNameDictionary;
            }
            else
            {
                for (int i = 0; i < phuCapTableArray.Length; i++)
                {
                    phuCapNameDictionary[phuCapTableArray[i].Id] = phuCapTableArray[i].Name;
                    phuCapDictionary[phuCapTableArray[i].Id] = _unitOfWork.HoSoLuongPhuCapTable.Get(u => u.HoSoLuongId == id && u.PhuCapId == phuCapTableArray[i].Id)?.Amount;
                }

                hoSoLuongVM.PhuCapDictionary = phuCapDictionary;
                hoSoLuongVM.PhuCapNameDictionary = phuCapNameDictionary;

                hoSoLuongVM.HoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.Id == id);
                employeeIdHasHoSoLuong.Remove(hoSoLuongVM.HoSoLuong.EmployeeId);
                hoSoLuongVM.EmployeeList = _unitOfWork.EmployeeTable.GetAll(u => !employeeIdHasHoSoLuong.Contains(u.Id)).Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name + " " + e.Email,
                });
            }

            return View(hoSoLuongVM);
        }

        [HttpPost]
        public ActionResult Upsert(HoSoLuongVM hoSoLuongVM)
        {
            if (hoSoLuongVM.HoSoLuong.RanhLuongMin > hoSoLuongVM.HoSoLuong.RanhLuongMax)
            {
                ModelState.AddModelError("HoSoLuong.RanhLuongMin", "Ranh lương min không được cao hơn ranh lương max");
                ModelState.AddModelError("HoSoLuong.RanhLuongMax", "Ranh lương max không được cao hơn ranh lương min");
            }

            if (ModelState.IsValid)
            {
                if (hoSoLuongVM.HoSoLuong.Id == 0)
                {
                    _unitOfWork.HoSoLuongTable.Add(hoSoLuongVM.HoSoLuong);
                    TempData["success"] = "Tạo hồ sơ lương thành công";
                    _unitOfWork.Save();

                    foreach (int key in hoSoLuongVM.PhuCapDictionary.Keys)
                    {
                        if (hoSoLuongVM.PhuCapDictionary[key] != 0 && hoSoLuongVM.PhuCapDictionary[key] != null)
                        {
                            HoSoLuongPhuCap hoSoLuongPhuCap = new HoSoLuongPhuCap()
                            {
                                PhuCapId = key,
                                HoSoLuongId = hoSoLuongVM.HoSoLuong.Id,
                                Amount = (int)hoSoLuongVM.PhuCapDictionary[key],
                            };


                            _unitOfWork.HoSoLuongPhuCapTable.Add(hoSoLuongPhuCap);
                        }
                    }

                    hoSoLuongVM.HoSoLuong.NgayTao = DateTime.Now;
                }
                else
                {
                    foreach (int key in hoSoLuongVM.PhuCapDictionary.Keys)
                    {
                        if (hoSoLuongVM.PhuCapDictionary[key] != 0 && hoSoLuongVM.PhuCapDictionary[key] != null)
                        {
                            HoSoLuongPhuCap hoSoLuongPhuCap = _unitOfWork.HoSoLuongPhuCapTable.Get(u => u.PhuCapId == key && u.HoSoLuongId == hoSoLuongVM.HoSoLuong.Id);

                            if (hoSoLuongPhuCap == null)
                            {
                                hoSoLuongPhuCap = new HoSoLuongPhuCap()
                                {
                                    PhuCapId = key,
                                    HoSoLuongId = hoSoLuongVM.HoSoLuong.Id,
                                    Amount = (int)hoSoLuongVM.PhuCapDictionary[key],
                                };
                                _unitOfWork.HoSoLuongPhuCapTable.Add(hoSoLuongPhuCap);
                            }
                            else
                            {
                                hoSoLuongPhuCap.Amount = (int)hoSoLuongVM.PhuCapDictionary[key];
                                _unitOfWork.HoSoLuongPhuCapTable.Update(hoSoLuongPhuCap);
                            }


                        }
                    }

                    hoSoLuongVM.HoSoLuong.NgayUpdate = DateTime.Now;


                    _unitOfWork.HoSoLuongTable.Update(hoSoLuongVM.HoSoLuong);
                    TempData["success"] = "Sửa hồ sơ lương thành công";

                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                List<int> employeeIdHasHoSoLuong = _unitOfWork.HoSoLuongTable.GetAll().Select(x => x.EmployeeId).ToList();
                var phuCapTableArray = _unitOfWork.PhuCapTable.GetAll().ToArray();
                Dictionary<int, string> phuCapNameDictionary = new Dictionary<int, string>();
                Dictionary<int, int?> phuCapDictionary = new Dictionary<int, int?>();

                if (hoSoLuongVM.HoSoLuong.Id == 0)
                {
                    hoSoLuongVM.EmployeeList = _unitOfWork.EmployeeTable.GetAll(u => !employeeIdHasHoSoLuong.Contains(u.Id)).Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name + " " + e.Email,
                    });
                    for (int i = 0; i < phuCapTableArray.Length; i++)
                    {
                        phuCapNameDictionary[phuCapTableArray[i].Id] = phuCapTableArray[i].Name;
                        phuCapDictionary[phuCapTableArray[i].Id] = null;
                    }

                    hoSoLuongVM.PhuCapDictionary = phuCapDictionary;
                    hoSoLuongVM.PhuCapNameDictionary = phuCapNameDictionary;
                }
                else
                {
                    for (int i = 0; i < phuCapTableArray.Length; i++)
                    {
                        phuCapNameDictionary[phuCapTableArray[i].Id] = phuCapTableArray[i].Name;
                        phuCapDictionary[phuCapTableArray[i].Id] = _unitOfWork.HoSoLuongPhuCapTable.Get(u => u.HoSoLuongId == hoSoLuongVM.HoSoLuong.Id && u.PhuCapId == phuCapTableArray[i].Id)?.Amount;
                    }

                    hoSoLuongVM.PhuCapDictionary = phuCapDictionary;
                    hoSoLuongVM.PhuCapNameDictionary = phuCapNameDictionary;

                    employeeIdHasHoSoLuong.Remove(hoSoLuongVM.HoSoLuong.EmployeeId);
                    hoSoLuongVM.EmployeeList = _unitOfWork.EmployeeTable.GetAll(u => !employeeIdHasHoSoLuong.Contains(u.Id)).Select(e => new SelectListItem
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name + " " + e.Email,
                    });
                }
            }

            return View(hoSoLuongVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var hoSoLuongViewList = _unitOfWork.HoSoLuongTable.GetAll()
                .Select(e => new
                {
                    e.Id,
                    _unitOfWork.EmployeeTable.Get(u => u.Id == e.EmployeeId).Name,
                    e.BacLuong,
                    e.LuongCoBan,
                    RanhLuong = e.RanhLuongMin + " - " + e.RanhLuongMax,
                    e.IsApplied,
                }).ToList();
            return Json(new { data = hoSoLuongViewList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var relatedRecords = _unitOfWork.HopDongDetailTable.GetAll(u => u.HoSoLuongId == id).ToList();

            if (relatedRecords.Any())
            {
                // Xóa các bản ghi liên quan
                foreach (var record in relatedRecords)
                {
                    _unitOfWork.HopDongDetailTable.Remove(record);
                }
                _unitOfWork.Save();
            }

            HoSoLuong hoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.Id == id);

            if (hoSoLuong == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.HoSoLuongTable.Remove(hoSoLuong);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }

        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var hoSoLuong = _unitOfWork.HoSoLuongTable.Get(u => u.Id == id);
            if (hoSoLuong == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy hồ sơ lương" });
            }

            hoSoLuong.IsApplied = !hoSoLuong.IsApplied;
            _unitOfWork.HoSoLuongTable.Update(hoSoLuong);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }
        #endregion
    }
}
