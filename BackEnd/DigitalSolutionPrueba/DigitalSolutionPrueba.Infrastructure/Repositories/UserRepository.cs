using DigitalSolutionPrueba.Domain.Entities;
using DigitalSolutionPrueba.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DigitalSolutionPrueba.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
            InitializeUsers(); // Método para inicializar usuarios (opcional, depende de tu implementación)
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.UserName == username);
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        private void InitializeUsers()
        {
            _users.AddRange(new List<User>
            {
                new User { UserName = "Alfonso" },
                new User { UserName = "Ivan" },
                new User { UserName = "Alicia" }
            });
        }
    }
}
