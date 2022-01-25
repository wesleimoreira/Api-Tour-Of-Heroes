using Microsoft.EntityFrameworkCore;
using Api_Tour_Of_Heroes_Domain.Data;
using Api_Tour_Of_Heroes_Domain.Entities;
using Api_Tour_Of_Heroes_Domain.Interfaces;

namespace Api_Tour_Of_Heroes_Infrastructure.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            this._context = context;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await this._context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await this._context.Set<TEntity>().AsNoTracking().FirstAsync(x => x.Id == id);
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            await this._context.Set<TEntity>().AddAsync(entity);
            return await this._context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
            return await this._context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            this._context.Set<TEntity>().Update(entity);
            return await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
