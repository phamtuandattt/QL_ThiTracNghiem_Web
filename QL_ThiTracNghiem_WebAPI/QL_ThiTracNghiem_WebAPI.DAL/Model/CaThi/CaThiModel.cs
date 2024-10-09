using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.CaThi
{
    public class CaThiModel
    {
        public int MaCaThi { get; set; }
        public string? MaHocPhan { get; set; }
        public int MaDeThi { get; set; }
        public string? MaDeCon { get; set; }
        public DateTime? NgayThi { get; set; }
        public string? PhongThi { get; set; }
        public string? GioLamBai { get; set; }
        public int TinhTrang { get; set; }
        public int TinhTrangThi { get; set; }
    }
}

//MACATHI INT IDENTITY(1,1) NOT NULL,
//MAHOCPHAN CHAR(10),
//MADETHI INT,
//MADECON NVARCHAR(10),
//NGAYTHI DATE,
//PHONGTHI NVARCHAR(20),
//GIOLAMBAI NVARCHAR(10),
//TINHTRANG BIT,
//TINHTRANGTHI BIT,