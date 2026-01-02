using AutoMapper;
using Round2Api.DTOs;
using Round2Api.Models;
using Round2Api.Models.Identity;
using Round2Api.Models.Order;

namespace Round2Api.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductToReturnDto>()
            .ForMember(dest=>dest.ProductType,opt=>opt.MapFrom(src=>src.ProductType.Name))
            .ForMember(dest=>dest.ProductBrand,opt=>opt.MapFrom(src=>src.ProductBrand.Name))
            .ForMember(dest=>dest.ImageUrl,opt=>opt.MapFrom<ProductPictureUrlResolver>());

        //For Address
        CreateMap<Models.Identity.Address, AddressDto>().ReverseMap();
        CreateMap<CustomerBasketDto, CustomerBasket>();
        CreateMap<BasketItemDto, BasketItem>();
        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d=>d.DeliveryMethod,o=>o.MapFrom(s=>s.DeliveryMethod.ShortName))
            .ForMember(d=>d.DeliveryMethodCost,o=>o.MapFrom(s=>s.DeliveryMethod.Cost));

        CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemPictureUrlResolver>());
    }
}