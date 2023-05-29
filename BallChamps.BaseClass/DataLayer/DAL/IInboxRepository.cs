using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IInboxRepository : IDisposable
    {      
        Task<List<Inbox>> GetInboxByUserProfileId(string userProfileId);
        Task InsertInbox(Inbox inbox);
        Task DeleteInbox(string inboxId);
        Task<Inbox> GetInboxById(string inboxId);
        Task UpdateInbox(Inbox inbox);       
        Task<int> Save();

    }
}
