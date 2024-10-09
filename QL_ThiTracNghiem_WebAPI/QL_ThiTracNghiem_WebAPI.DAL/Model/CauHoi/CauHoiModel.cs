using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.CauHoi
{
    public class CauHoiModel
    {
        public int MaCauHoi { get; set; }
        public string? NoiDung { get; set; }
        public string? DapAn1 { get; set; }
        public string? DapAn2 { get; set; }
        public string? DapAn3 { get; set; }
        public string? DapAn4 { get; set; }
        public string? DapAnDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public int MaNganHang { get; set; }
        public string? MaHocPhan { get; set; }
    }
}

//MACAUHOI INT NOT NULL IDENTITY(1,1),
//NOIDUNG NVARCHAR(MAX),
//DAPAN1 NVARCHAR(MAX),
//DAPAN2 NVARCHAR(MAX),
//DAPAN3 NVARCHAR(MAX),
//DAPAN4 NVARCHAR(MAX),
//DAPANDUNG CHAR(5),
//NGAYTAO DATE,
//NGAYCAPNHAT DATE,
//MANGANHANG INT,
//MAHOCPHAN CHAR(10)