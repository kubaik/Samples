using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProjetoTeste.Infrastructure.Context
{
    public class TesteContextFactory : IDesignTimeDbContextFactory<TesteContext>
    {
        public TesteContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TesteContext>();
            optionsBuilder.UseSqlite("Data Source=App_Data/Teste.db");
            return new TesteContext(optionsBuilder.Options);
        }
    }
}