using App.Web.Infrastructure.Database.Seeds;
using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Infrastructure.Database.Context
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<PersonEntity> Persons { get; set; }
        public virtual DbSet<OrderProductEntity> Products { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(e => e.Id);
                entity.HasOne(o => o.User).WithMany(m => m.Orders).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Orders_Persons");
            });

            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<PersonEntity>(entity =>
            {
                entity.ToTable("Persons");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<OrderProductEntity>(entity =>
            {
                entity.ToTable("OrderProducts");
                entity.HasKey(e => e.Id);
                entity.HasOne(o => o.Order).WithMany(m => m.Products).HasForeignKey(f => f.OrderId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderProducts_Orders");
                entity.HasOne(o => o.Product).WithMany(m => m.Orders).HasForeignKey(f => f.ProductId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OrderProducts_Products");
            });

            modelBuilder.Entity<RoleEntity>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
                entity.HasOne(o => o.Person).WithOne(o => o.User).HasForeignKey<UserEntity>(f => f.PersonId); 
                entity.HasOne(o => o.Role).WithMany(o => o.Users).HasForeignKey(f => f.RoleId);
            });

            base.OnModelCreating(modelBuilder);
            DataSeeder.SeedData(modelBuilder);
        }
    }
}
