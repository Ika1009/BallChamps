using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IBlogRepository : IDisposable
    {
        Task<List<Blog>> GetBlogs();
        Task<Blog> GetBlogById(string blogId);
        Task InsertBlog(Blog blog);
        Task DeleteBlog(string blogId);
        Task UpdateBlog(Blog blog);
        Task<int> Save();
    }
}
