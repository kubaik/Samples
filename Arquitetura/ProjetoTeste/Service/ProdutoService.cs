using ProjetoTeste.Entitiy;
using ProjetoTeste.Repository;

namespace ProjetoTeste.Service
{
    public class ProdutoService : ServiceBase<IProdutoRepository, Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }
    }
}