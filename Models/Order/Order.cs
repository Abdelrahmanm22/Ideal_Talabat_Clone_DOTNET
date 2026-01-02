namespace Round2Api.Models.Order
{
    public class Order : BaseModel
    {
        public Order()
        {
            
        }
        public Order(string buyerEmail, Address address, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = address;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShippingAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>(); //[Many]
        public decimal SubTotal {  get; set; }

        public decimal GetTotal()
        => SubTotal+DeliveryMethod.Cost;
        
        public string PaymentIntentId { get; set; } = string.Empty;
    }
}
