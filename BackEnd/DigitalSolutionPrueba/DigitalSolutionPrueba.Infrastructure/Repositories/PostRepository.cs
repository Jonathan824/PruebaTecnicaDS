using DigitalSolutionPrueba.Domain.Entities;
using DigitalSolutionPrueba.Domain.Interfaces;
using System.Collections.Generic;

namespace DigitalSolutionPrueba.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> _posts;

        public PostRepository()
        {
            _posts = new List<Post>();
        }

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public List<Post> GetAll()
        {
            return _posts;
        }
    }
}
