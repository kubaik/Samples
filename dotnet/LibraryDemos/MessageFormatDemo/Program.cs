using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using Jeffijoe.MessageFormat;
using Jeffijoe.MessageFormat.Formatting;
using Jeffijoe.MessageFormat.Formatting.Formatters;

namespace MessageFormatDemo
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
            var mf = new MessageFormatter();

            var str = @"You have {notifications, plural,
              zero {no notifications}
               one {one notification}
               =42 {a universal amount of notifications}
             other {# notifications}
            }. Have a nice day, {name}!";
            var formatted = mf.FormatMessage(str, new
            {
                notifications = 4,
                name = "Jeff"
            });
            Console.WriteLine(formatted);
            Console.WriteLine(MessageFormatter.Format(str, new {notifications = 15, name = "Fábio"}));

            //
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
                    Valor = 15.52m,
                    DocumentoCliente = "doc456",
                    Tipo = "Carga avulsa",
                    CodigoInterno = "5555"
                },
            };


            mf = new MessageFormatter();
            mf.Formatters.Add(new DateTimeFormatter());
            mf.Formatters.Add(new NumberFormatter());
            // mf.Locale = "pt-BR";
            foreach (var item in itens)
            {
                var line = mf.FormatMessage(
                    "{DataTransacao,DateTime,yyyy-MM-dd HH:mm:ss};{Valor,Number,N2};{DocumentoCliente};{Tipo};{CodigoInterno}",
                    item);

                Console.WriteLine($"Exemplo linha dinamica => {line}");
            }
        }
    }

    public class DateTimeFormatter : IFormatter
    {
        public bool CanFormat(FormatterRequest request) => request.FormatterName == "DateTime";

        public string Format(string locale, FormatterRequest request, IDictionary<string, object> args, object value,
            IMessageFormatter messageFormatter) =>
            ((DateTime) value).ToString(request.FormatterArguments, CultureInfo.GetCultureInfo(locale));
    }
    
    public class NumberFormatter : IFormatter
    {
        public bool CanFormat(FormatterRequest request) => request.FormatterName == "Number";

        public string Format(string locale, FormatterRequest request, IDictionary<string, object> args, object value,
            IMessageFormatter messageFormatter) =>
            Convert.ToDecimal(value).ToString(request.FormatterArguments, CultureInfo.GetCultureInfo(locale));
    }
}