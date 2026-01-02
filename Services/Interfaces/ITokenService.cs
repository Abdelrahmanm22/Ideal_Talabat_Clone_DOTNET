using Microsoft.AspNetCore.Identity;
using Round2Api.Models.Identity;

namespace Round2Api.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateTokenAsync(AppUser User, UserManager<AppUser> userManager);
    }
}
