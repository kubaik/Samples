using ProjetoTeste.Infrastructure;
using ProjetoTeste.Presentation;

namespace ProjetoTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            DI.Initialize();
            new MenuView().Start();
        }
    }
}