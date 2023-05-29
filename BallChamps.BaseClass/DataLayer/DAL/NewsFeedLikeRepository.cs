using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;



namespace DataLayer.DAL
{
    public class NewsFeedLikeRepository : INewsFeedLikeRepository, IDisposable
    {
        private NewsFeedLikeContext _context;

        public NewsFeedLikeRepository(NewsFeedLikeContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete News Feed Like
        /// </summary>
        /// <param name="newsFeedLikeId"></param>
        public async Task DeleteNewsFeedLike(string newsFeedLikeId)
        {
            NewsFeedLike model = (from u in _context.NewsFeedLike
                                 where u.NewsFeedLikeId == newsFeedLikeId
                                 select u).FirstOrDefault();

            _context.NewsFeedLike.Remove(model);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get NewsFeed Like By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<NewsFeedLike> GetNewsFeedLikeById(string newsFeedLikeId)
        {

            NewsFeedLike model = (from u in _context.NewsFeedLike
                          where u.NewsFeedLikeId == newsFeedLikeId
                          select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get News Feed Likes
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsFeedLike>> GetNewsFeedLikes()
        {
            
            return await _context.NewsFeedLike.ToListAsync();
        }

        /// <summary>
        /// Insert News Feed Like
        /// </summary>
        /// <param name="newsFeedLike"></param>
        public async Task InsertNewsFeedLike(NewsFeedLike newsFeedLike)
        {
            newsFeedLike.NewsFeedLikeId = Guid.NewGuid().ToString();

            _context.NewsFeedLike.Add(newsFeedLike);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update News Feed Like
        /// </summary>
        /// <param name="newsFeedLike"></param>
        public async Task UpdateNewsFeedLike(NewsFeedLike newsFeedLike)
        {
            _context.Entry(newsFeedLike).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Update NewsFeed Like Image
        /// </summary>
        /// <param name="newsFeedLikeId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateNewsFeedLikeImage(string newsFeedLikeId)
        {
            throw new NotImplementedException();
        }
    }
}
