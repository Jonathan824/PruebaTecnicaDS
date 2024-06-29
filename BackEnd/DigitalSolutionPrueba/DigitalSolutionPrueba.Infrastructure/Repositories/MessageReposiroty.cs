using DigitalSolutionPrueba.Domain.Entities;
using DigitalSolutionPrueba.Domain.Interfaces;

namespace DigitalSolutionPrueba.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly List<Message> _messages = new List<Message>();

        public List<Message> GetMessagesForDashboard(string username)
        {
            return _messages.Where(m => m.Username == username).ToList();
        }

        public void SaveMessage(Message message)
        {
            _messages.Add(message);
        }
    }
}

