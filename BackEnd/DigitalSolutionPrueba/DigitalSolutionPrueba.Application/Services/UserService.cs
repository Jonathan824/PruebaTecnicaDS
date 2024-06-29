using DigitalSolutionPrueba.Application.Interfaces;
using DigitalSolutionPrueba.Domain.Entities;
using DigitalSolutionPrueba.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DigitalSolutionPrueba.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.GetUserByUsername(username);
        }

        public void AddUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public bool FollowUser(User follower, User followee)
        {
            if (follower.Following.Any(u => u.UserName == followee.UserName))
            {
                return false;
            }

            follower.Following.Add(followee);
            return true;
        }

        public List<User> GetFollowedUsers(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return null;
            }

            var followingUsersWithDetails = new List<User>();
            foreach (var followedUser in user.Following)
            {
                var followedUserDTO = new User
                {
                    UserName = followedUser.UserName
                };

                followingUsersWithDetails.Add(followedUserDTO);
            }
            var userDTO = new User
            {
                UserName = user.UserName,
                FollowedUsers = followingUsersWithDetails
            };
            return new List<User> { userDTO };
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
