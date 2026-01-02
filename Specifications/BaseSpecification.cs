using System.Linq.Expressions;
using Round2Api.Models;

namespace Round2Api.Specifications;

public class BaseSpecification<T>:ISpecification<T> where T:BaseModel
{
    public Expression<Func<T, bool>> Criteria { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
    public Expression<Func<T, object>> OrderBy { get; set; }
    public Expression<Func<T, object>> OrderByDesc { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }

    //Get All
    public BaseSpecification()
    {
        // Includes = new List<Expression<Func<T, object>>>();
    }

    //Get by id
    public BaseSpecification(Expression<Func<T, bool>>  criteriaExp)
    {
        Criteria = criteriaExp;
        // Includes = new List<Expression<Func<T, object>>>();
    }
    public void AddOrderBy(Expression<Func<T, object>> orderByExp)
    {
        OrderBy = orderByExp;
    }

    public void AddOrderByDesc(Expression<Func<T, object>> orderByExp)
    {
        OrderByDesc = orderByExp;
    }
    public void ApplyPagination(int skip,int take)
    {
        Skip = skip;
        Take = take;
    }
}