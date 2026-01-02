using Microsoft.EntityFrameworkCore;
using Round2Api.Models;

namespace Round2Api.Specifications;

public static class SpecificationEvalutor<T> where T:BaseModel
{
    //Fun to build query in dynamic way
    // original query for example => _dbContext.Set<T>().where(P=>P.Id==id).Include(P=>P.ProductBrand).Include(P=>P.ProductType);
    public static IQueryable<T> BuildQuery(IQueryable<T> inputQuery,ISpecification<T> spec)
    {
        var Query = inputQuery; //_dbContext.Set<T>()
        if (spec.Criteria is not null)
        {
            Query = Query.Where(spec.Criteria); //_dbContext.Set<T>().where(P=>P.Id==id)
        }

        if (spec.OrderBy is not null)
        {
            Query = Query.OrderBy(spec.OrderBy);
        }

        if (spec.OrderByDesc is not null)
        {
            Query = Query.OrderByDescending(spec.OrderByDesc);
        }
        
        Query = Query.Skip(spec.Skip).Take(spec.Take);

        Query = spec.Includes.Aggregate(Query, (CurrentQuery, NextIncludeExpression) => CurrentQuery.Include(NextIncludeExpression));
        return Query;
    }
}