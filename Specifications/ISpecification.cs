using System.Linq.Expressions;
using Round2Api.Models;

namespace Round2Api.Specifications;

public interface ISpecification<T> where T : BaseModel
{
    //sign for (Where(p=>p.Id == id))
    public Expression<Func<T,bool>> Criteria { get; set; }
    //sign for (.Include(P => P.ProductBrand).Include(P => P.ProductType)) => list of includes
    public List<Expression<Func<T,object>>> Includes { get; set; }
    public Expression<Func<T,object>> OrderBy { get; set; }
    public Expression<Func<T,object>> OrderByDesc { get; set; }
    public int Take { get; set; }
    public int Skip { get; set; }
}