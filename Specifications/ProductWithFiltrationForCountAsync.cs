using Round2Api.Models;

namespace Round2Api.Specifications
{
    public class ProductWithFiltrationForCountAsync : BaseSpecification<Product>
    {
        public ProductWithFiltrationForCountAsync(ProductSpecParams Param) :
            base(p =>
            (!Param.BrandId.HasValue || p.ProductBrandId == Param.BrandId)
            &&
            (!Param.TypeId.HasValue || p.ProductTypeId == Param.TypeId)
            &&
            (string.IsNullOrEmpty(Param.Search) || p.Name.ToLower().Contains(Param.Search))
            )
        {

        }
    }
}
