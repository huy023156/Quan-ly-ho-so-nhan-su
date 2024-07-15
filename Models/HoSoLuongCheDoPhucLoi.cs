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
    public class HoSoLuongCheDoPhucLoi
    {
        [Key]
        public int Id { get; set; }

        public int CheDoPhucLoiId { get; set; }
        [ForeignKey(nameof(CheDoPhucLoiId))]
        [ValidateNever]
        public CheDoPhucLoi CheDoPhucLoi { get; set; }

        public int HoSoLuongId { get; set; }
        [ForeignKey(nameof(HoSoLuongId))]
        [ValidateNever]
        public HoSoLuong HoSoLuong { get; set; }

        public int Amount { get; set; }
    }
}
