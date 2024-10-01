using Azure.Data.Tables;
using Azure;
using System.ComponentModel.DataAnnotations;

namespace ABCretail2.Models
{
    public class UserModel : ITableEntity
    {
        [Key]
        public int User_Id { get; set; }  // Ensure this property exists and is populated
        public string? User_Name { get; set; }  // Ensure this property exists and is populated
        public string? email { get; set; }
        public string? password { get; set; }

        // ITableEntity implementation
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
