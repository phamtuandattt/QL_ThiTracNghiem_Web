using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Model.DeThi
{
    public class CT_DeThiModel
    {
        public int STT { get; set; }
        public int MaDeThi { get; set; }
        public string? MaDeCon { get; set; }
        public int MaCauHoi { get; set; }

    }
}
