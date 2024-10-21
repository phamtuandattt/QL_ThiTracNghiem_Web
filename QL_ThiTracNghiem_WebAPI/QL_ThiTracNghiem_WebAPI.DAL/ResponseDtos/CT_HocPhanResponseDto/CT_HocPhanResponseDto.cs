using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.ResponseDtos.CT_HocPhanResponseDto
{
    public class CT_HocPhanResponseDto
    {
        [Key]
        public string? MaLopHocPhan {  get; set; }
        public string? MaGV {  get; set; }
        public int? Thu {  get; set; }
        public string? Tiet {  get; set; }
        public string? Phong {  get; set; }
        public DateTime? NgayBD {  get; set; }
        public DateTime? NgayKT {  get; set; }
        public string? TenGv {  get; set; }
    }
}
