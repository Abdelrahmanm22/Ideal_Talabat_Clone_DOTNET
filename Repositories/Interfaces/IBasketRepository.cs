using Round2Api.Models;

namespace Round2Api.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        //Get Basket
        Task<CustomerBasket?> GetBasketAsync(string basketId);

        //Update Basket
        Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket);

        //Delete Basket
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
