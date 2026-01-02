namespace Round2Api.Models.Order
{
    public class OrderItem : BaseModel
    {
        public OrderItem()
        {

        }
        public OrderItem(int productId, string productName, string pictureUrl, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
            Quantity = quantity;
            Price = price;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
