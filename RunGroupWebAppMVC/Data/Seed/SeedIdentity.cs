using Microsoft.AspNetCore.Identity;
using RunGroupWebAppMVC.Data.Constants;
using RunGroupWebAppMVC.Models;

namespace RunGroupWebAppMVC.Data.Seed
{
    public class SeedIdentity
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedIdentity(UserManager<AppUser> userManager,
            ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        public async Task SeedInitialIdentityData()
        {
            await SeedUsersAndRolesAsync();

        }
        public async Task SeedUsersAndRolesAsync()
        {
            string adminUserEmail = "teddysmithdeveloper@gmail.com";
            var adminUser = await _userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new AppUser()
                {
                    UserName = "teddysmithdev",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                    Address = new Address()
                    {
                        Street = "123 Main St",
                        City = "Charlotte",
                        State = "NC"
                    }
                };
                await _userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await _userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }
            string appUserEmail = "user@etickets.com";

            var appUser = await _userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new AppUser()
                {
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    Address = new Address()
                    {
                        Street = "123 Main St",
                        City = "Charlotte",
                        State = "NC"
                    }
                };
                await _userManager.CreateAsync(newAppUser, "Coding@1234?");
                await _userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }    
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            string[] roleNames = { UserRoles.Admin, UserRoles.User };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExists =await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string adminUserEmail = "teddysmithdeveloper@gmail.com";
            var adminpassword = "Coding@1234?";

            if (userManager.FindByEmailAsync(adminUserEmail).Result == null)
            {
                var newAdminUser = new AppUser()
                {
                    UserName = "teddysmithdev",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                    Address = new Address()
                    {
                        Street = "123 Main St",
                        City = "Charlotte",
                        State = "NC"
                    }
                };

                IdentityResult result = userManager.CreateAsync(newAdminUser, adminpassword).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin).Wait();
                }


            }

            string appUserEmail = "user@etickets.com";
            var appUserPass = "Coding@1234?";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new AppUser()
                {
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    Address = new Address()
                    {
                        Street = "123 Main St",
                        City = "Charlotte",
                        State = "NC"
                    }
                };
                IdentityResult result = userManager.CreateAsync(newAppUser, appUserPass).Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newAppUser, UserRoles.User).Wait();
                }
            }            
        }
    }
}
