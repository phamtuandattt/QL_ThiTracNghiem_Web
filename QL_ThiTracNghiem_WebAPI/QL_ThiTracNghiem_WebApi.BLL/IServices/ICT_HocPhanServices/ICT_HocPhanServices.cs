using QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using QL_ThiTracNghiem_WebAPI.DAL.ResponseDtos.CT_HocPhanResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.ICT_HocPhanServices
{
    public interface ICT_HocPhanServices
    {
        Task<List<CT_HocPhanResponseDto>> GetAllAsync(string MaLopHocPhan);
        Task<List<DS_SVHocPhanResponseDto>> GetDS_SVHocPhanAsync(string MaLopHocPhan);
        Task<bool> ItemExists(string malophocphan, string masv, string mahp);

        Task AddAsync(CT_HocPhanAddDto cthp);
        Task UpdateAsync(string malophp, CT_HocPhanDto ct_hp);
        Task DeleteAsync(string malophocphan);
    }
}
