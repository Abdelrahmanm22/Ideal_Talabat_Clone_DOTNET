using Microsoft.AspNetCore.Identity;
using Round2Api.Models.Identity;

namespace Round2Api.Data
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var User = new AppUser()
                {
                    DisplayName = "Abdelrahman Mohamed",
                    Email = "abdelrahmanmohamed2293@gmail.com",
                    UserName = "abdelrahman22",
                    PhoneNumber = "01015496488",
                };

                await userManager.CreateAsync(User, "Pa$$w0rd");
            }
        }
    }
}
