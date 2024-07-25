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
    public class Reward
    {
        [Key]
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [ValidateNever]
        public Employee Employee { get; set; }

        public DateOnly RewardDate { get; set; }

        public string Reason { get; set; }

        public string RewardType { get; set; }

        public string? Description { get; set; }

        public string? Remarks { get; set; }
    }
}
