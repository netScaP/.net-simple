using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Messages
{
    public class CreateRequest
    {
        [Required]
        public string Title { get; set; }
    }
}