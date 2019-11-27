using System;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Topics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Topic sample!");
            
            // Message struct: <Tipo>.<Provider[]>

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.ExchangeDelete("Notificacao");
            channel.QueueDelete("Notificacao.AlertarEquipeSustencacao");
            channel.QueueDelete("Notificacao.EnviarEmail");
            channel.QueueDelete("Notificacao.EnviarSms");
            channel.QueueDelete("Notificacao:ArmazenarDb");
            
            channel.ExchangeDeclare("Notificacao", "topic");
            channel.QueueDeclare("Notificacao.AlertarEquipeSustencacao", exclusive: false);
            channel.QueueDeclare("Notificacao.EnviarEmail", exclusive: false);
            channel.QueueDeclare("Notificacao.EnviarSms", exclusive: false);
            channel.QueueDeclare("Notificacao:ArmazenarDb", exclusive: false);
            
            channel.QueueBind("Notificacao.AlertarEquipeSustencacao", "Notificacao", "Erro.#");
            channel.QueueBind("Notificacao.EnviarEmail", "Notificacao", "#.Email.#");
            channel.QueueBind("Notificacao.EnviarSms", "Notificacao", "#.Sms.#");
            channel.QueueBind("Notificacao:ArmazenarDb", "Notificacao", "#");
            
            //
            Console.WriteLine("Publish messages");
            channel.BasicPublish("Notificacao", "Info.None", body: Encoding.UTF8.GetBytes("Apenas armazenar"));
            channel.BasicPublish("Notificacao", "Erro.None", body: Encoding.UTF8.GetBytes("Apenas alertar equipe sustentação"));
            channel.BasicPublish("Notificacao", "Info.Email", body: Encoding.UTF8.GetBytes("Informação por e-mail"));
            channel.BasicPublish("Notificacao", "Info.Sms", body: Encoding.UTF8.GetBytes("Informação por sms"));
            channel.BasicPublish("Notificacao", "Erro.Email", body: Encoding.UTF8.GetBytes("Erro por email"));
            channel.BasicPublish("Notificacao", "Erro.Email.Sms", body: Encoding.UTF8.GetBytes("Erro por email e SMS"));
            channel.BasicPublish("Notificacao", "Erro.Sms.Email", body: Encoding.UTF8.GetBytes("Erro por SMS e e-mail"));

            Console.Write("Finished!");
        }
    }
}