using Round2Api.Models;
using Round2Api.Specifications;

namespace Round2Api.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseModel 
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec);
    Task<T> GetByIdAsync(ISpecification<T> spec);
    Task<T> GetByIdAsync(int Id);
    Task AddAsync (T item);
    void Update (T item);
    void Delete (T item);

    Task<int> GetCountWithSpecAsync(ISpecification<T> spec);
}