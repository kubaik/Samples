using ProjetoTeste.Entitiy;
using ProjetoTeste.Repository;

namespace ProjetoTeste.Service
{
    public class ProdutoService : ServiceBase<IRepositoryBase<Produto>, Produto>
    {
        public ProdutoService(IRepositoryBase<Produto> repository) : base(repository)
        {
        }
    }
}