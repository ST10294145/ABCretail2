using Azure;
using Azure.Data.Tables;
using ABCretail2.Models;

namespace ABCretail2.Services
{
    public class TableStorageService
    {
        private readonly TableClient _productTableClient;

        public TableStorageService(string connectionString)
        {
            _productTableClient = new TableClient(connectionString, "Products");
        }

        // Product-related operations
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = new List<Product>();
            await foreach (var product in _productTableClient.QueryAsync<Product>())
            {
                products.Add(product);
            }
            return products;
        }

        public async Task AddProductAsync(Product product)
        {
            if (string.IsNullOrEmpty(product.PartitionKey) || string.IsNullOrEmpty(product.RowKey))
            {
                throw new ArgumentException("PartitionKey and RowKey must be set.");
            }

            try
            {
                await _productTableClient.AddEntityAsync(product);
            }
            catch (RequestFailedException ex)
            {
                throw new InvalidOperationException("Error adding product to Table Storage", ex);
            }
        }

        public async Task DeleteProductAsync(string partitionKey, string rowKey)
        {
            await _productTableClient.DeleteEntityAsync(partitionKey, rowKey);
        }

        public async Task<Product?> GetProductAsync(string partitionKey, string rowKey)
        {
            try
            {
                var response = await _productTableClient.GetEntityAsync<Product>(partitionKey, rowKey);
                return response.Value;
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return null;
            }
        }
    }
}
