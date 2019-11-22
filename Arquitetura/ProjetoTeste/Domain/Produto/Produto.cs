using System;
using ProjetoTeste.Domain.Base;

namespace ProjetoTeste.Domain.Produto
{
    public class Produto : EntityBase
    {
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}