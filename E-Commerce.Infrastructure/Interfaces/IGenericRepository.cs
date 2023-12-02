using E_Commerce.Shared.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : IEntity
    {
        Task<T> GetByID(int id);
        Task<T> GetByID(int id, params string[] includes);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task Update(T entity, int id);
        Task SaveChangesAsync();
    }
}
