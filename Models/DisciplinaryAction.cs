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
    public class DisciplinaryAction
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [ValidateNever]
        public Employee Employee { get; set; }

        public DateOnly ViolationDate { get; set; }

        public string ViolationType { get; set; }

        public string? Description { get; set; }

        public string? Evidence { get; set; }

        public string ActionTakenType { get; set; }

        public string? Remarks { get; set; }
    }
}
