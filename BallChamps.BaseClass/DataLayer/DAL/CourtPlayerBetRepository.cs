using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class CourtPlayerBetRepository : ICourtPlayerBetRepository, IDisposable
    {
        private CourtPlayerBetContext _context;

        /// <summary>
        /// Court Player Bet Repository
        /// </summary>
        /// <param name="context"></param>
        public CourtPlayerBetRepository(CourtPlayerBetContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Get CourtPlayer Bet By CourtId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<List<CourtPlayerBet>> GetCourtPlayerBetByCourtId(string Id)
        {

            List<CourtPlayerBet> model = (from u in _context.CourtPlayerBet
                         where u.CourtPlayerBetId == Id
                         select u).ToList();

            return model;
        }


        /// <summary>
        /// Update Court Player Bet By CourtId
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateCourtPlayerBetByCourtId(CourtPlayerBet model)
        {
            _context.Entry(model).State = EntityState.Modified;
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
