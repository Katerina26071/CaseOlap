using System.Data.Entity;

namespace MvcSmallScreen.Models
{
    public class PCStoreEntities : DbContext
    {
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        /*public System.Data.Entity.DbSet<MvcSmallScreen.Models.Laptop> Laptops { get; set; }*/
    }
}