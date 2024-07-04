using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
	public class XaPhuongController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public XaPhuongController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<XaPhuong> xaPhuongTable = _unitOfWork.XaPhuongTable.GetAll(includeProperties: "QuanHuyen").ToList();

			return View(xaPhuongTable);
		}

		public ActionResult Upsert(int? id)
		{
			XaPhuongVM xaPhuongVM = new XaPhuongVM
			{
				XaPhuong = new XaPhuong(),
				QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(q => new SelectListItem
				{
					Text = q.Name,
					Value = q.Id.ToString()
				})
			};



			if (id == 0 || id == null)
			{
			}
			else
			{
				xaPhuongVM.XaPhuong = _unitOfWork.XaPhuongTable.Get(u => u.Id == id);

				QuanHuyen quanHuyen = _unitOfWork.QuanHuyenTable.Get(u => u.Id == xaPhuongVM.XaPhuong.QuanHuyenId);

				TinhThanh tinhThanh = _unitOfWork.TinhThanhTable.Get(u => u.Id == quanHuyen.TinhThanhId);
				xaPhuongVM.QuocGiaId = tinhThanh.QuocGiaId;
				xaPhuongVM.TinhThanhId = tinhThanh.Id;

				xaPhuongVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll(u => u.Id == quanHuyen.Id).Select(
								t => new SelectListItem
								{
									Text = t.Name,
									Value = t.Id.ToString()
								});

				xaPhuongVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll(u => u.Id == tinhThanh.Id).Select(
								t => new SelectListItem
								{
									Text = t.Name,
									Value = t.Id.ToString()
								});

				xaPhuongVM.QuocGiaList = _unitOfWork.QuocGiaTable.GetAll().Select(
								q => new SelectListItem
								{
									Text = q.Name,
									Value = q.Id.ToString()
								});
			}

			return View(xaPhuongVM);
		}

		[HttpPost]
		public ActionResult Upsert(XaPhuongVM xaPhuongVM)
		{
			if (ModelState.IsValid)
			{
				if (xaPhuongVM.XaPhuong.Id == 0)
				{
					_unitOfWork.XaPhuongTable.Add(xaPhuongVM.XaPhuong);
					TempData["success"] = "Thêm tỉnh thành thành công";
				}
				else
				{
					_unitOfWork.XaPhuongTable.Update(xaPhuongVM.XaPhuong);
					TempData["success"] = "Sửa tỉnh thành thành công";
				}

				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			else
			{
				xaPhuongVM.QuanHuyenList = _unitOfWork.QuanHuyenTable.GetAll().Select(q => new SelectListItem
				{
					Text = q.Name,
					Value = q.Id.ToString()
				});
			}

			return View(xaPhuongVM);
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			List<XaPhuong> xaPhuongTable = _unitOfWork.XaPhuongTable.GetAll(includeProperties: "QuanHuyen").ToList();

			return Json(new { data = xaPhuongTable });
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			XaPhuong xaPhuongToDelete = _unitOfWork.XaPhuongTable.Get(u => u.Id == id);

			if (xaPhuongToDelete == null)
			{
				return Json(new { success = false, Message = "Delete failed" });
			}

			_unitOfWork.XaPhuongTable.Remove(xaPhuongToDelete);
			_unitOfWork.Save();
			return Json(new { success = true, Message = "Delete successful" });
		}

		#endregion
	}
}
