using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Messages;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private IMessageService _MessageService;
        private IMapper _mapper;

        public MessagesController(
            IMessageService MessageService,
            IMapper mapper)
        {
            _MessageService = MessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Messages = _MessageService.GetAll();
            return Ok(Messages);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Message = _MessageService.GetById(id);
            return Ok(Message);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _MessageService.Create(model);
            return Ok(new { message = "Message created" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _MessageService.Update(id, model);
            return Ok(new { message = "Message updated" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _MessageService.Delete(id);
            return Ok(new { message = "Message deleted" });
        }
    }
}
