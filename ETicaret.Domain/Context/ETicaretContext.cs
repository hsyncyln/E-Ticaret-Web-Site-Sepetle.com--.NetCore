using ETicaret.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Domain.Context
{
    public class ETicaretContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\MSSQLServer01;Database=ETicaret;Integrated Security=True;");
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Bill> Bills { get; set; }

    }
}
