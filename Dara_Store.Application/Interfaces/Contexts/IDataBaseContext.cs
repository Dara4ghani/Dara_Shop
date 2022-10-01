using Dara_Store.Domain.Entities.Carts;
using Dara_Store.Domain.Entities.HomePages;
using Dara_Store.Domain.Entities.Products;
using Dara_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dara_Store.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }
         DbSet<Category> Categories { get; set; }
         DbSet<Product> Products { get; set; }
         DbSet<ProductImages> ProductImages { get; set; }
         DbSet<ProductFeatures> ProductFeatures { get; set; }
         DbSet<Slider> Sliders { get; set; }
         DbSet<HomePageImages> HomePageImages { get; set; }
         DbSet<Cart> Carts { get; set; }
         DbSet<CartItem> CartItems { get; set; }

        int SaveChanges(bool acceptAllChangeOnSuccess);
        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangeOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
