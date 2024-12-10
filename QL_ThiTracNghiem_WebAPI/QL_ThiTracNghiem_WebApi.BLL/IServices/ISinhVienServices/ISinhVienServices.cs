using QL_ThiTracNghiem_WebApi.BLL.Dtos.SinhVienDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.ISinhVienServices
{
    public interface ISinhVienServices
    {
        Task<SinhVienDto> GetByIdAsync(string masv);
        Task<List<SinhVienDto>> GetAllAsync();
        Task AddAsync(SinhVienAddDto addDto);
        Task AddRangeAsync(List<SinhVienAddDto> addDtos);
        Task UpdateAsync(string masv, SinhVienDto svDto);
        Task DeleteAsync(string masv);
        Task<bool> ItemExists(string masv);
    }
}
