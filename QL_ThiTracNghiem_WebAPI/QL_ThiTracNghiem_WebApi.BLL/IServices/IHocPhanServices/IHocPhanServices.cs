
using QL_ThiTracNghiem_WebApi.BLL.Dtos.HocPhanDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IHocPhanServices
{
    public interface IHocPhanServices
    {
        Task<HocPhanDto> GetByIdAsync(string mhp);
        Task<List<HocPhanDto>> GetAllAsync();
        Task AddAsync(HocPhanAddDto hocphanDto);
        Task UpdateAsync(string mhp, HocPhanDto hocphanDto);
        Task DeleteAsync(string mhp);
        Task<bool> ItemExists(string mhp);
    }
}
