using QL_ThiTracNghiem_WebApi.BLL.Dtos.CT_HocPhanDto;
using QL_ThiTracNghiem_WebApi.BLL.Dtos.GiangVienDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.ICT_HocPhanServices
{
    public interface ICT_HocPhanServices
    {
        Task<CT_HocPhanDto> GetByIdAsync(string malophocphan, string masv, string mahp);
        Task<List<CT_HocPhanDto>> GetAllAsync();
        Task AddAsync(CT_HocPhanAddDto cthp);
        Task UpdateAsync(string malophp, CT_HocPhanDto ct_hp);
        Task DeleteAsync(string malophocphan, string masv, string mahp);
        Task<bool> ItemExists(string malophocphan, string masv, string mahp);
    }
}
