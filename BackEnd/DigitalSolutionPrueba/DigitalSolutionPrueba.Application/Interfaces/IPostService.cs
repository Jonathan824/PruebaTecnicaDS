using DigitalSolutionPrueba.Domain.Entities;
using System.Collections.Generic;

namespace DigitalSolutionPrueba.Application.Interfaces
{
    public interface IPostService
    {   
        Post CreatePost(User user, string message);
        List<Post> GetDashboard(User user);
    }
}
