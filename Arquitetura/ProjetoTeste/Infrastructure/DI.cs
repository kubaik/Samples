using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Domain.Produto;
using ProjetoTeste.Infrastructure.Context;

namespace ProjetoTeste.Infrastructure
{
    public static class DI
    {
        private static ServiceCollection Services { get; } = new ServiceCollection();
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Initialize()
        {
            RegisteredServices();
            ServiceProvider = Services.BuildServiceProvider();
        }

        private static void RegisteredServices()
        {
            Services.AddScoped<TesteContext>(provider =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<TesteContext>();
                optionsBuilder.UseSqlite("Data Source=../../../App_Data/Teste.db");
                return new TesteContext(optionsBuilder.Options);
            });

            Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            Services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}