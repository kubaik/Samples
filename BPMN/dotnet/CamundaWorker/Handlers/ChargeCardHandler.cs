using System;
using System.Threading.Tasks;
using Camunda.Worker;

namespace CamundaWorker.Handlers
{

    [HandlerTopics("charge-card")]
    public class ChargeCardHandler : ExternalTaskHandler
    {
        public override async Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            var item = externalTask.Variables["item"].AsString();
            var amount = externalTask.Variables["amount"].AsLong();
            if (amount > 1100)
                throw new Exception("Meu teste de erro");
//                return new FailureResult("Falha no processo", "Detalhes da falha");
            Console.WriteLine($"Charging credit card with an amount of '{amount}'€ for the item '{item}'...");
            return new CompleteResult();
        }
    }
}