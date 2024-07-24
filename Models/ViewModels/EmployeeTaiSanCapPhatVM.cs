using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class EmployeeTaiSanCapPhatVM
    {
        public int EmployeeId { get; set; }

        public int TaiSanCapPhatId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng thêm phải lớn hơn hoặc bằng 1")]
        public int Amount { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TaiSanCapPhatList { get; set; }
    }
}
