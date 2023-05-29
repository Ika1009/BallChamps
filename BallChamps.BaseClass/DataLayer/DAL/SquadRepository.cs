using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;



namespace DataLayer.DAL
{
    public class SquadRepository : ISquadRepository, IDisposable
    {
        private SquadContext _context;
        

        public SquadRepository(SquadContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete Squad
        /// </summary>
        /// <param name="Id"></param>
        public async Task DeleteSquad(string Id)
        {
            Squad model = (from u in _context.Squad
                          where u.SquadId == Id
                          select u).FirstOrDefault();

            _context.Squad.Remove(model);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Squad By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Squad> GetSquadById(string Id)
        {

            Squad model = (from u in _context.Squad
                         where u.SquadId == Id
                          select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get All Blogs List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Squad>> GetSquads()
        {
            return null;
            //return await _context.Blog.ToListAsync();
        }

        /// <summary>
        /// Insert Squad
        /// </summary>
        /// <param name="model"></param>
        public async Task InsertSquad(Squad model)
        {
            model.SquadId = Guid.NewGuid().ToString();

            _context.Squad.Add(model);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Squad
        /// </summary>
        /// <param name="blog"></param>
        public async Task UpdateSquad(Squad model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Update Squad Image
        /// </summary>
        /// <param name="squadId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task UpdateSquadImage(string squadId)
        {
            throw new NotImplementedException();
        }
    }
}
