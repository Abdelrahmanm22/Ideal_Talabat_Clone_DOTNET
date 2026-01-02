using AutoMapper;
using AutoMapper.Execution;
using Round2Api.DTOs;
using Round2Api.Models;

namespace Round2Api.Helpers;

public class ProductPictureUrlResolver : IValueResolver<Product,ProductToReturnDto,string>
{
    private readonly IConfiguration _configuration;

    public ProductPictureUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImageUrl))
        {
            return $"{_configuration["ApiBaseURL"]}{source.ImageUrl}";
        }
        return string.Empty;
    }
}