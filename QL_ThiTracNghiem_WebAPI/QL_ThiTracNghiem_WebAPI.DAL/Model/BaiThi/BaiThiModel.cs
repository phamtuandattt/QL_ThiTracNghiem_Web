using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.BaiThi
{
    public class BaiThiModel
    {
        public int MaBaiThi { get; set; }
        public string? GioNopBai { get; set; }
        public int Diem { get; set; }
        public string? MaSV { get; set; }
        public string? TinhTrang { get; set; }
        public int MaCaThi { get; set; }

    }
}
