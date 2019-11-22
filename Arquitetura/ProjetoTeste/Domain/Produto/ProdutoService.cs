using System.Collections.Generic;
using System.Linq;
using ProjetoTeste.Domain.Base;

namespace ProjetoTeste.Domain.Produto
{
    public class ProdutoService : ServiceBase<IProdutoRepository, Produto>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }

        public IEnumerable<Produto> Filtrar(string nome) => Repository.Query()
            .Where(p => p.Nome.ToUpper().Contains(nome.ToUpper()))
            .ToList();
    }
}