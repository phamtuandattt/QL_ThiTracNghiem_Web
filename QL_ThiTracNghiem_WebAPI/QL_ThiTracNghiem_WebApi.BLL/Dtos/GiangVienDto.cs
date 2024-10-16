using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos
{
    public class GiangVienDto
    {
        public string Magv { get; set; } = null!;

        public string? Matkhau { get; set; }

        public string? Tengv { get; set; }

        public DateTime? Ngaysinh { get; set; }

        public string? Gioitinh { get; set; }

        public string? Quequan { get; set; }

        public string? Hocvi { get; set; }

        public string? Sdt { get; set; }

        public string? Email { get; set; }

        public string? Diachi { get; set; }

        public byte[]? Avata { get; set; }

        public string? Makhoa { get; set; }

        public int? Machucvu { get; set; }
    }
}
