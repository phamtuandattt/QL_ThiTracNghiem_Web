using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos.LopHocDto
{
    public class LopHocAddDto
    {
        public string? MaLop { get; set; }
        public string? TenLop { get; set; }
        public int SiSo { get; set; } = 0;
        public string? MaKhoa { get; set; }
    }
}
