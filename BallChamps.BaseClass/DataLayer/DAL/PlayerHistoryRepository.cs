using BallChamps.Domain;
using Common;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.DAL
{
    public class PlayerHistoryRepository : IPlayerHistoryRepository, IDisposable
    {
        private PlayerHistoryContext _context;

        /// <summary>
        /// PlayerHistory Repository
        /// </summary>
        /// <param name="context"></param>
        public PlayerHistoryRepository(PlayerHistoryContext context)
        {
            this._context = context;
            
        }
       
        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<PlayerHistory> GetPlayerHistoryById(string Id)
        {

            PlayerHistory model = (from u in _context.PlayerHistory
                                  where u.PlayerHistoryId == Id
                             select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get All PlayerHistorys List
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlayerHistory>> GetPlayerHistorys()
        {
            return await _context.PlayerHistory.ToListAsync();
        }

        /// <summary>
        /// Insert New PlayerHistory
        /// </summary>
        /// <param name="model"></param>
        public async Task InsertPlayerHistory(PlayerHistory model)
        {
            model.PlayerHistoryId = Guid.NewGuid().ToString();
            model.Status = "C";

            _context.PlayerHistory.Add(model);
            Save();
        }

        /// <summary>
        /// Update PlayerHistory Info
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdatePlayerHistory(PlayerHistory model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Delete PlayerHistory
        /// </summary>
        /// <param name="Id"></param>
        public async Task DeletePlayerHistory(string Id)
        {
            PlayerHistory model = (from u in _context.PlayerHistory
                                   where u.PlayerHistoryId == Id
                         select u).FirstOrDefault();

            _context.PlayerHistory.Remove(model);
            Save();

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
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
