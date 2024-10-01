using Azure;
using Azure.Data.Tables;

namespace ABCretail2.Models
{
    public class Product : ITableEntity
    {
        // Product properties
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // ITableEntity properties
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public Product()
        {
            // Assign RowKey and PartitionKey based on the product's Id
            PartitionKey = "Products";
            RowKey = Id.ToString(); // Convert Id (int) to string
        }
    }
}
