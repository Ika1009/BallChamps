using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IEventRepository : IDisposable
    {
        Task<List<Event>> GetEvents();
        Task<Event> GetEventById(string blogId);
        Task InsertEvent(Event blog);
        Task DeleteEvent(string blogId);
        Task UpdateEvent(Event blog);
        Task UpdateEventImage(string blogId);
        Task<int> Save();
    }
}
