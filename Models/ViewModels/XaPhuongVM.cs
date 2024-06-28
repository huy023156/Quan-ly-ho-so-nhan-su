﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
		[ValidateNever]
		public IEnumerable<SelectListItem> QuanHuyenList { get; set; }
	}
}
