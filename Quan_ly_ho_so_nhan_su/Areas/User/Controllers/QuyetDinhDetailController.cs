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
    public class QuyetDinhDetailController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuyetDinhDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Upsert(int? id)
        {
            QuyetDinhDetailVM quyetDinhDetailVM = new QuyetDinhDetailVM()
            {
                QuyetDinhDetail = new QuyetDinhDetail(),
                QuyetDinhList = _unitOfWork.QuyetDinhTable.GetAll(/*n => n.IsApplied == true*/).Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                }),
            };

            if (id == 0 || id == null)
            {
            }
            else
            {
                quyetDinhDetailVM.QuyetDinhDetail = _unitOfWork.QuyetDinhDetailTable.Get(u => u.Id == id);
            }

            return View(quyetDinhDetailVM);
        }

        [HttpPost]
        public ActionResult Upsert(QuyetDinhDetailVM quyetDinhDetailVM)
        {
            if (ModelState.IsValid)
            {
                if (quyetDinhDetailVM.QuyetDinhDetail.Id == 0)
                {
                    _unitOfWork.QuyetDinhDetailTable.Add(quyetDinhDetailVM.QuyetDinhDetail);
                    TempData["success"] = "Tạo quyết định thành công";
                }
                else
                {
                    _unitOfWork.QuyetDinhDetailTable.Update(quyetDinhDetailVM.QuyetDinhDetail);
                    TempData["success"] = "Sửa quyết định thành công";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                quyetDinhDetailVM.QuyetDinhList = _unitOfWork.QuyetDinhTable.GetAll().Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Name
                });
            }

            return View(quyetDinhDetailVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var quyetDinhDetailList = _unitOfWork.QuyetDinhDetailTable.GetAll(includeProperties: "QuyetDinh").ToList();
            return Json(new { data = quyetDinhDetailList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            // Tìm các bản ghi liên quan trong bảng con
            var relatedRecords = _unitOfWork.HopDongDetailTable.GetAll(u => u.QuyetDinhDetailId == id).ToList();

            if (relatedRecords.Any())
            {
                // Xóa các bản ghi liên quan
                foreach (var record in relatedRecords)
                {
                    _unitOfWork.HopDongDetailTable.Remove(record);
                }
                _unitOfWork.Save();
            }

            // Sau khi xóa các bản ghi liên quan, xóa bản ghi từ bảng cha
            QuyetDinhDetail quyetDinhDetailToDelete = _unitOfWork.QuyetDinhDetailTable.Get(u => u.Id == id);

            if (quyetDinhDetailToDelete == null)
            {
                return Json(new { success = false, Message = "Delete failed" });
            }

            _unitOfWork.QuyetDinhDetailTable.Remove(quyetDinhDetailToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Delete successful" });
        }



        [HttpPost]
        public IActionResult ToggleApply(int id)
        {
            var quyetDinhDetail = _unitOfWork.QuyetDinhDetailTable.Get(u => u.Id == id);
            if (quyetDinhDetail == null)
            {
                return Json(new { success = false, Message = "Không tìm thấy tỉnh thành" });
            }

            quyetDinhDetail.IsApplied = !quyetDinhDetail.IsApplied;
            _unitOfWork.QuyetDinhDetailTable.Update(quyetDinhDetail);
            _unitOfWork.Save();
            return Json(new { success = true, Message = "Thay đổi trạng thái thành công" });
        }

        #endregion
    }
}
