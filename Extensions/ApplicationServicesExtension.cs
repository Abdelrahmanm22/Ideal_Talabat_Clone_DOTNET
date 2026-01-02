using Microsoft.AspNetCore.Mvc;
using Round2Api.Errors;
using Round2Api.Helpers;
using Round2Api.Repositories.Concretes;
using Round2Api.Repositories.Interfaces;
using Round2Api.Services;
using Round2Api.Services.Interfaces;
using Round2Api.UnitOfWorkLayer;

namespace Round2Api.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection Services)   //// el caller hya hya el parameter ely hytb3tlk
    {
        Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        Services.AddAutoMapper(typeof(MappingProfiles));
        Services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
        #region validation error
        Services.Configure<ApiBehaviorOptions>(Options =>
        {
            Options.InvalidModelStateResponseFactory = (actionContext) =>
            {
                var errors = actionContext.ModelState
                    .Where(p => p.Value.Errors.Count() > 0)
                    .SelectMany(p => p.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                var ValidationErrorResponse = new ApiValidationErrorResponse()
                {
                    Errors = errors
                };
                return new BadRequestObjectResult(ValidationErrorResponse);
            };
        });
        #endregion
        Services.AddScoped<IUnitOfWork, UnitOfWork>();
        Services.AddScoped<IOrderService, OrderService>();
        return Services;
    }
}