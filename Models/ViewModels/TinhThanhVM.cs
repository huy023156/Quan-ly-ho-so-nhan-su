﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
    public class TinhThanhVM
    {
        public TinhThanh TinhThanh { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> QuocGiaList { get; set; }
    }
}
