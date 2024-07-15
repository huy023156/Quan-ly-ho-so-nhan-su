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
    public class HopDongDetail
    {
        [Key]
        public int Id { get; set; }

        public int HopDongId { get; set; }
        [ForeignKey(nameof(HopDongId))]
        [ValidateNever]
        public HopDong HopDong { get; set; }

        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [ValidateNever]
        public Employee Employee { get; set; }

        public int QuyetDinhDetailId { get; set; }
        [ForeignKey(nameof(QuyetDinhDetailId))]
        [ValidateNever]
        public QuyetDinhDetail QuyetDinhDetail { get; set; }

        public int HoSoLuongId { get; set; }
        [ForeignKey(nameof(HoSoLuongId))]
        [ValidateNever]
        public HoSoLuong HoSoLuong { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayUpdate { get; set; }
        public string? NguoiTao { get; set; }
        public string? NguoiUpdate { get; set; }

        public bool IsApplied { get; set; } = true;
    }
}
