using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos.HocPhanDto
{
    public class HocPhanAddDto
    {
        public string Mahocphan { get; set; } = null!;

        public string? Tenhocphan { get; set; }

        public int? Sotc { get; set; }

        public int? SotietLt { get; set; }

        public int? SotietTh { get; set; }

        public string? Makhoa { get; set; }
    }
}
