using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RunGroupWebAppMVC.Data.Constants;
using RunGroupWebAppMVC.Models;

namespace RunGroupWebAppMVC.Data.Seed
{
    public static class SeedUserAndRole
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            //Roles
            string[] roleNames = { UserRoles.Admin, UserRoles.User };
            IdentityResult roleResult;
            foreach (var role in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            //User
            string adminUserEmail = "teddysmithdeveloper@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new AppUser()
                {
                    UserName = "teddysmithdev",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                    AddressId=1
                };
                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }
            string appUserEmail = "user@etickets.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new AppUser()
                {
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    AddressId=2
                };
                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }
}

