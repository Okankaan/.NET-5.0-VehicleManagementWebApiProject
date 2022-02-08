using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMEntities.VMDBEntities;

namespace VMDataAccess
{
    public class VMDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=VehicleManagement;Trusted_connection=true");
        }

        public DbSet<Authority> Authorities { get; set; }
        public DbSet<AuthRole> AuthRoles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        /// <summary>
        /// Test / SEED DATA
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authority>().HasData(
                new Authority { Id = 1, Name = "Vehicle Insert Authority", Active = true },
                new Authority { Id = 2, Name = "Vehicle Update Authority", Active = true },
                new Authority { Id = 3, Name = "Vehicle Delete Authority", Active = true },
                new Authority { Id = 4, Name = "Vehicle List Authority", Active = true },
                new Authority { Id = 5, Name = "Brand List Authority", Active = true },
                new Authority { Id = 6, Name = "Model List Authority", Active = true }
            );

            modelBuilder.Entity<Role>().HasData(
              new Role { Id = 1, Name = "SystemAdministrator", Active = true },
              new Role { Id = 2, Name = "VehicleAdministrator", Active = true },
              new Role { Id = 3, Name = "BrandAdministrator", Active = true },
              new Role { Id = 4, Name = "ModelAdministrator", Active = true },
              new Role { Id = 5, Name = "User", Active = true }
          );

            modelBuilder.Entity<AuthRole>().HasData(
                new AuthRole { Id = 1, AuthorityId = 1, RoleId = 1, Active = true },
                new AuthRole { Id = 2, AuthorityId = 2, RoleId = 1, Active = true },
                new AuthRole { Id = 3, AuthorityId = 3, RoleId = 1, Active = true },
                new AuthRole { Id = 4, AuthorityId = 4, RoleId = 1, Active = true },
                new AuthRole { Id = 5, AuthorityId = 5, RoleId = 1, Active = true },
                new AuthRole { Id = 6, AuthorityId = 6, RoleId = 1, Active = true },

                new AuthRole { Id = 7, AuthorityId = 1, RoleId = 2, Active = true },
                new AuthRole { Id = 8, AuthorityId = 2, RoleId = 2, Active = true },
                new AuthRole { Id = 9, AuthorityId = 3, RoleId = 2, Active = true },
                new AuthRole { Id = 10, AuthorityId = 4, RoleId = 2, Active = true },

                new AuthRole { Id = 11, AuthorityId = 5, RoleId = 3, Active = true },

                new AuthRole { Id = 12, AuthorityId = 6, RoleId = 4, Active = true },

                new AuthRole { Id = 13, AuthorityId = 4, RoleId = 5, Active = true },
                new AuthRole { Id = 14, AuthorityId = 5, RoleId = 5, Active = true },
                new AuthRole { Id = 15, AuthorityId = 6, RoleId = 5, Active = true }
            );

            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, Name = "Okan Kaan Cetinkaya", Password = "1234", EMail = "okankaan.cetinkaya@gmail.com", Active = true },
              new User { Id = 2, Name = "Maria Anders", Password = "1234", EMail = "maria.anders@test.com", Active = true },
              new User { Id = 3, Name = "Antonio Moreno Taquería", Password = "1234", EMail = "antonio.moreno@test.com", Active = true },
              new User { Id = 4, Name = "Sven Ottlieb", Password = "1234", EMail = "sven.ottlieb@test.com", Active = true },
              new User { Id = 5, Name = "Carine Schmitt", Password = "1234", EMail = "carine.schmitt@test.com", Active = true }
          );

            modelBuilder.Entity<UserRole>().HasData(
              new UserRole { Id = 1, UserId = 1, RoleId = 1, Active = true },
              new UserRole { Id = 2, UserId = 2, RoleId = 2, Active = true },
              new UserRole { Id = 3, UserId = 3, RoleId = 3, Active = true },
              new UserRole { Id = 4, UserId = 4, RoleId = 4, Active = true },
              new UserRole { Id = 5, UserId = 5, RoleId = 5, Active = true }
          );

            modelBuilder.Entity<Color>().HasData(
              new Color { Id = 1, Name = "White", Active = true },
              new Color { Id = 2, Name = "Red", Active = true },
              new Color { Id = 3, Name = "Night Blue", Active = true },
              new Color { Id = 4, Name = "Black", Active = true },
              new Color { Id = 5, Name = "Space Grey", Active = true }
          );

            modelBuilder.Entity<Brand>().HasData(
              new Brand { Id = 1, Name = "Bmw", Active = true },
              new Brand { Id = 2, Name = "Toyota", Active = true },
              new Brand { Id = 3, Name = "Fiat", Active = true },
              new Brand { Id = 4, Name = "Opel", Active = true },
              new Brand { Id = 5, Name = "Audi", Active = true }
          );

            modelBuilder.Entity<Model>().HasData(
              new Model { Id = 1, Name = "Yaris", BrandId = 2, Active = true },
              new Model { Id = 2, Name = "Rav 4", BrandId = 2, Active = true },
              new Model { Id = 3, Name = "x5", BrandId = 1, Active = true },
              new Model { Id = 4, Name = "Corsa", BrandId = 4, Active = true },
              new Model { Id = 5, Name = "Corolla", BrandId = 2, Active = true }
          );

            modelBuilder.Entity<Vehicle>().HasData(
             new Vehicle { Id = 1, UserId = 1, ModelId = 2, ColorId = 2, Price = 200000, Active = true },
             new Vehicle { Id = 2, UserId = 1, ModelId = 1, ColorId = 5, Price = 150000, Active = true },
             new Vehicle { Id = 3, UserId = 5, ModelId = 3, ColorId = 4, Price = 230000, Active = true },
             new Vehicle { Id = 4, UserId = 4, ModelId = 4, ColorId = 2, Price = 500000, Active = true },
             new Vehicle { Id = 5, UserId = 3, ModelId = 2, ColorId = 2, Price = 200000, Active = true },
             new Vehicle { Id = 6, UserId = 3, ModelId = 5, ColorId = 3, Price = 300000, Active = true }
         );
        }

    }
}
