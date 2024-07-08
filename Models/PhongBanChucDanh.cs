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
	public class PhongBanChucDanh
	{
		[Key]
		public int Id { get; set; }
		
		[Required]		
		public int PhongBanId { get; set; }
		[ForeignKey(nameof(PhongBanId))]
		[ValidateNever]
		public PhongBan PhongBan { get; set; }

		[Required]
		public int ChucDanhId { get; set; }
		[ForeignKey(nameof(ChucDanhId))]
		[ValidateNever]
		public ChucDanh ChucDanh { get; set;}

        public bool IsApplied { get; set; } = true;
    }
}
