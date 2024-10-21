using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IHocPhanRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.Infrastructure.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.HocPhanRepository
{
    public class HocPhanRepository : IHocPhanRepository
    {
        private readonly QlHethongthitracnghiemContext _context;
        public HocPhanRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public async Task<string> GetMaHocPhan()
        {
            var sqlQuery = SqlCommand.GET_MAHOCPHAN;
            var result = await _context.GetMaHocPhan.FromSqlRaw(sqlQuery).FirstOrDefaultAsync();
            return result?.MaHocPhan ?? "";
        }
    }
}
