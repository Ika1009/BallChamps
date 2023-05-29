using BallChamps.Domain;
using Common;
using DataLayer.BallChamps;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class NewsFeedRepository : INewsFeedRepository, IDisposable
    {
        private NewsFeedContext _context;
        private ProductContext _contextProduct;
        private CampaignContext _contextCampaign;
        private CourtContext _contextCourt;


        public NewsFeedRepository(NewsFeedContext context, ProductContext contextProduct, CourtContext contextCourt, CampaignContext contextCampaign)
        {
            this._context = context;
            this._contextProduct = contextProduct;
            this._contextCampaign = contextCampaign;
            this._contextCourt = contextCourt;
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        public async Task DeleteNewsFeed(string newsFeedId)
        {
            NewsFeed? model = (from u in _context.NewsFeed
                             where u.NewsFeedId == newsFeedId
                             select u).FirstOrDefault();

            _context.NewsFeed.Remove(model);
            await Save();

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
        /// Get NewsFeed By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<NewsFeed> GetNewsFeedById(string newsFeedId)
        {

            NewsFeed model = (from u in _context.NewsFeed
                         where u.NewsFeedId == newsFeedId
                              select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get All NewsFeed List
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsFeed>> GetNewsFeeds()
        {
            
            return await _context.NewsFeed.ToListAsync();
        }

        /// <summary>
        /// Insert New NewsFeed
        /// </summary>
        /// <param name="blog"></param>
        public async Task InsertNewsFeed(NewsFeed newsFeed)
        {
            string id = Guid.NewGuid().ToString();
            string uniqueNumber = Functions.GenerateSixDigit();

            newsFeed.NewsFeedId = id;
            newsFeed.NewsFeedNumber = uniqueNumber;
            newsFeed.ImagePath = "https://ballchampsstorage.blob.core.windows.net/newsfeed/"+ uniqueNumber +".png";
            newsFeed.PostedDate = DateTime.Now;
            newsFeed.Title = string.Empty;
            newsFeed.Body = string.Empty;
            newsFeed.Type = string.Empty;
            newsFeed.CreatedDate = DateTime.Now;
            newsFeed.Status = string.Empty;
            newsFeed.Likes = 0;
            newsFeed.ObjType = string.Empty;
            newsFeed.URL = string.Empty;
            newsFeed.VideoURL = string.Empty;

            _context.NewsFeed.Add(newsFeed);
            await Save();
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
        /// Update NewsFeed
        /// </summary>
        /// <param name="blog"></param>
        public async Task UpdateNewsFeed(NewsFeed newsFeed)
        {
            //_context.Entry(newsFeed).Property(x => x.CampaignId).IsModified = false;
            //_context.Entry(newsFeed).Property(x => x.ProductId).IsModified = false;
            //_context.Entry(newsFeed).Property(x => x.CourtId).IsModified = false;
            //_context.Entry(newsFeed).Property(x => x.CreatedDate).IsModified = false;
            //_context.Entry(newsFeed).Property(x => x.Type).IsModified = false;
            //_context.Entry(newsFeed).Property(x => x.ImagePath).IsModified = false;

            //_context.Entry(newsFeed).State = EntityState.Modified;
            await Save();
        }

        public async Task UpdateBlogImage(string blogId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistInNewFeed(string id, string ObjType)
        {

            //if(ObjType == "Court")
            //{
            //    var model = (from u in _context.NewsFeed
            //                 where u.CourtId == id
            //                 select u).AnyAsync();

            //    return model;
            //}
            //else if(ObjType == "Product")
            //    {
            //    var model = (from u in _context.NewsFeed
            //                 where u.ProductId == id
            //                 select u).AnyAsync();

            //    return model;
            //}
            //else if(ObjType == "Campaign")
            //{
            //    var model = (from u in _context.NewsFeed
            //                 where u.CampaignId == id
            //                 select u).AnyAsync();

            //    return model;
            //}
            return null;
        }

    }
}
