using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto
{
    public class CT_HocPhanDto
    {
        public string Malophocphan { get; set; } = null!;

        public string Masv { get; set; } = null!;

        public string Mahocphan { get; set; } = null!;

        public string? Magv { get; set; }

        public int? Thu { get; set; }

        public string? Tiet { get; set; }

        public string? Phong { get; set; }

        public DateTime? Ngaybd { get; set; }

        public DateTime? Ngaykt { get; set; }
    }
}
