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
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string DiaChiDetail { get; set; }
        public int DiaChiId { get; set; }
        [ForeignKey(nameof(DiaChiId))]
        [ValidateNever] 
        public DiaChi DiaChi { get; set; }

        public int ChiNhanhNganHangId { get; set; }
        [ForeignKey(nameof(ChiNhanhNganHangId))]
        [ValidateNever]
        public ChiNhanhNganHang ChiNhanhNganHang { get; set; }

        public int PhongBanId { get; set; }
        [ForeignKey(nameof(PhongBanId))]
        [ValidateNever]
        public PhongBan PhongBan { get; set; }

        public int ChucDanhId { get; set; }
        [ForeignKey(nameof(ChucDanhId))]
        [ValidateNever]
        public ChucDanh ChucDanh { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayUpdate { get; set; }
        public string? NguoiTao { get; set; }
        public string? NguoiUpdate { get; set; }

        public bool IsApplied { get; set; } = true;
    }
}
