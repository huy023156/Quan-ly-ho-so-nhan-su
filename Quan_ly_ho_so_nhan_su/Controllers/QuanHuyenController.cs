﻿using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Quan_ly_ho_so_nhan_su.Controllers
{
	public class QuanHuyenController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public QuanHuyenController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			List<QuanHuyen> quanHuyenTable = _unitOfWork.QuanHuyenTable.GetAll(includeProperties: "TinhThanh").ToList();

			return View(quanHuyenTable);
		}

		public ActionResult Upsert(int? id)
		{
			QuanHuyenVM quanHuyenVM = new QuanHuyenVM
			{
				QuanHuyen = new QuanHuyen(),
				TinhThanhList = _unitOfWork.TinhThanhTable.GetAll().Select(q => new SelectListItem
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
				quanHuyenVM.QuanHuyen = _unitOfWork.QuanHuyenTable.Get(u => u.Id == id);
			}

			return View(quanHuyenVM);
		}

		[HttpPost]
		public ActionResult Upsert(QuanHuyenVM quanHuyenVM)
		{
			if (ModelState.IsValid)
			{
				if (quanHuyenVM.QuanHuyen.Id == 0)
				{
					_unitOfWork.QuanHuyenTable.Add(quanHuyenVM.QuanHuyen);
					TempData["success"] = "Thêm quận huyện thành công";
				}
				else
				{
					_unitOfWork.QuanHuyenTable.Update(quanHuyenVM.QuanHuyen);
					TempData["success"] = "Sửa quận huyện thành công";
				}

				_unitOfWork.Save();
				return RedirectToAction("Index");
			}
			else
			{
				quanHuyenVM.TinhThanhList = _unitOfWork.TinhThanhTable.GetAll().Select(q => new SelectListItem
				{
					Text = q.Name,
					Value = q.Id.ToString()
				});
			}

			return View(quanHuyenVM);
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			List<QuanHuyen> quanHuyenTable = _unitOfWork.QuanHuyenTable.GetAll(includeProperties: "TinhThanh").ToList();
			return Json(new { data = quanHuyenTable });
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			QuanHuyen quanHuyenToDelete = _unitOfWork.QuanHuyenTable.Get(u => u.Id == id);

			if (quanHuyenToDelete == null)
			{
				return Json(new { success = false, Message = "Delete failed" });
			}

			_unitOfWork.QuanHuyenTable.Remove(quanHuyenToDelete);
			_unitOfWork.Save();
			return Json(new { success = true, Message = "Delete successful" });
		}

		#endregion
	}
}