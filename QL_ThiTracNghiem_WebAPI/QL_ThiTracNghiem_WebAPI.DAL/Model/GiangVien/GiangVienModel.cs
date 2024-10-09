using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.GiangVien
{
    public class GiangVienModel
    {
        public string? MaGV { get; set; }
        public string? MatKhau { get; set; }
        public string? TenGV { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string? QueQuan { get; set; }
        public string? HocVi { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }
        public string? DiaChi { get; set; }
        public byte[]? Avata { get; set; }
        public string? MaKhoa { get; set; }
        public int MaChucVu { get; set; }
    }
}
//MAGV CHAR(10) NOT NULL,
//MATKHAU CHAR(20),
//TENGV NVARCHAR(50),
//NGAYSINH DATE,
//GIOITINH NVARCHAR(5),
//QUEQUAN NVARCHAR(20),
//HOCVI NVARCHAR(50),
//SDT CHAR(10),
//EMAIL NVARCHAR(100),
//DIACHI NVARCHAR(100),
//AVATA IMAGE,
//MAKHOA CHAR(2),
//MACHUCVU INT,