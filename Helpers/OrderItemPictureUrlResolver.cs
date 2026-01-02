using AutoMapper;
using Round2Api.DTOs;
using Round2Api.Models.Order;

namespace Round2Api.Helpers
{
    public class OrderItemPictureUrlResolver : IValueResolver<OrderItem,OrderItemDto,string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemPictureUrlResolver(IConfiguration _configuration)
        {
            _configuration = _configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseURL"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
