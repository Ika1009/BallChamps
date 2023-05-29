using BallChamps.Domain;

using Microsoft.EntityFrameworkCore;



namespace DataLayer.DAL
{
    public class EventRepository : IEventRepository, IDisposable
    {
        private EventContext _context;
        //private StorageAPI _storageAPI = new StorageAPI("blogimage");

        public EventRepository(EventContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        public async Task DeleteEvent(string blogId)
        {
            Event blog = (from u in _context.Event
                             where u.EventId == blogId
                         select u).FirstOrDefault();

            _context.Event.Remove(blog);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }
       
        /// <summary>
        /// Get Blog By ID
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<Event> GetEventById(string blogId)
        {

            Event blog = (from u in _context.Event
                         where u.EventId == blogId
                             select u).FirstOrDefault();

            return  blog;
        }

        /// <summary>
        /// Get All Blogs List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Event>> GetEvents()
        {
            
            return await _context.Event.ToListAsync();
        }

        /// <summary>
        /// Insert New Blog
        /// </summary>
        /// <param name="blog"></param>
        public async Task InsertEvent(Event blog)
        {
            blog.EventId = Guid.NewGuid().ToString();

            _context.Event.Add(blog);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Blog Info
        /// </summary>
        /// <param name="blog"></param>
        public async Task UpdateEvent(Event blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
            Save();
        }

        public async Task UpdateEventImage(string blogId)
        {
            throw new NotImplementedException();
        }
    }
}
