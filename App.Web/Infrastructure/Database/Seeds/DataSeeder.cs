using App.Web.Models.Constants;
using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using static App.Web.Models.Constants.Constants;

namespace App.Web.Infrastructure.Database.Seeds
{
    public class DataSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity { Id = Roles.AdminId, Name = Roles.Admin },
                new RoleEntity { Id = Roles.RegularId, Name = Roles.Regular }
            );

            modelBuilder.Entity<PersonEntity>().HasData(
                new PersonEntity { 
                    Id = new Guid("5EB7D209-020B-477C-9E01-DB717874FAF6"),
                    Name = "Harold Andrés Bartolo Moscoso",
                    Address = "Calle 49 A Sur 87 J 29",
                    Phone = "3028305818" 
                }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity {
                    Id = new Guid("C95EE721-EFDD-4E25-B969-45A9F6235E45"),
                    Username = "admin",
                    PasswordHash = "omXELhhijwpUNqzdst2HTtuY8oplkmgyRi7o45Ptrjc=",
                    PasswordSalt = "aL5obEwZGtIprvlpvLA6BQ==",
                    IsActive = true,
                    RoleId = Roles.AdminId,
                    PersonId = new Guid("5EB7D209-020B-477C-9E01-DB717874FAF6")
                }
            );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Mallow TM97 AMD Ryzen 5 4600G Ram 8GB SSD 480GB", Price = 1650000, Stock = 1 , Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Mallow TM92 AMD Ryzen 3 4100 GT 1030 2GB Ram 8GB M.2 256GB *Ob", Price = 1599000, Stock = 0, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Mallow TM96 AMD Ryzen 5 5600G Ram 16GB M.2 512GB", Price = 1999000, Stock = 11, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Violet TV40 Intel Core i3-13100F GTX 1650 4GB Ram 16GB M", Price = 2899000, Stock = 13, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Orchid TO70 AMD Ryzen 5 4600G GTX 1660 Ti 6GB Ram", Price = 3499000, Stock = 15, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Orchid TO66 Intel Core i5-12400 GTX 1660 6GB Ram", Price = 3799000, Stock = 14, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA73 Intel core 13400F RTX 3060 Ti 8GB R", Price = 3899000, Stock = 10, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA70 Alto Rendimiento AMD Ryzen 7 5700X", Price = 5150000, Stock = 13, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Orchid TO72 AMD Ryzen 5 5600X RTX 3050 8GB Ram 16", Price = 5799000, Stock = 21, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA53 AMD Ryzen 7 5800X3D RTX 3060 12GB R", Price = 6599000, Stock = 8, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA66 intel Core i5-13400F RTX 3070 8GB R", Price = 6799000, Stock = 4, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA71 AMD Ryzen 7 5800X3D RTX 4070 12GB R", Price = 7999000, Stock = 10, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA75 AMD Ryzen 5 7600X RTX 4060 Ti 8GB R", Price = 7999000, Stock = 5, Description = "Laptop" },
                new ProductEntity { Id = Guid.NewGuid(), Name = "PC Gamer Tauret Amethyst TA76 AMD Ryzen 7 7700X RTX 4070 Ti 12GB", Price = 9799000, Stock = 5, Description = "Laptop"  }
            );
        }
    }
}
