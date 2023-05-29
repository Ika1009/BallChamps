using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IMessagesRepository : IDisposable
    {
        Task<List<Messages>> GetMessages();
        Task<Messages> GetMessagesById(string messagesId);
        Task InsertMessage(Messages messages);
        Task DeleteMessage(string messagesId);
        Task UpdateMessage(Messages messages);       
        Task<int> Save();

    }
}
