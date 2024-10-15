using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IKhoaRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.KhoaRepository
{
    public class KhoaRepository : IKhoaRepository
    {
        private readonly QlHethongthitracnghiemContext _context;
        public KhoaRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Khoa khoa)
        {
            await _context.AddAsync(khoa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string makhoa)
        {
            var item = await _context.Khoas.FindAsync(makhoa);
            if (item != null)
            {
                _context.Khoas.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string makhoa)
        {
            return await _context.Khoas.AnyAsync(m => m.Makhoa == makhoa);
        }

        public async Task<List<Khoa>> GetAllAsync()
        {
            return await _context.Khoas.ToListAsync();
        }

        public async Task<Khoa> GetByIdAsync(string makhoa)
        {
            return await _context.Khoas.FindAsync(makhoa) ?? new Khoa();
        }

        public async Task UpdateAsync(Khoa khoa)
        {
            _context.Khoas.Update(khoa);
            await _context.SaveChangesAsync();
        }
    }
}
