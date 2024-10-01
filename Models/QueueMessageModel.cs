using System.ComponentModel.DataAnnotations;

namespace ABCretail2.Models
{
    public class QueueMessageModel
    {
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}
