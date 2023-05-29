using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallChampsApi.Controllers
{
    
    /// <summary>
    /// Blog Controller
    /// </summary>
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        private IBlogRepository blogRepository;
        /// <summary>
        /// Blog Controller Constructor
        /// </summary>
        /// <param name="blogContext"></param>
        public BlogController(BlogContext blogContext)
        {
            this.blogRepository = new BlogRepository(blogContext);
        }

        /// <summary>
        /// Get All Blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetBlogs")]
        public async  Task<List<Blog>> GetBlogs()
        {
            try
            {
                return await blogRepository.GetBlogs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetBlogById")]
        //[Authorize]
        public async Task<Blog> GetBlogById(string blogId)
        {

            try
            {
                return await blogRepository.GetBlogById(blogId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("DeleteBlog")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeleteBlog(string blogId)
        {

            try
            {
                await blogRepository.DeleteBlog(blogId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeleteBlog");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Create new Blog
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("CreateBlog")]
        public void CreateBlog([FromBody] Blog blog)
        {
            try
            {

                blogRepository.InsertBlog(blog);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update Blog Info
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("UpdateBlog")]
        public void UpdateBlog([FromBody] Blog blog)
        {
            try
            {
                blogRepository.UpdateBlog(blog);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
