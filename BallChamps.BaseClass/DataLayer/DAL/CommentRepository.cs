using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    public class CommentRepository : ICommentRepository, IDisposable
    {
        public IConfiguration Configuration { get; }
        private CommentContext _context;
        string UserProfileDefaultImagePath;

        /// <summary>
        /// Comment Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public CommentRepository(CommentContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;
            this.UserProfileDefaultImagePath = Configuration.GetSection("ResourcesPath:UserProfileDefaultImagePath").Value;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Comment Rate By Id
        /// </summary>
        /// <param name="commentRateId"></param>
        /// <returns></returns>
        public async Task<Comment> GetCommentById(string commentRateId)
        {

            Comment commentRate = (from u in _context.Comment
                                       where u.CommentId == commentRateId
                                       select u).FirstOrDefault();

            return commentRate;
        }

        /// <summary>
        /// Get Comment By UserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<CommentDTO>> GetCommentByUserProfileId(string userProfileId,string connStr)
        {

            List<CommentDTO> commentDTOTempList = new List<CommentDTO>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetCommentByUserProfileId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@userProfileId", userProfileId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                CommentDTO commentDTOTemp = new CommentDTO();
                                //User Table
                                commentDTOTemp.CommentId = dr["CommentId"].ToString();
                                commentDTOTemp.QuickComment = dr["QuickComment"].ToString();
                                commentDTOTemp.Message = dr["Message"].ToString();
                                commentDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                commentDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                commentDTOTemp.UserName = dr["UserName"].ToString();
                                commentDTOTemp.CommentedByUserProfileId = dr["CommentedByUserProfileId"].ToString();
                                commentDTOTemp.CommentDate = (DateTime)dr["CommentDate"];
                                commentDTOTemp.HasImage = (bool)dr["HasImage"];

                                commentDTOTempList.Add(commentDTOTemp);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }

                foreach (var item in commentDTOTempList)
                {

                   

                    if (item.HasImage == false)
                    {
                        item.ImagePath = UserProfileDefaultImagePath;
                    }


                }

                return commentDTOTempList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Create new comment
        /// </summary>
        /// <param name="commentRate"></param>
        public async Task CommentPlayerUpdate(Comment commentRate)
        {
            try
            {
                bool hasCommented = (from u in _context.Comment
                                     where u.UserProfileId == commentRate.UserProfileId && u.CommentedByUserProfileId == commentRate.CommentedByUserProfileId
                                     select u).Any();

                if (hasCommented)
                {

                    Comment _commentRate = (from u in _context.Comment
                                               where u.UserProfileId == commentRate.UserProfileId && u.CommentedByUserProfileId == commentRate.CommentedByUserProfileId
                                               select u).FirstOrDefault();

                    _commentRate.StarRating = commentRate.StarRating;
                    _commentRate.Message = commentRate.Message;
                    _commentRate.QuickComment = commentRate.QuickComment;


                    _context.Entry(_commentRate).State = EntityState.Modified;
                    Save();
                }
                else
                {
                    commentRate.CommentId = Guid.NewGuid().ToString();

                    _context.Comment.Add(commentRate);
                    Save();
                }
            }

            catch(Exception ex)
            {

            }

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
        /// Update Comment Rate
        /// </summary>
        /// <param name="commentRate"></param>
        public async Task UpdateComment(Comment commentRate)
        {
            _context.Entry(commentRate).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete CommentRate
        /// </summary>
        /// <param name="commentRateId"></param>
        public async Task DeleteComment(string commentRateId)
        {
            Comment commentRate = (from u in _context.Comment
                                   where u.CommentId == commentRateId
                                   select u).FirstOrDefault();

            _context.Comment.Remove(commentRate);

        }

    }
}
