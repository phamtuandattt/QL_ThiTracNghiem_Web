using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos
{
    public class KhoaDto
    {
        public string Makhoa { get; set; } = null!;

        public string Tenkhoa { get; set; } = null!;

        public int? Soluonggiangvien { get; set; } = 0;

        public int? Soluongmonhoc { get; set; } = 0;

        public int? Songanhdaotao { get; set; } = 0;
    }
}
