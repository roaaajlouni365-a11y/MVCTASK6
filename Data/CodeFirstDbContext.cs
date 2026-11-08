
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Models.CodeFirst;

namespace UniversityCafeteria.Data
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext(
            DbContextOptions<CodeFirstDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
