using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.ResponseDtos.CT_HocPhanResponseDto
{
    public class DS_SVHocPhanResponseDto
    {
        [Key]
        public string? MaSV { get; set; }
        public string? TenSV { get; set; }
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }
        public string? QueQuan { get; set; }
        public string? MaLop { get; set; }
        public string? HocPhi { get; set; }
    }
}
