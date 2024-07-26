using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class EmployeeReportVM
    {
        public Employee Employee { get; set; }

        [ValidateNever]
        public Dictionary<int, int> YearEmployeeJoinedDictionary { get; set; }
        [ValidateNever]
        public Dictionary<int, int> YearEmployeeLeaveDictionary { get; set; }
    }
}
