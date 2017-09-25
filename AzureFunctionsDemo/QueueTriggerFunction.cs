using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsDemo
{
    public static class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
