using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IChucVuRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.ChucVuRepository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly QlHethongthitracnghiemContext _context;
        public ChucVuRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Chucvu chuvu)
        {
            await _context.Chucvus.AddAsync(chuvu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int macv)
        {
            var item = await _context.Khoas.FindAsync(macv);
            if (item != null)
            {
                _context.Khoas.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int macv)
        {
            return await _context.Chucvus.AnyAsync(m => m.Machucvu == macv);
        }

        public async Task<List<Chucvu>> GetAllAsync()
        {
            return await _context.Chucvus.ToListAsync();
        }

        public async Task<Chucvu> GetByIdAsync(int id)
        {
            return await _context.Chucvus.FindAsync(id) ?? new Chucvu();
        }

        public async Task UpdateAsync(Chucvu chucvu)
        {
            _context.Chucvus.Update(chucvu);
            await _context.SaveChangesAsync();
        }
    }
}
