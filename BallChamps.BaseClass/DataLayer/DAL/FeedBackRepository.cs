using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class FeedBackRepository : IFeedBackRepository, IDisposable
    {
        private FeedBackContext _context;
     
        public FeedBackRepository(FeedBackContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete FeedBack
        /// </summary>
        /// <param name="feedBackId"></param>
        public async Task DeleteFeedBack(string feedBackId)
        {
            FeedBack? feedBack = (from u in _context.FeedBack
                                 where u.FeedBackId == feedBackId
                                 select u).FirstOrDefault();

            _context.FeedBack.Remove(feedBack);
            Save();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get FeedBack By ID
        /// </summary>
        /// <param name="feedBackId"></param>
        /// <returns></returns>
        public async Task<FeedBack> GetFeedBackById(string feedBackId)
        {

            FeedBack feedBack = (from u in _context.FeedBack
                                 where u.FeedBackId == feedBackId
                         select u).FirstOrDefault();

            return feedBack;
        }

        /// <summary>
        /// Get FeedBacks
        /// </summary>
        /// <returns></returns>
        public async Task<List<FeedBack>> GetFeedBacks()
        {

            return await _context.FeedBack.ToListAsync();
        }

        /// <summary>
        /// Insert FeedBack
        /// </summary>
        /// <param name="feedBack"></param>
        public async Task InsertFeedBack(FeedBack feedBack)
        {
            feedBack.FeedBackId = Guid.NewGuid().ToString();

            _context.FeedBack.Add(feedBack);
            Save();
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update FeedBack
        /// </summary>
        /// <param name="feedBack"></param>
        public async Task UpdateFeedBack(FeedBack feedBack)
        {



            _context.Entry(feedBack).State = EntityState.Modified;
            Save();
        }
    
    }
}
