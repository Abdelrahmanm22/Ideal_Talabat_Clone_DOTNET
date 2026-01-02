using Round2Api.Models.Order;

namespace Round2Api.Specifications;

public class OrderSpecifications : BaseSpecification<Order>
{
    // get order for specific user
    public OrderSpecifications(string buyerEmail,int orderId) : base(o=>o.BuyerEmail == buyerEmail && o.Id ==orderId)
    {
        Includes.Add(O=>O.DeliveryMethod);
        Includes.Add(O=>O.Items);
    }
    //get orders for user
    public OrderSpecifications(string buyerEmail) : base(o=>o.BuyerEmail == buyerEmail)
    {
        Includes.Add(O=>O.DeliveryMethod);
        Includes.Add(O=>O.Items);
        AddOrderByDesc(O => O.OrderDate);
    }
}