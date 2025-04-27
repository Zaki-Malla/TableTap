using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TableTap.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TableTap.Models
{
    public class TTContext : IdentityDbContext<UserModel, RoleModel, int>
    {
        private readonly IConfiguration _configuration;

        public TTContext() { }

        public TTContext(DbContextOptions<TTContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<UserModel> TbUser { get; set; }
        public virtual DbSet<RoleModel> TbRole { get; set; }
        public virtual DbSet<CityModel> TbCity { get; set; }
        public virtual DbSet<EstablishmentModel> TbEstablishment { get; set; }
        public virtual DbSet<SubscriptionModel> TbSubscription { get; set; }
        public virtual DbSet<SubscriptionPlanModel> TbSubscriptionPlan { get; set; }
        public virtual DbSet<MenuModel> TbMenus { get; set; }
        public virtual DbSet<CategoryModel> TbCategories { get; set; }
        public virtual DbSet<MenuItemModel> TbMenuItems { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. CityModel → EstablishmentModel (One-to-Many)
            modelBuilder.Entity<CityModel>()
                .HasMany(c => c.Establishments)             
                .WithOne(e => e.City)                      
                .HasForeignKey(e => e.CityId)               
                .OnDelete(DeleteBehavior.Restrict);

            // 2. Establishment ↔ User (1:1, required for Establishment, optional for User)
            modelBuilder.Entity<EstablishmentModel>()
                .HasOne(e => e.User)                        
                .WithOne(u => u.Establishment)              
                .HasForeignKey<EstablishmentModel>(e => e.UserId) 
                .OnDelete(DeleteBehavior.Cascade);          

            // 3. EstablishmentModel → SubscriptionModel (One-to-Many)
            modelBuilder.Entity<EstablishmentModel>()
                .HasMany(e => e.Subscriptions)              
                .WithOne(s => s.Establishment)              
                .HasForeignKey(s => s.RestaurantId);      

            // 4. SubscriptionPlanModel → SubscriptionModel (One-to-Many)
            modelBuilder.Entity<SubscriptionPlanModel>()
                .HasMany(p => p.Subscriptions)              
                .WithOne(s => s.Plan)                       
                .HasForeignKey(s => s.PlanId);

            // 5. EstablishmentModel → MenuModel (One-to-Many)
            modelBuilder.Entity<EstablishmentModel>()
                .HasMany(e => e.Menus)
                .WithOne(m => m.Establishment)
                .HasForeignKey(m => m.EstablishmentId)
                .OnDelete(DeleteBehavior.Cascade);

            //6. MenuModel → CategoryModel (One-to-Many)
            modelBuilder.Entity<MenuModel>()
                .HasMany(m => m.Categories)
                .WithOne(c => c.Menu)
                .HasForeignKey(c => c.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            //7. CategoryModel → MenuItemModel (One-to-Many)
            modelBuilder.Entity<CategoryModel>()
                .HasMany(c => c.MenuItems)
                .WithOne(mi => mi.Category)
                .HasForeignKey(mi => mi.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }
}