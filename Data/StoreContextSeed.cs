using System.Text.Json;
using Round2Api.Models;
using Round2Api.Models.Order;

namespace Round2Api.Data;

public static class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext dbContext)
    {
        if (!dbContext.ProductBrands.Any())
        {
            var brandsData = File.ReadAllText("../Round2Api/Data/DataSeed/brands.json");
            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if (brands?.Count>0)
            {
                foreach (var brand in brands)
                {
                    await dbContext.Set<ProductBrand>().AddAsync(brand);
                }
                await dbContext.SaveChangesAsync();
            }
        }

        if (!dbContext.ProductTypes.Any())
        {
            var typesData = File.ReadAllText("../Round2Api/Data/DataSeed/types.json");
            var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if (types?.Count > 0)
            {
                foreach (var type in types)
                {
                    await dbContext.Set<ProductType>().AddAsync(type);
                }
                await dbContext.SaveChangesAsync();
            }
        }

        if (!dbContext.Products.Any())
        {
            var productsData = File.ReadAllText("../Round2Api/Data/DataSeed/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if (products?.Count > 0)
            {
                foreach (var product in products)
                {
                    await dbContext.Set<Product>().AddAsync(product);
                }
                await dbContext.SaveChangesAsync();
            }
        }
        ///Seeding DeliveryMethods
        if (!dbContext.DeliveryMethods.Any())
        {
            var DeliveryMethodsData = File.ReadAllText("../Round2Api/Data/DataSeed/delivery.json");
            var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodsData);

            if (DeliveryMethods?.Count > 0)
            {
                foreach (var DeliveryMethod in DeliveryMethods)
                    await dbContext.Set<DeliveryMethod>().AddAsync(DeliveryMethod);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}