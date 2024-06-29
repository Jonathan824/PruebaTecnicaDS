using System.Collections.Generic;

namespace DigitalSolutionPrueba.Domain.Entities
{    
    public class User
    {
        public string UserName { get; set; }
        public List<string> Timeline { get; set; } = new List<string>();
        public List<User> Following { get; set; } = new List<User>();
        public int Id { get; set; }
        public List<User> FollowedUsers { get; set; } = new List<User>();
    }
}
