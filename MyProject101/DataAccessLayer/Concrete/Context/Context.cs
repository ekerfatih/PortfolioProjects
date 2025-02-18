using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete.Context {
    public class Context : IdentityDbContext<AppUser, AppRole, int> {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Server=PHILOPHOBIC\\SQLEXPRESS; Database=MyProject101; Trusted_Connection=True; TrustServerCertificate=True;");

        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Customer> Customers => Set<Customer>();
    }
}

