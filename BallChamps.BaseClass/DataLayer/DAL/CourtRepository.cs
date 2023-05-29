using BallChamps.Domain;
using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.DAL
{
    public class CourtRepository : ICourtRepository, IDisposable
    {
        string CourtImageDefaultURL;
        private CourtContext _context;
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Court Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public CourtRepository(CourtContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;
            this.CourtImageDefaultURL = Configuration.GetSection("BlobStorage")["CourtImageDefaultURL"];
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
        /// Get Court By Id
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        public async Task<Court> GetCourtById(string courtId)
        {

            Court court = (from u in _context.Court
                             where u.CourtId == courtId
                             select u).FirstOrDefault();

            return court;
        }

        /// <summary>
        /// Get All Courts
        /// </summary>
        /// <returns></returns>
        public async Task<List<Court>> GetCourts()
        {

            return await _context.Court.ToListAsync();
        }

        /// <summary>
        /// Insert a New Court
        /// </summary>
        /// <param name="court"></param>
        public async Task InsertCourt(Court court)
        {
            court.CourtId = Guid.NewGuid().ToString();
            court.CourtNumber = Functions.GenerateSixDigit();
            court.ImagePath = CourtImageDefaultURL + court.CourtNumber + ".png";
            court.ObjType = "Court";


            await _context.Court.AddAsync(court);

            await Save();
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Court
        /// </summary>
        /// <param name="court"></param>
        public async Task UpdateCourt(Court court)
        {

            _context.Entry(court).Property(x => x.Rating).IsModified = false;
            _context.Entry(court).Property(x => x.CourtNumber).IsModified = false;
            _context.Entry(court).Property(x => x.CourtId).IsModified = false;


            _context.Entry(court).State = EntityState.Modified;
            await Save();
        }

        /// <summary>
        /// CourtNameExist
        /// </summary>
        /// <param name="courtName"></param>
        /// <returns></returns>
        public async Task<bool> CourtNameExist(string courtName)
        {

            Task<bool> result = (from u in _context.Court
                            where u.CourtName == courtName
                            select u).AnyAsync();

            return await result;
        }

        /// <summary>
        /// //Delete a Court By Id
        /// </summary>
        /// <param name="courtId"></param>
        public async Task DeleteCourt(string courtId)
        {
            Court court = (from u in _context.Court
                           where u.CourtId == courtId
                           select u).FirstOrDefault();

            _context.Court.Remove(court);
            await Save();

        }

    }
}
