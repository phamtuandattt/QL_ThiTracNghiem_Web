using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.ModelResults.CT_HocPhanResult
{
    public class CT_HocPhanResult
    {
        [Key]
        public string? MaLopHocPhan { get; set; }
    }
}
