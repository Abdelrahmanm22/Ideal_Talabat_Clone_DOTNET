using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Round2Api.Models;

public class Product : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    
    public int ProductBrandId { get; set; }
    public ProductBrand ProductBrand { get; set; }
    
    public int ProductTypeId { get; set; }
    public ProductType ProductType { get; set; }
}