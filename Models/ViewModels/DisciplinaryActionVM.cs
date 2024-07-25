using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
	public class DisciplinaryActionVM
	{
		public DisciplinaryAction DisciplinaryAction { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> EmployeeList { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> ViolationTypeList { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> ActionTakenTypeList { get; set; }
	}
}
