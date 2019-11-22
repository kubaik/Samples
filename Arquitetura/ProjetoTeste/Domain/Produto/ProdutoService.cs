using ProjetoTeste.Domain.Base;

namespace ProjetoTeste.Domain.Produto
{
    public class ProdutoService : ServiceBase<IProdutoRepository, Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }
    }
}