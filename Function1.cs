using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureQueueMessageFunction
{
    public class ProcessTransactionQueueFunction
    {
        private readonly ILogger<ProcessTransactionQueueFunction> _logger;

        public ProcessTransactionQueueFunction(ILogger<ProcessTransactionQueueFunction> logger)
        {
            _logger = logger;
        }

        [Function(nameof(ProcessTransactionQueueFunction))]
        public void Run(
            [QueueTrigger("transaction-queue", Connection = "AzureWebJobsStorage")] QueueMessage message)
        {
            _logger.LogInformation($"Queue trigger function processed: {message.MessageText}");

            // You can add your business logic here to process the message
        }
    }
}
