using Round2Api.Models;
using Round2Api.Models.Order;
using Round2Api.Repositories.Interfaces;
using Round2Api.Services.Interfaces;
using Round2Api.Specifications;
using Round2Api.UnitOfWorkLayer;

namespace Round2Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IBasketRepository basketRepository,
            IUnitOfWork unitOfWork)
        {
            this._basketRepository = basketRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<Order?> CreateOrderAsync(string BuyerEmail, string BasketId, int DeliveryMethodId, Address ShippingAddress)
        {
            #region Steps for our business
            //1. Get Basket from basket repo
            var Basket = await _basketRepository.GetBasketAsync(BasketId);
            //2. Get Selected Items at basket from product repo
            var OrderItems = new List<OrderItem>();
            if (Basket?.Items.Count > 0)
            {
                foreach (var item in Basket.Items)
                {

                    var Product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                    var OrderItem = new OrderItem(Product.Id, Product.Name, Product.ImageUrl, item.Quantity, Product.Price);
                    OrderItems.Add(OrderItem);
                }
            }
            //3. Calculate SubTotal
            var SubTotal = OrderItems.Sum(Item => Item.Price * Item.Quantity);
            //4. Get Delivery Method From DeliveryMethod Repo
            var DeliceryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(DeliveryMethodId);
            //5. Create Order
            var Order = new Order(BuyerEmail, ShippingAddress, DeliceryMethod, OrderItems, SubTotal);
            //6. Add Order Locally
            await _unitOfWork.Repository<Order>().AddAsync(Order);
            //7. Save Order To Database
            var result = await _unitOfWork.CompleteAsync();
            if (result <= 0) return null;
            return Order;
            #endregion
        }

        public async Task<Order?> GetOrderByIdForSpecificUserAsync(string BuyerEmail, int OrderId)
        {
            var spec = new OrderSpecifications(BuyerEmail, OrderId);
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(spec);
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForSpecificUserAsync(string BuyerEmail)
        {
            var spec = new OrderSpecifications(BuyerEmail);
            var order = await _unitOfWork.Repository<Order>().GetAllAsync(spec);
            return order;
        }
    }
}
