using DigitalSolutionPrueba.Domain.Entities;

namespace DigitalSolutionPrueba.Application.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetMessagesForDashboard(string username);
    }
}
