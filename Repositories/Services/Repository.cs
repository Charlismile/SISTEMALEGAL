using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SISTEMALEGAL.Data;
using SISTEMALEGAL.Models.Entities.BdSisLegal;
using SISTEMALEGAL.Repositories.Interfaces;

namespace SISTEMALEGAL.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContextSisLegal _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContextSisLegal context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
    }
}