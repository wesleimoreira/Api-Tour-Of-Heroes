using Api_Tour_Of_Heroes_Domain.Entities;

namespace Api_Tour_Of_Heroes_Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(TEntity entity);
    }
}
