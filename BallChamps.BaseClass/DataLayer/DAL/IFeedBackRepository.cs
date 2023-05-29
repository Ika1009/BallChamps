using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IFeedBackRepository : IDisposable
    {
        Task<List<FeedBack>> GetFeedBacks();
        Task<FeedBack> GetFeedBackById(string feedBackId);
        Task InsertFeedBack(FeedBack feedBack);
        Task DeleteFeedBack(string feedBackId);
        Task UpdateFeedBack(FeedBack feedBack);        
        Task<int> Save();
    }
}
