using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository.ILopHocRepository
{
    public interface ILopHocRepository
    {
        Task<Lophoc> GetByIdAsync(string malop);
        Task<List<Lophoc>> GetAllAsync();
        Task AddAsync(Lophoc lophoc);
        Task UpdateAsync(Lophoc lophoc);
        Task DeleteAsync(string malop);
        Task<bool> ExistsAsync(string malop);
    }
}
