using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dara_Store.Application.Interfaces.Contexts;
using Dara_Store.Common.Roles;
using Dara_Store.Domain.Entities.HomePages;
using Dara_Store.Domain.Entities.Products;
using Dara_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Dara_Store.Persistence.Contexts
{
    public class DataBaseContext:DbContext , IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<HomePageImages> HomePageImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed Data
            SeedData(modelBuilder);

            //افزودن مقادیر پیش فرض به جدول Roles
           

            //اعمال ایندکس بر روی فیلد ایمیل
            //اعمال عدم تکراری بودن ایمیل
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

            //عدم نمایش اطلاعات حذف شده
            ApplyQuaryFilter(modelBuilder);
            
        }
        private void ApplyQuaryFilter(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<Role>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<UserInRole>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<Slider>().HasQueryFilter(p => !p.IsRemove);
            modelBuilder.Entity<HomePageImages>().HasQueryFilter(p => !p.IsRemove);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { Id = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { Id = 3, Name = nameof(UserRoles.Customer) });
        }
    }
}
