namespace BackEndForFrontEnd.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(int? limit = null);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> CreateAsync(T entity);
    Task<T?> UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
}
