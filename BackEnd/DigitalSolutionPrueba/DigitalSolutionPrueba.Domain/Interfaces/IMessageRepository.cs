
using DigitalSolutionPrueba.Domain.Entities;

namespace DigitalSolutionPrueba.Domain.Interfaces
{
    public interface IMessageRepository
    {
        List<Message> GetMessagesForDashboard(string username);
    }
}
