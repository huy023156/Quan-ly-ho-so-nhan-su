using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class QuanHuyen
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TinhThanhId { get; set; }
        [ForeignKey(nameof(TinhThanhId))]
        [ValidateNever]
        public TinhThanh TinhThanh { get; set; }

		public bool IsApplied { get; set; } = true;
    }
}
