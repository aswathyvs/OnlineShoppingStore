using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Data
{
    public class OnlineShoppingStoreContext : DbContext
    {
        public OnlineShoppingStoreContext(DbContextOptions<OnlineShoppingStoreContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
