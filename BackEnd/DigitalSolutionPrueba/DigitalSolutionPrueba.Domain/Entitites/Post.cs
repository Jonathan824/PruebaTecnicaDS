using System;

namespace DigitalSolutionPrueba.Domain.Entities
{
    public class Post
    {
        public User Author { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
