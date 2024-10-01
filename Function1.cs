using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureTableFunction
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function1))]
        public async Task Run([BlobTrigger("users/{name}", Connection = "DefaultEndpointsProtocol=https;AccountName=st10294145storage;AccountKey=x6Zdw9zyS9HMBCGE7LsBV0csrKG9Sszgtd6KBf6pB1LFrHhv1FnOfWXDRbS5hFafTpY7nSebvzSV+AStdSHR1A==;EndpointSuffix=core.windows.net")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
