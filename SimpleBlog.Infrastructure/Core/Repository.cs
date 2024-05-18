using Microsoft.EntityFrameworkCore;
using SimpleBlog.Domain.Core;
using SimpleBlog.Domain.Core.Repositories;

namespace SimpleBlog.Infrastructure.Core
{
    internal class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbSet.Where(e => e.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return _dbSet.Where(e => e.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
