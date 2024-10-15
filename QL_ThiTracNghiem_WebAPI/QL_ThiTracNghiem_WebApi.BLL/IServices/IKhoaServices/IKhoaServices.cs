using QL_ThiTracNghiem_WebApi.BLL.Dtos;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebApi.BLL.IServices.IKhoaServices
{
    public interface IKhoaServices
    {
        Task<KhoaDto> GetByIdAsync(string makhoa);
        Task<List<KhoaDto>> GetAllAsync();
        Task AddAsync(KhoaDto khoa);
        Task UpdateAsync(string makhoa, KhoaDto khoa);
        Task DeleteAsync(string makhoa);
        Task<bool> ItemExists(string makhoa);
    }
}
