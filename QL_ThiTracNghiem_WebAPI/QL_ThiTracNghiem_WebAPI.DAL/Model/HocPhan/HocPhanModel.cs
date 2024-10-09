using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.HocPhan
{
    public class HocPhanModel
    {
        public string? MaHocPhan { get; set; }
        public string? TenHocPhan { get; set; }
        public int SoTC { get; set; }
        public int SoTietLT { get; set; }
        public int SoTietTH { get; set; }
        public string? MaKhoa { get; set; }
    }
}
