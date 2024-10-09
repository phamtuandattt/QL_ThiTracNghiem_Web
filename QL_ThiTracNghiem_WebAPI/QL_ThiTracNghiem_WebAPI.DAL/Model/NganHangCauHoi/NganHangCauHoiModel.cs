using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.NganHangCauHoi
{
    public class NganHangCauHoiModel
    {
        public int MaNH { get; set; }
        public int SLCauHoi { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
    }
}
