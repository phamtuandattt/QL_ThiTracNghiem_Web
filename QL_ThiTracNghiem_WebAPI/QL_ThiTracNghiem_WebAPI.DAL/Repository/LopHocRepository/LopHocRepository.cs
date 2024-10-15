using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.ILopHocRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.LopHocRepository
{
    public class LopHocRepository : ILopHocRepository
    {
        private readonly QlHethongthitracnghiemContext _context;
        public LopHocRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lophoc lophoc)
        {
            await _context.Lophocs.AddAsync(lophoc);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string malop)
        {
            var item = await _context.Lophocs.FindAsync(malop);
            if (item != null)
            {
                _context.Lophocs.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(string malop)
        {
            return await _context.Lophocs.AnyAsync(m => m.Malop == malop);
        }

        public async Task<List<Lophoc>> GetAllAsync()
        {
            return await _context.Lophocs.ToListAsync();
        }

        public async Task<Lophoc> GetByIdAsync(string malop)
        {
            return await _context.Lophocs.FindAsync(malop) ?? new Lophoc();
        }

        public async Task UpdateAsync(Lophoc lophoc)
        {
            _context.Lophocs.Update(lophoc);
            await _context.SaveChangesAsync();
        }
    }
}
