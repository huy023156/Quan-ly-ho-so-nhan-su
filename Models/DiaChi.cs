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
	public class DiaChi
	{
		[Key]
		public int Id { get; set; }

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

		public int XaPhuongId { get; set; }
		[ForeignKey(nameof(XaPhuongId))]
		[ValidateNever]
		public XaPhuong XaPhuong { get; set; }
	}
}
