using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.HocPhan
{
    public class CT_HocPhanModel
    {
        public string? MaLopHocPhan { get; set; }
        public string? MaSV { get; set; }
        public string? MaHocPhan { get; set; }
        public string? MaGV { get; set; }
        public string? Thu { get; set; }
        public string? Tiet { get; set; }
        public string? Phong { get; set; }
        public DateTime? NgayBD { get; set; }
        public DateTime? NgayKT { get; set; }
    }
}

//MALOPHOCPHAN CHAR(12) NOT NULL,
//MASV CHAR(10) NOT NULL,
//MAHOCPHAN CHAR(10) NOT NULL,
//MAGV CHAR(10),
//THU INT,
//TIET CHAR(10),
//PHONG CHAR(10),
//NGAYBD DATE,
//NGAYKT DATE,