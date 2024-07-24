using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmployeeTaiSanCapPhat
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [ValidateNever]
        public Employee Employee { get; set; }
    
        public int TaiSanCapPhatId { get; set; }
        [ForeignKey(nameof(TaiSanCapPhatId))]
        [ValidateNever]
        public TaiSanCapPhat TaiSanCapPhat { get; set; }

        public int Amount { get; set; }
    }
}
