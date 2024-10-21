using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.DAL.ResponseDtos.CT_HocPhanResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository.IHocPhanRepository
{
    public interface ICT_HocPhanRepository
    {
        Task<string> GetMaLopHocPhan(string MaHocPhan);
        Task<List<CT_HocPhanResponseDto>> GetCT_LopHocPhan(string MaLopHocPhan);
        Task<List<DS_SVHocPhanResponseDto>> GetDS_SVHocPhanAsync(string MaLopHocPhan);
        Task<CtHocphan> GetLopHocPhan(string MaLopHocPhan);
        Task<bool> ExistsAsync(string malophocphan, string masv, string mahocphan);
    }
}
