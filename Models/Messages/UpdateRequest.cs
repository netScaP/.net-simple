using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

namespace WebApi.Models.Messages
{
    public class UpdateRequest
    {
        public string Title { get; set; }
    }
}