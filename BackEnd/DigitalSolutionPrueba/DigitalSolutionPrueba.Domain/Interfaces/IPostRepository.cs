using DigitalSolutionPrueba.Domain.Entities;
using System.Collections.Generic;

namespace DigitalSolutionPrueba.Domain.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        List<Post> GetAll();
    }
}
