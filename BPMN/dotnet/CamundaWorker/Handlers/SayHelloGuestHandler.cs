using System.Collections.Generic;
using System.Threading.Tasks;
using Camunda.Worker;

namespace CamundaWorker.Handlers
{
    [HandlerTopics("sayHelloGuest")]
    public class SayHelloGuestHandler : ExternalTaskHandler
    {
        public override Task<IExecutionResult> Process(ExternalTask externalTask)
        {
            var result = new CompleteResult();
            result.Variables.Add("MESSAGE", Variable.String("Hello, Guest!"));

            return Task.FromResult<IExecutionResult>(result);
        }
    }
}