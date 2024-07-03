using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChiNhanhNganHang
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Địa chỉ")]
        public string DiaChi {  get; set; }

        [Required]
        public int NganHangId { get; set; }
        [ForeignKey(nameof(NganHangId))]
        [ValidateNever]
        public NganHang NganHang { get; set; }


        [Required]
        public int XaPhuongId {  get; set; }
        [ForeignKey(nameof(XaPhuongId))]
        [ValidateNever]
        public XaPhuong XaPhuong { get; set; }
    }
}
