using Round2Api.Models.Order;

namespace Round2Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(string BuyerEmail, string BasketId, int DeliveryMethodId, Address ShippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string BuyerEmail);
        Task<Order?> GetOrderByIdForSpecificUserAsync(string BuyerEmail, int OrderId);
    }
}
