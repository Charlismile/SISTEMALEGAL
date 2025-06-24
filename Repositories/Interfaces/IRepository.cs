using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SISTEMALEGAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
    }
}