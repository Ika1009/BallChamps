using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface INewsFeedRepository : IDisposable
    {
        Task<List<NewsFeed>> GetNewsFeeds();
        Task<NewsFeed> GetNewsFeedById(string newsFeedId);
        Task InsertNewsFeed(NewsFeed NewsFeed);
        Task DeleteNewsFeed(string newsFeedId);
        Task UpdateNewsFeed(NewsFeed newsFeed);
        Task<bool> ExistInNewFeed(string id, string ObjectType);        
        Task<int> Save();
    }
}
