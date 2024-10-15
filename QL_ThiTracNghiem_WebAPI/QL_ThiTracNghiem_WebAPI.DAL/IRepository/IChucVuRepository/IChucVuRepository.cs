using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository.IChucVuRepository
{
    public interface IChucVuRepository
    {
        Task<Chucvu> GetByIdAsync(int id);
        Task<List<Chucvu>> GetAllAsync();
        Task AddAsync(Chucvu chuvu);
        Task UpdateAsync(Chucvu chucvu);
        Task DeleteAsync(int macv);
        Task<bool> ExistsAsync(int macv);
    }
}
