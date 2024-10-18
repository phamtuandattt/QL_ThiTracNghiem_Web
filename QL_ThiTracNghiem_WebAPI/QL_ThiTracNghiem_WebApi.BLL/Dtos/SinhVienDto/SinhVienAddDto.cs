using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.Dtos.SinhVienDto
{
    public class SinhVienAddDto
    {
        public string Masv { get; set; } = null!;

        public string? Makhau { get; set; }

        public string? Tensv { get; set; }

        public string? Gioitinh { get; set; }

        public DateTime? Ngaysinh { get; set; }

        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public string? Diachi { get; set; }

        public string? Quequan { get; set; }

        public string? Malop { get; set; }

        public string? Hocphi { get; set; }
    }
}
