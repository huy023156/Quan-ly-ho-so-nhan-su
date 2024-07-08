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
    public class TinhThanh
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuocGiaId { get; set; }
        [ForeignKey(nameof(QuocGiaId))]
        [ValidateNever]
        public QuocGia QuocGia { get; set; }

		public bool IsApplied { get; set; } = true;
    }
}
