using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository.IHocPhanRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using QL_ThiTracNghiem_WebAPI.DAL.ResponseDtos.CT_HocPhanResponseDto;
using QL_ThiTracNghiem_WebAPI.Infrastructure.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository.HocPhanRepository
{
    public class CT_HocPhanRepository : ICT_HocPhanRepository
    {
        private readonly QlHethongthitracnghiemContext _context;
        public CT_HocPhanRepository(QlHethongthitracnghiemContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(string malophocphan, string masv, string mahocphan)
        {
            var item = await _context.CtHocphans.AnyAsync(mlhp => mlhp.Malophocphan == malophocphan);
            if (!item)
            {
                Logger.Error($"Entity of type {typeof(CT_HocPhanRepository).Name} with id {malophocphan} not found.");
                throw new KeyNotFoundException($"Entity of type {typeof(CT_HocPhanRepository).Name}  with id  {malophocphan} not found.");
            }
            return item;
        }

        public async Task<List<CT_HocPhanResponseDto>> GetCT_LopHocPhan(string MaLopHocPhan)
        {
            var sqlQuery = string.Format(SqlCommand.GET_CT_LOPHOCPHAN, MaLopHocPhan);
            var result = await _context.GetCT_HocPhan.FromSqlRaw(sqlQuery).ToListAsync();
            return result;
        }

        public async Task<List<DS_SVHocPhanResponseDto>> GetDS_SVHocPhanAsync(string MaLopHocPhan)
        {
            var sqlQuery = string.Format(SqlCommand.GET_DSSV_HOCPHAN, MaLopHocPhan);
            var result = await _context.GetDS_SVHocPhan.FromSqlRaw(sqlQuery).ToListAsync();
            return result;
        }

        public async Task<CtHocphan> GetLopHocPhan(string MaLopHocPhan)
        {
            var item = await _context.CtHocphans.Where(lhp => lhp.Malophocphan == MaLopHocPhan).FirstOrDefaultAsync();
            return item ?? new CtHocphan();
        }

        public async Task<string> GetMaLopHocPhan(string MaHocPhan)
        {
            var sqlQuery = string.Format(SqlCommand.GET_MALOPHOCPHAN, MaHocPhan);
            var result = await _context.GetMaLopHocPhan.FromSqlRaw(sqlQuery).FirstOrDefaultAsync();
            return result?.MaLopHocPhan ?? "";
        }

        
    }
}
