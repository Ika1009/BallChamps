using BallChamps.Domain;
using Common;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.DAL
{
    public class BlogRepository : IBlogRepository, IDisposable
    {
        private BlogContext _context;

        /// <summary>
        /// Blog Repository
        /// </summary>
        /// <param name="context"></param>
        public BlogRepository(BlogContext context)
        {
            this._context = context;
            
        }
       
        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Blog> GetBlogById(string Id)
        {

            Blog model = (from u in _context.Blog
                             where u.BlogId == Id
                             select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get All Blogs List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Blog>> GetBlogs()
        {
            return await _context.Blog.ToListAsync();
        }

        /// <summary>
        /// Insert New Blog
        /// </summary>
        /// <param name="model"></param>
        public async Task InsertBlog(Blog model)
        {
            model.BlogId = Guid.NewGuid().ToString();
            model.BlogNumber = Functions.GenerateSixDigit();

            _context.Blog.Add(model);
            Save();
        }

        /// <summary>
        /// Update Blog Info
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateBlog(Blog model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="Id"></param>
        public async Task DeleteBlog(string Id)
        {
            Blog model = (from u in _context.Blog
                         where u.BlogId == Id
                         select u).FirstOrDefault();

            _context.Blog.Remove(model);
            Save();

        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
