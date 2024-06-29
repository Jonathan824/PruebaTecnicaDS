using DigitalSolutionPrueba.Application.Interfaces;
using DigitalSolutionPrueba.Domain.Entities;
using DigitalSolutionPrueba.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalSolutionPrueba.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post CreatePost(User user, string message)
        {
            var post = new Post
            {
                Author = user,
                Message = message,
                Timestamp = DateTime.Now
            };
            _postRepository.Add(post);
            return post;
        }

        public List<Post> GetDashboard(User user)
        {
            return _postRepository.GetAll()
                .Where(p => user.Following.Contains(p.Author))
                .OrderBy(p => p.Timestamp)
                .ToList();
        }
    }
}
