using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThiTracNghiem_WebAPI.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly QlHethongthitracnghiemContext _context;
        private DbSet<T> _dbSet;

        public Repository(QlHethongthitracnghiemContext context)
        {
            _context = context;
            _dbSet = this._context.Set<T>();
        }

        public async Task AddAsync(T item)
        {
            await _dbSet.AddAsync(item);
            try
            {

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(object id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item != null) 
            {
                _dbSet.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(object id)
        {
            var item = await _dbSet.FindAsync(id);
            return item != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var items = await _dbSet.ToListAsync();
            if (items == null || !items.Any())
            {
                return new List<T>();  // Return an empty list if no items are found
            }
            return items;
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var item = await _dbSet.FindAsync(id);
            if (item == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with id {id} not found.");
            }
            return item;
        }

        private object GetPrimaryKeyValue(T entity)
        {
            var keyName = _context.Model?.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.Select(x => x.Name).Single();
            
            return entity.GetType().GetProperty(keyName)?.GetValue(entity, null);
        }

        public async Task UpdateAsync(T item)
        {
            var existingItem = await _dbSet.FindAsync(GetPrimaryKeyValue(item));

            if (existingItem == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with the specified key not found.");
            }

            // Update the existing item with new values
            _context.Entry(existingItem).CurrentValues.SetValues(item);

            // Save changes to the database
            await _context.SaveChangesAsync();
        }
    }
}
