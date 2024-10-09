using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.Khoa
{
    public class KhoaModel
    {
        public string? MaKhoa { get; set; }
        public string? TenKhoa { get; set; }
        public int SLGiangVien { get; set; }
        public int SLMonHoc { get; set; }
        public int SoNganhDaoTao { get; set; }
    }
}
