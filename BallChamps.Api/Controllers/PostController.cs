using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Post Controller
    /// </summary>
    [Route("api/[controller]")]
    public class PostController : Controller
    {

        private IPostRepository postRepository;

        /// <summary>
        /// Post Controller Constructor
        /// </summary>
        /// <param name="postContext"></param>
        public PostController(PostContext postContext)
        {

            this.postRepository = new PostRepository(postContext);

        }

        /// <summary>
        /// Get All Posts
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPosts")]
        public async  Task<List<Post>> GetPosts()
        {
            try
            {
                return await postRepository.GetPosts();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }


        /// <summary>
        /// Get Post By Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        // [Authorize]
        [HttpGet("GetPostById")]
        public async Task<Post> GetPostById(string postId)
        {

            try
            {
                return await postRepository.GetPostById(postId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return null;
        }

        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="postId"></param>
        [HttpPost("DeletePost")]
        public void DeleteBlog(string postId)
        {
            try
            {
                postRepository.DeletePost(postId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }

        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="post"></param>
        [Authorize]
        [HttpPost("CreatePost")]
        public void CreateBlog([FromBody] Post post)
        {
            try
            {
                postRepository.InsertPost(post);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }

        /// <summary>
        /// Update Post Info
        /// </summary>
        /// <param name="post"></param>
        [Authorize]
        [HttpPost("UpdatePost")]
        public void UpdateBlog([FromBody] Post post)
        {
            try
            {
                postRepository.UpdatePost(post);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }
    }
}
