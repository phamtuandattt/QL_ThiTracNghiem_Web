using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task AddAsync(T item);
        Task AddRangeAsync (List<T> list);
        Task UpdateAsync(T item);
        Task DeleteAsync(object id);
        Task<bool> ExistsAsync(object id);
    }
}
