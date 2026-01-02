using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Round2Api.Models.Identity;

namespace Round2Api.Extensions
{
    public static class UserManagerExtension
    {
        // to override var user = await userManager.FindByEmailAsync(Email);
        public static async Task<AppUser?> FindUserWithAddressAsync(this UserManager<AppUser> userManager,string email)
        {
            var user = await userManager.Users.Where(U=>U.Email == email).Include(U=>U.Address).FirstOrDefaultAsync();
            return user;
        }
    }
}
