using Microsoft.EntityFrameworkCore;
using Round2Api.Data;
using Round2Api.Models;
using Round2Api.Repositories.Interfaces;
using Round2Api.Specifications;

namespace Round2Api.Repositories.Concretes;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
{
    private readonly StoreContext dbContext;

    public GenericRepository(StoreContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task AddAsync(T item)
    {
        await dbContext.Set<T>().AddAsync(item);
    }
    public void Update(T item)
    {
        dbContext.Set<T>().Update(item);
    }

    public void Delete(T item)
    {
        dbContext.Set<T>().Remove(item);
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await dbContext.Set<T>().ToListAsync();
    }
    public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }
        
    
    public async Task<T> GetByIdAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<T> GetByIdAsync(int Id)
    {
        return await dbContext.Set<T>().FindAsync(Id);
    }

    public async Task<int> GetCountWithSpecAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvalutor<T>.BuildQuery(dbContext.Set<T>(), spec);
    }
}