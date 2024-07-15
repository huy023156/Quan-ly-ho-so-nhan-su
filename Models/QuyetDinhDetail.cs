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
    public class QuyetDinhDetail
    {
        [Key]
        public int Id { get; set; }

        public string NoiDung { get; set; }

        [Required]
        public int QuyetDinhId { get; set; }
        [ForeignKey(nameof(QuyetDinhId))]
        [ValidateNever]
        public QuyetDinh QuyetDinh { get; set; }

        public DateTime NgayQuyetDinh {  get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime NgayHetHieuLuc { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayUpdate { get; set; }
        public string? NguoiTao { get; set; }
        public string? NguoiUpdate { get; set; }

    }
}
