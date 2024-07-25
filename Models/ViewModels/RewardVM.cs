using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class RewardVM
    {
        public Reward Reward { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> EmployeeList { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> RewardTypeList { get; set; }
    }
}
