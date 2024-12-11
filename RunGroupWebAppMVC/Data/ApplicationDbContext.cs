using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RunGroupWebAppMVC.Models;
using System.Linq;

namespace RunGroupWebAppMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Race> Races { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); //Remember to add this
            #region Custom UserManagement
            //builder.HasDefaultSchema("Identity");
            builder.Entity<AppUser>(entity =>
            {
                entity.ToTable(name: "User", schema: "Identity");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role", schema: "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", schema: "Identity");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", schema: "Identity");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", schema: "Identity");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", schema: "Identity");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", schema: "Identity");
            });
            #endregion
            #region Seed Identity Data //https://www.youtube.com/watch?v=WpymlVGek94 17:13
            //https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
            builder.Entity<IdentityRole>().HasData 
            (
                new IdentityRole() { Name="Admin", ConcurrencyStamp="1",NormalizedName="Administrator" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "2", NormalizedName = "Normal User" }

            );
            #endregion

            #region Data   //https://learn.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-schema
            builder.Entity<Race>(entity =>
            {
                entity.ToTable(name: "Races", schema: "Data");
            });
            builder.Entity<Club>(entity =>
            {
                entity.ToTable(name: "Clubs", schema: "Data");
            });
            builder.Entity<Address>(entity =>
            {
                entity.ToTable(name: "Addresses", schema: "Data");
            });
            builder.Entity<State>(entity =>
            {
                entity.ToTable(name: "States", schema: "Data");
            });
            builder.Entity<City>(entity =>
            {
                entity.ToTable(name: "Cities", schema: "Data");
            });
            #endregion
        }
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                
                );
        }
    }
}
