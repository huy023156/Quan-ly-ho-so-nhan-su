using Microsoft.AspNetCore.Mvc;

namespace Quan_ly_ho_so_nhan_su.Areas.User.Controllers
{
	[Area("User")]
	public class EmployeeReportController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
