using System.Collections.Generic;
using ProjetoTeste.Domain.Base;

namespace ProjetoTeste.Domain.Produto
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> Filtrar(string nome);
    }
}