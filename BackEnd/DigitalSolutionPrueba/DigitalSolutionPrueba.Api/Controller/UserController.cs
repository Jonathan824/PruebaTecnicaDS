using Microsoft.AspNetCore.Mvc;
using DigitalSolutionPrueba.Application.Interfaces;
using DigitalSolutionPrueba.Application.Services;

namespace DigitalSolutionPrueba.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IMessageService _messageService;

        public UserController(IUserService userService, IPostService postService, IMessageService messageService)
        {
            _userService = userService;
            _postService = postService;
            _messageService = messageService;
        }

        [HttpPost("post")]
        public IActionResult PostMessage([FromQuery] string username, [FromQuery] string message)
        {
            var user = _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound($"User @{username} not found.");
            }
            var post = _postService.CreatePost(user, message);
            return Ok(new
            {
                message = $"{user.UserName} posted -> \"{post.Message}\" @{post.Timestamp:HH:mm}"
            });
        }

        [HttpPost("follow")]
        public IActionResult FollowUser([FromQuery] string followerUsername, [FromQuery] string followeeUsername)
        {
            var follower = _userService.GetUserByUsername(followerUsername);
            var followee = _userService.GetUserByUsername(followeeUsername);

            if (follower == null || followee == null)
            {
                return NotFound(new { message = "One or both users not found." });
            }

            if (_userService.FollowUser(follower, followee))
            {
                return Ok(new { message = $"{follower.UserName} started following {followee.UserName}" });
            }
            else
            {
                return BadRequest(new { message = $"{follower.UserName} is already following {followee.UserName}" });
            }
        }

        [HttpGet("followed")]
        public IActionResult GetFollowedUsers([FromQuery] string username)
        {
            var followedUsers = _userService.GetFollowedUsers(username);
            if (followedUsers == null)
            {
                return NotFound($"No se encontraron usuarios seguidos para el usuario @{username}");
            }
            return Ok(followedUsers);
        }

        [HttpGet("dashboard/{username}")]
        public IActionResult ShowDashboard(string username)
        {
            var user = _userService.GetUserByUsername(username);
            if (user == null)
            {
                return NotFound($"User @{username} not found.");
            }
            var dashboard = _postService.GetDashboard(user);
            var result = dashboard.Select(post => new
            {
                Message = post.Message,
                Author = post.Author.UserName,
                Timestamp = post.Timestamp.ToString("HH:mm")
            });
            return Ok(result);
        }

        [HttpGet("messages/{username}")]
        public IActionResult GetMessagesForDashboard(string username)
        {
            try
            {
                var messages = _messageService.GetMessagesForDashboard(username);
                return Ok(messages);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users.Select(u => u.UserName));
        }
    }
}
