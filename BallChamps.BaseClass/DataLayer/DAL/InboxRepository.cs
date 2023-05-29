using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class InboxRepository : IInboxRepository, IDisposable
    {
        private InboxContext _context;
        public InboxRepository(InboxContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete Inbox
        /// </summary>
        /// <param name="blogId"></param>
        public async Task DeleteInbox(string inboxId)
        {
            Inbox inbox = (from u in _context.Inbox
                          where u.InboxId == inboxId
                           select u).FirstOrDefault();

            _context.Inbox.Remove(inbox);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Inbox By UserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        public async Task<List<Inbox>> GetInboxByUserProfileId(string userProfileId)
        {

            List<Inbox> inbox = (from u in _context.Inbox
                         where u.UserProfileId == userProfileId
                                 select u).ToList();

            return inbox;
        }

        /// <summary>
        /// Get Inbox By Id
        /// </summary>
        /// <param name="inboxId"></param>
        /// <returns></returns>
        public async Task<Inbox> GetInboxById(string inboxId)
        {

            Inbox inbox = (from u in _context.Inbox
                           where u.InboxId == inboxId
                           select u).FirstOrDefault();


            return inbox;
        }


        /// <summary>
        /// Insert Inbox
        /// </summary>
        /// <param name="blog"></param>
        public async Task InsertInbox(Inbox inbox)
        {
            inbox.InboxId = Guid.NewGuid().ToString();

            _context.Inbox.Add(inbox);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Inbox
        /// </summary>
        /// <param name="inbox"></param>
        public async Task UpdateInbox(Inbox inbox)
        {
            _context.Entry(inbox).State = EntityState.Modified;
            Save();
        }

       
    }
}
