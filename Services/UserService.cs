using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Messages;

namespace WebApi.Services
{
    public interface IMessageService
    {
        IEnumerable<Message> GetAll();
        Message GetById(int id);
        void Create(CreateRequest model);
        void Update(int id, UpdateRequest model);
        void Delete(int id);
    }

    public class MessageService : IMessageService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public MessageService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages;
        }

        public Message GetById(int id)
        {
            return getMessage(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Messages.Any(x => x.Title == model.Title))
                throw new AppException("Message '" + model.Title + "' already exists");

            // map model to new Message object
            var Message = _mapper.Map<Message>(model);

            // save Message
            _context.Messages.Add(Message);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var Message = getMessage(id);

            // copy model to Message and save
            _mapper.Map(model, Message);
            _context.Messages.Update(Message);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var Message = getMessage(id);
            _context.Messages.Remove(Message);
            _context.SaveChanges();
        }

        // helper methods

        private Message getMessage(int id)
        {
            var Message = _context.Messages.Find(id);
            if (Message == null) throw new KeyNotFoundException("Message not found");
            return Message;
        }
    }
}