using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
	public class XaPhuongVM
	{
		public XaPhuong XaPhuong { get; set; }

		public int TinhThanhId { get; set; }
		public int QuocGiaId { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> QuanHuyenList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> TinhThanhList { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem> QuocGiaList { get; set; }

	}
}
