using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastructure.Interfaces;
using E_Commerce.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly E_CommerceDbContext _context;
        public GenericRepository(E_CommerceDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByID(int id, params string[] includes)
        {
            var _set = _context.Set<T>().AsQueryable();

            foreach (var inc in includes)
            {
                _set = _set.Include(inc);
            }
            return await _set.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }

        public async Task Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity, int id)
        {
            T? entity2 = await _context.Set<T>().FindAsync(id);
            if (entity2 != null)
            {
                _context.Entry(entity2).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }

}
