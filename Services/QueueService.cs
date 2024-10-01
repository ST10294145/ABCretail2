using Azure.Storage.Queues;
using System.Threading.Tasks;

namespace ABCretail2.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(string connectionString, string queueName)
        {
            _queueClient = new QueueClient(connectionString, queueName);
        }

        public async Task SendMessageAsync(string message)
        {
            await _queueClient.SendMessageAsync(message);
        }
    }
}
