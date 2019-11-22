using Microsoft.EntityFrameworkCore;
using ProjetoTeste.Entitiy;

namespace ProjetoTeste.Context
{
    public class TesteContext : DbContext
    {
        protected TesteContext()
        {
        }

        public TesteContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}