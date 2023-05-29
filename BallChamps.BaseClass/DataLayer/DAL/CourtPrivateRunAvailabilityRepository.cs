using BallChamps.Domain;
using Common;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.DAL
{
    public class CourtPrivateRunAvailabilityRepository : ICourtPrivateRunAvailabilityRepository, IDisposable
    {
        private CourtPrivateRunAvailabilityContext _context;

        /// <summary>
        /// CourtPrivateRunAvailability Repository
        /// </summary>
        /// <param name="context"></param>
        public CourtPrivateRunAvailabilityRepository(CourtPrivateRunAvailabilityContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Get CourtPrivateRunAvailability By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityById(string Id)
        {

            CourtPrivateRunAvailability model = (from u in _context.CourtPrivateRunAvailability
                                                where u.CourtPrivateRunAvailabilityId == Id
                             select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get CourtPrivateRunAvailability By CourtId
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityByCourtId(string Id)
        {

            CourtPrivateRunAvailability model = (from u in _context.CourtPrivateRunAvailability
                                                 where u.CourtId == Id
                                                 select u).FirstOrDefault();

            return model;
        }

        /// <summary>
        /// Get All Blogs List
        /// </summary>
        /// <returns></returns>
        public async Task<List<CourtPrivateRunAvailability>> GetCourtPrivateRunAvailabilitys()
        {
            return await _context.CourtPrivateRunAvailability.ToListAsync();
        }

        /// <summary>
        /// Insert New Blog
        /// </summary>
        /// <param name="blog"></param>
        public async Task InsertCourtPrivateRunAvailability(CourtPrivateRunAvailability model)
        {
            model.CourtPrivateRunAvailabilityId = Guid.NewGuid().ToString();
            //model.BlogNumber = Functions.GenerateSixDigit();

            _context.CourtPrivateRunAvailability.Add(model);
            Save();
        }

        /// <summary>
        /// Update Blog Info
        /// </summary>
        /// <param name="blog"></param>
        public async Task UpdateCourtPrivateRunAvailability(CourtPrivateRunAvailability model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        public async Task DeleteCourtPrivateRunAvailability(string Id)
        {
            CourtPrivateRunAvailability model = (from u in _context.CourtPrivateRunAvailability
                                                 where u.CourtPrivateRunAvailabilityId == Id
                         select u).FirstOrDefault();

            _context.CourtPrivateRunAvailability.Remove(model);
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
