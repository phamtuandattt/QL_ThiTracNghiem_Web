using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.ISinhVienRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.Infrastructure.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.SinhVienRepository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly QlHethongthitracnghiemContext _context;
        public SinhVienRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public async Task<string> GetMaSV(string heDaoTao, string maKhoa, string namNhapHoc)
        {
            var sqlQuery = string.Format(SqlCommand.GET_MASINHVIEN, heDaoTao, maKhoa, namNhapHoc);
            var result = await _context.GetMaSV.FromSqlRaw(sqlQuery).FirstOrDefaultAsync();
            return result?.MaSV ?? "";
        }
    }
}
