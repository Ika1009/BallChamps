using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using DataLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Comment Rate Controller
    /// </summary>
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        private ICommentRepository commentRepository;

        /// <summary>
        /// Comment Rate Controller
        /// </summary>
        /// <param name="commentContext"></param>
        public CommentController(CommentContext commentContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.commentRepository = new CommentRepository(commentContext, configuration);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }

        ///// <summary>
        ///// Comment Rates
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet("GetComments")]
        //public async Task<List<Comment>> GetComments()
        //{
        //    return await commentRepository.GetComments();
        //}

        /// <summary>
        /// Get Comment Rate By Id
        /// </summary>
        /// <param name="commentRateId"></param>
        /// <returns></returns>
        // [Authorize]
        [HttpGet("GetCommentById")]
        public async Task<Comment> GetCommentById(string commentId)
        {

            try
            {
                return await commentRepository.GetCommentById(commentId);
            }
            catch
            {
                return null;
            }


        }

        /// <summary>
        /// GetCourtWaitingList By CourtId
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpGet("GetCommentByUserProfileId")]
        //[Authorize]
        public async Task<List<CommentDTO>> GetCommentByUserProfileId(string userProfileId)
        {
            try
            {
                return await commentRepository.GetCommentByUserProfileId(userProfileId, ballchampsConnectionString);
            }
            catch (Exception ex)
            {
               
            }
            return null;

        }

       

        /// <summary>
        /// Create CommentRate
        /// </summary>
        /// <param name="commentRate"></param>
        
        [HttpPost("CommentPlayerUpdate")]
        public void CommentPlayerUpdate([FromBody] Comment comment)
        {

            try
            {

                commentRepository.CommentPlayerUpdate(comment);

            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }


        /// <summary>
        /// Update CommentRate
        /// </summary>
        /// <param name="commentRate"></param>
        [Authorize]
        [HttpPost("UpdateComment")]
        public void UpdateComment([FromBody] Comment comment)
        {
            commentRepository.UpdateComment(comment);

        }
    }
}
