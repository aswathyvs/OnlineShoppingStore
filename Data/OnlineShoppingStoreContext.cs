using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Data
{
    public class OnlineShoppingStoreContext : IdentityDbContext<AppUser>
    {
        public OnlineShoppingStoreContext(DbContextOptions<OnlineShoppingStoreContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
