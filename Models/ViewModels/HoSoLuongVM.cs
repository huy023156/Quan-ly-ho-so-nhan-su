using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class HoSoLuongVM
    {
        public HoSoLuong HoSoLuong { get; set; }

        [ValidateNever]
        public Dictionary<int, string> PhuCapNameDictionary { get; set; }
        [ValidateNever]
        public Dictionary<int, int?> PhuCapDictionary { get; set; }

        [ValidateNever]
        public Dictionary<int, string> PhucLoiNameDictionary { get; set; }
        [ValidateNever]
        public Dictionary<int, int?> PhucLoiDictionary { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> EmployeeList { get; set; }
    }
}
