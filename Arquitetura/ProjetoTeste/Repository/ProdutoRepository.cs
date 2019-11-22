using ProjetoTeste.Context;
using ProjetoTeste.Entitiy;

namespace ProjetoTeste.Repository
{
    public class ProdutoRepository : RepositoryBase<Produto>
    {
        public ProdutoRepository(TesteContext context) : base(context)
        {
        }
    }
}