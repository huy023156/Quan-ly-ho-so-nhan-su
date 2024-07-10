using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class ChiNhanhNganHangView
    {
        public int Id { get; set; }
        public string NganHangName { get; set; }
        public string XaPhuongName { get; set; }
        public string DiaChi {  get; set; }
        public bool IsApplied { get; set; }
    }
}
