using DigitalSolutionPrueba.Domain.Entities;
using System.Collections.Generic;

namespace DigitalSolutionPrueba.Application.Interfaces
{
    public interface IUserService
    {
        User GetUserByUsername(string username);
        void AddUser(User user);
        bool FollowUser(User follower, User followee);
        IEnumerable<User> GetAllUsers();
        List<User> GetFollowedUsers(string username);
    }
}
