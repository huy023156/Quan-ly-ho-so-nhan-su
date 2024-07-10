using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
	public class PhongBanChucDanhVM
	{
		public PhongBan PhongBan { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> ChucDanhList { get; set; }

		public int ChucDanhId { get; set; }
	}
}