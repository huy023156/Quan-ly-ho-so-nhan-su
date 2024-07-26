using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Resignation
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [ValidateNever]
        public Employee Employee { get; set; }

        public string IdentityUserId { get; set; }
        [ForeignKey(nameof(IdentityUserId))]
        [ValidateNever]
        public IdentityUser IdentityUser { get; set; }

        public string Reason { get; set; }

        public string Status { get; set; }

        public DateOnly ResignationDate { get; set; }

        public DateOnly CreatedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }

    }
}
