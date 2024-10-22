using AutoMapper;
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
        private readonly IMapper _mapper;
        public CT_HocPhanRepository(QlHethongthitracnghiemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public  async Task AddRangeAsync(List<CtHocphan> items)
        {
            if (items.Count <= 0)
            {
                Logger.Error($"Entity of type {typeof(CtHocphan).Name} with the specified key not found.");
                throw new KeyNotFoundException($"Entity of type {typeof(CtHocphan).Name} with the specified key not found.");
            }
            try
            {
                _context.CtHocphans?.AddRangeAsync(items);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbConcurrencyEx)
            {
                Logger.Error($"Concurrency error occurred while updating the entity - {typeof(CtHocphan).Name}  - {dbConcurrencyEx?.InnerException?.Message.ToString()}");
                throw new RepositoryException($"Concurrency error occurred while updating the entity - {typeof(CtHocphan).Name}  - {dbConcurrencyEx?.InnerException?.Message.ToString()}");
            }
            catch (DbUpdateException dbEx)
            {
                Logger.Error($"An error occurred while trying to update the entity - {typeof(CtHocphan).Name}", dbEx);
                throw new RepositoryException($"An error occurred while trying to update the entity - {typeof(CtHocphan).Name}", dbEx);
            }
        }

        public async Task UpdateRangeAsync(CtHocphan item)
        {
            if (string.IsNullOrEmpty(item.Malophocphan))
            {
                Logger.Error($"Entity of type {typeof(CtHocphan).Name} with the specified key not found.");
                throw new KeyNotFoundException($"Entity of type {typeof(CtHocphan).Name} with the specified key not found.");
            }
            try
            {
                var sqlQuery = string.Format(SqlCommand.UPDATE_LOPHOCPHAN, item.Magv, item.Thu, item.Tiet, item.Phong, item.Ngaybd, item.Ngaykt, item.Malophocphan);
                var result = await _context.Database.ExecuteSqlRawAsync(sqlQuery);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbConcurrencyEx)
            {
                Logger.Error($"Concurrency error occurred while updating the entity - {typeof(CtHocphan).Name}  - {dbConcurrencyEx?.InnerException?.Message.ToString()}");
                throw new RepositoryException($"Concurrency error occurred while updating the entity - {typeof(CtHocphan).Name}  - {dbConcurrencyEx?.InnerException?.Message.ToString()}");
            }
            catch (DbUpdateException dbEx)
            {
                Logger.Error($"An error occurred while trying to update the entity - {typeof(CtHocphan).Name}", dbEx);
                throw new RepositoryException($"An error occurred while trying to update the entity - {typeof(CtHocphan).Name}", dbEx);
            }
        }

        public async Task DeleteAsync(string malophocphan)
        {
            if (string.IsNullOrEmpty(malophocphan))
            {
                Logger.Error($"Entity of type {typeof(CtHocphan).Name} with the specified key not found.");
                throw new KeyNotFoundException($"Entity of type {typeof(CtHocphan).Name} with the specified key not found.");
            }
            try
            {
                // Remove entity
                var sqlQuery = string.Format(SqlCommand.DELETE_LOPHOCPHAN, malophocphan);
                var result = await _context.Database.ExecuteSqlRawAsync(sqlQuery);
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbConcurrencyEx)
            {
                Logger.Error($"Database update failed while deleting  {typeof(CtHocphan).Name} entity - ID: {malophocphan} - {dbConcurrencyEx?.InnerException?.Message.ToString()}");
                throw new RepositoryException($"Concurrency error occurred while deleting the entity - {typeof(CtHocphan).Name}  - {dbConcurrencyEx?.InnerException?.Message.ToString()}");
            }
            catch (DbUpdateException dbEx)
            {
                Logger.Error("Database update failed while deleting entity.");
                throw new RepositoryException($"An error occurred while trying to delete the entity - {typeof(CtHocphan).Name}", dbEx);
            }
        }
    }
}
