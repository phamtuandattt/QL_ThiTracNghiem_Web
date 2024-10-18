using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos.LopHocDto
{
    public class LopHocDto
    {
        public string Malop { get; set; } = null!;

        public string? Tenlop { get; set; }

        public int? Siso { get; set; }

        public string? Makhoa { get; set; }
    }
}
