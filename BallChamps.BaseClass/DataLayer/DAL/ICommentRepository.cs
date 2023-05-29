using BallChamps.Domain;
using DataLayer.DTO;

namespace DataLayer.DAL
{
    public interface ICommentRepository : IDisposable
    {
        Task<Comment> GetCommentById(string commentRateId);
        Task CommentPlayerUpdate(Comment commentRate);
        Task DeleteComment(string commentRateId);
        Task UpdateComment(Comment commentRate);
        Task<List<CommentDTO>> GetCommentByUserProfileId(string userProfileId, string connStr);
        Task<int> Save();

    }
}
