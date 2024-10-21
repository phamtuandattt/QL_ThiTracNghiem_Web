using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IGiangVienRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.Infrastructure.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.GiangVienRepository
{
    public class GiangVienRepository : IGiangVienRepository
    {
        private readonly QlHethongthitracnghiemContext _context;

        public GiangVienRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }
        public async Task<string> GetMaGiangVien(string dau, string makhoa)
        {
            var sqlQuery = string.Format(SqlCommand.GET_MAGV, dau, makhoa);
            var result = await _context.GetMaGv.FromSqlRaw(sqlQuery).FirstOrDefaultAsync();
            return result?.MaGv ?? "";
        }
    }
}
