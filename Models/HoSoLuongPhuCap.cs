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
    public class HoSoLuongPhuCap
    {
        [Key]
        public int Id { get; set; }

        public int PhuCapId { get; set; }
        [ForeignKey(nameof(PhuCapId))]
        [ValidateNever]
        public PhuCap PhuCap { get; set; }

        public int HoSoLuongId { get; set; }
        [ForeignKey(nameof(HoSoLuongId))]
        [ValidateNever]
        public HoSoLuong HoSoLuong { get; set; }

        public int Amount { get; set; }
    }
}
