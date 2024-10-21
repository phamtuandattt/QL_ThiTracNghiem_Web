using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.ModelResults.HocPhanResult
{
    public class HocPhanResult
    {
        [Key]
        public string? MaHocPhan { get; set; }
    }
}
