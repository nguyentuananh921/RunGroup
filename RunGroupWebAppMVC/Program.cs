using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RunGroupWebAppMVC.Data;
using RunGroupWebAppMVC.Data.Seed;
using RunGroupWebAppMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region AddDBContext
var connectionString = builder.Configuration.GetConnectionString("TeddySmith-RunGroup") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
#endregion
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#region Add Identity
builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
#endregion

#region register the Seed Data class
builder.Services.AddTransient<SeedData>();//https://medium.com/@sebastiankern/on-create-a-data-seeder-with-ef-core-and-asp-net-core-web-api-net-8-72a8816b4b77
builder.Services.AddTransient<SeedIdentity>();

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


#region Seed Data
using (var scope = app.Services.CreateScope())
{
    var service =scope.ServiceProvider;
    var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();

    //https://github.com/robinskoogh/BookStore/blob/master/Program.cs
    //https://www.youtube.com/watch?v=26VIcXcZlwc
    
    //var userManager= scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    //var roleManager= scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    seeder.SeedInitialData();
    //SeedIdentity.InitializeAsync(service);

    var seedIdentity = scope.ServiceProvider.GetRequiredService<SeedIdentity>();
    seedIdentity.SeedInitialIdentityData();
}

#endregion
app.Run();
