using System;
using StringFormat;

namespace StringFormatDemo
{
    public class ConciliacaoItem
    {
        public DateTime DataTransacao { get; set; }
        public decimal Valor { get; set; }
        public string DocumentoCliente { get; set; }
        public string Tipo { get; set; }
        public string CodigoInterno { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var itens = new[]
            {
                new ConciliacaoItem
                {
                    DataTransacao = DateTime.Now,
                    Valor = 10,
                    DocumentoCliente = "doc123",
                    Tipo = "Carga avulsa",
                    CodigoInterno = "5555"
                },
                new ConciliacaoItem
                {
                    DataTransacao = DateTime.Now.AddMinutes(5),
                    Valor = 15.5m,
                    DocumentoCliente = "doc456",
                    Tipo = "Carga avulsa",
                    CodigoInterno = "5555"
                },
            };


            foreach (var item in itens)
            {
                Console.WriteLine(TokenStringFormat.Format(
                    "Exemplo linha dinamica => {DataTransacao:yyyy-MM-dd HH:mm:ss};{Valor:N2};{DocumentoCliente};{Tipo};{CodigoInterno}",
                    item));
            }
        }
    }
}