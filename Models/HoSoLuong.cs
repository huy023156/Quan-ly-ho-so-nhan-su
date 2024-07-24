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
    public class HoSoLuong
    {
        [Key]
        public int Id { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá trị không được âm")]
        public float BacLuong { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá trị không được âm")]
        public int LuongCoBan {  get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá trị không được âm")]
        public int RanhLuongMin { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá trị không được âm")]
        public int RanhLuongMax { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [ValidateNever]
        public Employee Employee { get; set; }

        public DateTime? NgayTao { get; set; }
        public DateTime? NgayUpdate { get; set; }
        public string? NguoiTao { get; set; }
        public string? NguoiUpdate { get; set; }

        public bool IsApplied { get; set; } = true;
    }
}
