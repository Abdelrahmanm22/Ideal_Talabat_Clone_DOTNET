using Round2Api.Models;

namespace Round2Api.Specifications;

public class ProductWithBrandAndTypeSpecification : BaseSpecification<Product>
{
    public ProductWithBrandAndTypeSpecification(ProductSpecParams productSpec)
        : base(p=>
            (!productSpec.BrandId.HasValue || p.ProductBrandId== productSpec.BrandId)
            &&
            (!productSpec.TypeId.HasValue || p.ProductTypeId== productSpec.TypeId)
            &&
            ( string.IsNullOrEmpty(productSpec.Search) || p.Name.ToLower().Contains(productSpec.Search))
        )
    {
        Includes.Add(p => p.ProductType);
        Includes.Add(p => p.ProductBrand);
        if (!string.IsNullOrEmpty(productSpec.Sort))
        {
            switch (productSpec.Sort)
            {
                case "PriceAsc":
                    AddOrderBy(P => P.Price);
                    break;
                case "PriceDesc":
                    AddOrderByDesc(P => P.Price);
                    break;
                default:
                    AddOrderBy(P => P.Name);
                    break;
            }

        }

        ApplyPagination(productSpec.PageSize * (productSpec.PageIndex - 1), productSpec.PageSize);
    }
    public ProductWithBrandAndTypeSpecification(int id):base(p=>p.Id == id)
    {
        Includes.Add(p => p.ProductType);
        Includes.Add(p => p.ProductBrand);
    }
}