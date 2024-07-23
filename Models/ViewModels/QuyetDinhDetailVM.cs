using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class QuyetDinhDetailVM
    {
        public QuyetDinhDetail QuyetDinhDetail { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> QuyetDinhList { get; set; }
    }
}
