using System;
using Maestria.Extensions;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste.Domain.Produto;
using ProjetoTeste.Infrastructure;

namespace ProjetoTeste.Presentation
{
    public class MenuView
    {
        public void Start()
        {
            string op = null;
            while (op != "9")
            {
                Console.Clear();
                Console.WriteLine("Projeto Teste");
                Console.WriteLine();
                Console.WriteLine("1-Listar produto");
                Console.WriteLine("2-Cadastrar produto");
                Console.WriteLine("9-Sair");
                Console.Write("Opção > ");
                op = Console.ReadLine();

                Console.Clear();
                switch (op)
                {
                    case "1":
                        ImprimirProdutos();
                        break;
                    case "2":
                        CadastrarProduto();
                        break;
                    case "9":
                        Console.WriteLine();
                        Console.WriteLine("Fim!");
                        return;
                }

                Console.WriteLine("---");
                Console.WriteLine("Tecle para continuar...");
                Console.ReadKey();
            }
        }

        private void CadastrarProduto()
        {
            Console.WriteLine("Cadastrando produto"); // Muito importando o "using" desta linha para executar o dispose ao final do uso deste método
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            
            using var scope = DI.ServiceProvider.CreateScope();
            var service = scope.ServiceProvider.GetService<IProdutoService>();
            var produto = new Produto {Nome = nome};
            service.Insert(produto);
            
            Console.WriteLine();
            Console.WriteLine($"Produto cadastrado - Id: {produto.Id} - Nome: {produto.Nome} - Data: {produto.DataCadastro}");
        }

        private void ImprimirProdutos()
        {
            Console.WriteLine("Produtos atuais");
            
            using var scope = DI.ServiceProvider.CreateScope(); // Muito importando o "using" desta linha para executar o dispose ao final do uso deste método
            var service = scope.ServiceProvider.GetService<IProdutoService>();
            var produtos = service.GetAll();
            
            if (produtos.IsNullOrEmpty())
                Console.WriteLine("Nenhum produto cadastrado.");
            else
                foreach (var p in produtos)
                    Console.WriteLine($"{p.Id} - {p.Nome} - {p.DataCadastro}");
        }
    }
}