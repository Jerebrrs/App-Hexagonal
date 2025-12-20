
namespace App_Hexagonal.Application.Common.Persistence
{
    public interface IRepository<T, TId>
    {
        Task<T?> GetByIdAsync(TId id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(TId id);
    }
}