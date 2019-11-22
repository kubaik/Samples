using ProjetoTeste.Domain.Base;
using ProjetoTeste.Infrastructure.Context;

namespace ProjetoTeste.Domain.Produto
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(TesteContext context) : base(context)
        {
        }
    }
}