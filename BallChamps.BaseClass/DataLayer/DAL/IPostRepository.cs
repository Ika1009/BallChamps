using BallChamps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IPostRepository : IDisposable
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(string postId);
        Task InsertPost(Post post);
        Task DeletePost(string postId);
        Task UpdatePost(Post post);
        Task UpdatePostImage(string postId);
        Task<int> Save();

    }
}
