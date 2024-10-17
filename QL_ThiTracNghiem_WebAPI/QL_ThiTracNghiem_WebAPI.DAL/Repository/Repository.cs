using Microsoft.EntityFrameworkCore;
using QL_ThiTracNghiem_WebAPI.DAL.IRepository;
using QL_ThiTracNghiem_WebAPI.DAL.Models;

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
            try
            {
                await _dbSet.AddAsync(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                //_logger.LogError(dbEx, "Database update failed while adding entity.");
                throw new RepositoryException($"An error occurred while adding the entity to the database. {typeof(T).Name}", dbEx);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An unexpected error occurred while adding entity.");
                throw new RepositoryException($"An unexpected error occurred while adding the entity.  {typeof(T).Name}", ex);
            }
        }

        public async Task DeleteAsync(object id)
        {
            var item = await _dbSet.FindAsync(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with the specified key not found.");
            }

            try
            {
                // Remove entity
                _dbSet.Remove(item);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbConcurrencyEx)
            {
                // Handle concurrency-related exceptions
                throw new RepositoryException($"Concurrency error occurred while deleting the entity. {typeof(T).Name}", dbConcurrencyEx);
            }
            catch (DbUpdateException dbEx)
            {
                // Handle other database update exceptions
                throw new RepositoryException($"An error occurred while trying to delete the entity. {typeof(T).Name}", dbEx);
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

            try
            {
                _context.Entry(existingItem).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException dbConcurrencyEx)
            {
                // Handle concurrency-related exceptions
                throw new RepositoryException($"Concurrency error occurred while updating the entity. {typeof(T).Name}", dbConcurrencyEx);
            }
            catch (DbUpdateException dbEx)
            {
                // Handle other database update exceptions
                throw new RepositoryException($"An error occurred while trying to update the entity. {typeof(T).Name}", dbEx);
            }
        }
    }
}
