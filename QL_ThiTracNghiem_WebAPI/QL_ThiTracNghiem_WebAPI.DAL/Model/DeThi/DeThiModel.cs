using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.DeThi
{
    public class DeThiModel
    {
        public int MaDeThi { get; set; }
        public string? MaHocPhan { get; set; }
        public DateTime? NgayTao { get; set; }
        public int TgLamBai { get; set; }
        public int SLCauHoi { get; set; }
        public int TinhTrang { get; set; }
    }
}

//MADETHI INT IDENTITY(1, 1),
//MAHOCPHAN CHAR(10),
//NGAYTAO DATE,
//TGLAMBAI INT,
//SLCAUHOI INT,
//TINHTRANG BIT,