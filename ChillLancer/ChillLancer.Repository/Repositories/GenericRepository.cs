using ChillLancer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ChillLancer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ChillLancerDbContext _context;

        public GenericRepository(ChillLancerDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Entities => _context.Set<T>();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().CountAsync(expression);
        }
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
        public IQueryable<T> GetAll() => Entities.AsQueryable();

        //This function is the update version of the one above, which have Include() in it
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(expression);

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetOneAsync(Expression<Func<T, bool>> expression, bool hasTrackings = true)
        {
            return hasTrackings ? await _context.Set<T>().FirstOrDefaultAsync(expression)
                                : await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<T?> GetByIdAsync<Tkey>(Tkey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task AddAsync(T TEntity)
        {
            _context.Add(TEntity);
            return Task.CompletedTask;
        }

        public async Task AddRangeAsync(IEnumerable<T> Tentities)
        {
            await _context.Set<T>().AddRangeAsync(Tentities);
        }

        public Task UpdateAsync(T TEntity)
        {
            _context.Set<T>().Update(TEntity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T TEntity)
        {
            _context.Remove(TEntity);
            return Task.CompletedTask;
        }

        public Task DeleteRangeAsync(IEnumerable<T> TEntities)
        {
            _context.Set<T>().RemoveRange(TEntities);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RollbackAsync()
        {
            foreach (var entry in _context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        // Remove the entity from DbContext
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        // Reload the entity's data from the database
                        entry.Reload();
                        break;
                }
            }
            return await SaveChangeAsync();
        }
    }
}
