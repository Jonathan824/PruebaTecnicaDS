using DigitalSolutionPrueba.Domain.Entities;
using System.Collections.Generic;

namespace DigitalSolutionPrueba.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
    }
}
