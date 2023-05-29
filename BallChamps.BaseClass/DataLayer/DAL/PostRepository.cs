using ApiClient;
using BallChamps.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataLayer.DAL
{
    public class PostRepository : IPostRepository, IDisposable
    {

        private PostContext _context;
        //private StorageAPI _storageAPI = new StorageAPI();

        public PostRepository(PostContext context)
        {
            this._context = context;
            
        }


        public async Task DeletePost(string postId)
        {
            Post post = (from u in _context.Post
                         where u.PostId == postId
                         select u).FirstOrDefault();

            _context.Post.Remove(post);

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
       
        public async Task<Post> GetPostById(string postId)
        {

            Post post =  (from u in _context.Post
                         where u.PostId == postId
                         select u).FirstOrDefault();

            return  post;
        }

        public async Task<List<Post>> GetPosts()
        {

            return await _context.Post.ToListAsync();
        }

        public async Task InsertPost(Post post)
        {
            post.PostId = Guid.NewGuid().ToString();

            _context.Post.Add(post);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
        }

        public async Task UpdatePostImage(string PostId)
        {
            throw new NotImplementedException();
        }
    }
}
