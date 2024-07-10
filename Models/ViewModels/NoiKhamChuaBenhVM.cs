using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class NoiKhamChuaBenhVM
    {
        public NoiKhamChuaBenh NoiKhamChuaBenh { get; set; }

        public int QuocGiaId { get; set; }
        public int TinhThanhId { get; set; }
        public int QuanHuyenId { get; set; }
        public int XaPhuongId { get; set; }

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
