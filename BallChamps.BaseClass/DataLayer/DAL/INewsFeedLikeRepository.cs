using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface INewsFeedLikeRepository : IDisposable
    {
        Task<List<NewsFeedLike>> GetNewsFeedLikes();
        Task<NewsFeedLike> GetNewsFeedLikeById(string newsFeedLikeId);
        Task InsertNewsFeedLike(NewsFeedLike newsFeedLike);
        Task DeleteNewsFeedLike(string newsFeedLikeId);
        Task UpdateNewsFeedLike(NewsFeedLike newsFeedLike);
        Task UpdateNewsFeedLikeImage(string newsFeedLikeId);
        Task<int> Save();
    }
}
