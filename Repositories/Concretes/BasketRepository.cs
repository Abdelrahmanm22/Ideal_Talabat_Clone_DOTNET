using System.Text.Json;
using Round2Api.Models;
using Round2Api.Repositories.Interfaces;
using StackExchange.Redis;

namespace Round2Api.Repositories.Concretes
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            database = redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await database.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var Basket = await database.StringGetAsync(basketId);
            if (Basket.IsNull) return null;
            else return JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var JsonBasket = JsonSerializer.Serialize(basket);
            // Create or Update
            var CreatedOrUpdated = await database.StringSetAsync(basket.Id, JsonBasket, TimeSpan.FromDays(1));

            if (!CreatedOrUpdated) return null;
            else return await GetBasketAsync(basket.Id);
        }
    }
}
