using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProjetoTeste.Context;
using ProjetoTeste.Repository;
using ProjetoTeste.Service;

namespace ProjetoTeste
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
                optionsBuilder.UseSqlite("Data Source=/home/fabio/Sources/Pessoal/Samples/Arquitetura/ProjetoTeste/App_Data/Teste.db");
                return new TesteContext(optionsBuilder.Options);
            });

            Services.AddScoped<IProdutoRepository, ProdutoRepository>();
            Services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}