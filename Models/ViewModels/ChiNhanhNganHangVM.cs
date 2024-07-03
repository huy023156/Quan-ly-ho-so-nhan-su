using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ChiNhanhNganHangVM
    {
        public ChiNhanhNganHang ChiNhanhNganHang { get; set; }

        public int QuocGiaId { get; set; }
        [ForeignKey(nameof(QuocGiaId))]
        [ValidateNever]
        public QuocGia QuocGia { get; set; }
        public int TinhThanhId { get; set; }
        [ForeignKey(nameof(TinhThanhId))]
        [ValidateNever]
        public TinhThanh TinhThanh { get; set; }
        public int QuanHuyenId { get; set; }
        [ForeignKey(nameof(QuanHuyenId))]
        [ValidateNever]
        public QuanHuyen QuanHuyen { get; set; }

        [ValidateNever]
		public IEnumerable<SelectListItem> NganHangList { get; set; }
		[ValidateNever]
        public IEnumerable<SelectListItem> QuocGiaList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> TinhThanhList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> QuanHuyenList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> XaPhuongList { get; set; }
    }
}
