using System;
using System.Threading.Tasks;
using Camunda.Api.Client;
using Camunda.Api.Client.ProcessDefinition;

namespace ApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Camunda API Rest Client");
            StartInstance().Wait();
        }

        private static async Task StartInstance()
        {
            CamundaClient camunda = CamundaClient.Create("http://localhost:8080/engine-rest");
            var process = await camunda.ProcessInstances.Query().List();
            foreach (var p in process)
            {
                Console.WriteLine($"{p.Id}-{p.DefinitionId}");
            }
        }
    }
}