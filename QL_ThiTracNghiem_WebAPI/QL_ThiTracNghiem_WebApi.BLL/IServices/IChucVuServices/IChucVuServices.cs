using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IChucVuServices
{
    public interface IChucVuServices
    {
        Task<ChucVuDto> GetByIdAsync(int macv);
        Task<List<ChucVuDto>> GetAllAsync();
        Task AddAsync(ChucVuDto chucVu);
        Task UpdateAsync(int macv, ChucVuDto chucVu);
        Task DeleteAsync(int macv);
        Task<bool> ItemExists(int macv);
    }
}
