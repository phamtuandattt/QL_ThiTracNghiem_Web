using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model
{
    public class SinhVienModel
    {
        public string? MaSV {  get; set; }
        public string? MatKhau {  get; set; }
        public string? TenSV {  get; set; }
        public string? GioiTinh {  get; set; }
        public DateTime? NgaySinh {  get; set; }
        public string? Email {  get; set; }
        public string? Sdt{  get; set; }
        public string? DiaChi {  get; set; }
        public string? QueQuan {  get; set; }
        public string? MaLop {  get; set; }
        public string? HocPhi{  get; set; }
    }
}
//MASV CHAR(10) NOT NULL,
//MAKHAU CHAR(20),
//TENSV NVARCHAR(50),
//GIOITINH NVARCHAR(5),
//NGAYSINH DATE,
//EMAIL NVARCHAR(100),
//SDT CHAR(10),
//DIACHI NVARCHAR(100),
//QUEQUAN NVARCHAR(100),
//MALOP CHAR(10),
//HOCPHI NVARCHAR(10),

