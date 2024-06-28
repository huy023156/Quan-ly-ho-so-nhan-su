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
    public class XaPhuong
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuanHuyenId { get; set; }
        [ForeignKey(nameof(QuanHuyenId))]
        [ValidateNever]
        public QuanHuyen QuanHuyen { get; set; }
    }
}
