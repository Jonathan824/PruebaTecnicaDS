using DigitalSolutionPrueba.Application.Interfaces;
using DigitalSolutionPrueba.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DigitalSolutionPrueba.Application.Services
{
    public class MessageService : IMessageService
    {
        public IEnumerable<Message> GetMessagesForDashboard(string username)
        {
            var messages = new List<Message>
            {
                new Message { Id = 1, Content = "Hoy puede ser un gran dia", Username = "Ivan", Timestamp = new DateTime(2024, 6, 28, 8, 10, 0) },
                new Message { Id = 2, Content = "Hola mundo", Username = "Alfonso", Timestamp = new DateTime(2024, 6, 28, 10, 30, 0) },
                new Message { Id = 3, Content = "Para casa ya, media jornada, 12h", Username = "Ivan", Timestamp = new DateTime(2024, 6, 28, 20, 10, 0) },
                new Message { Id = 4, Content = "Adiós mundo cruel", Username = "Alfonso", Timestamp = new DateTime(2024, 6, 28, 20, 30, 0) }
            };

            return messages;
        }
    }
}
