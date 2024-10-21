using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.ModelResults.GiangVienResult
{
    public class GiangVienResult
    {
        [Key]
        public string? MaGv { get; set; }
    }
}
