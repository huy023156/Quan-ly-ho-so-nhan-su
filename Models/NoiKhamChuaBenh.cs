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
    public class NoiKhamChuaBenh
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DiaChiDetail { get; set; }
        public int DiaChiId { get; set; }
        [ForeignKey(nameof(DiaChiId))]
        [ValidateNever]
        public DiaChi DiaChi { get; set; }

        public bool IsApplied { get; set; } = true;
    }
}
