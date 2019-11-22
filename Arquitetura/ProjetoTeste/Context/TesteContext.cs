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
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Produto>().HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
    }
}