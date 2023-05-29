using BallChamps.Domain;
using DataLayer.BallChamps;
using Microsoft.EntityFrameworkCore;



namespace DataLayer.DAL
{
    public class MessagesRepository : IMessagesRepository, IDisposable
    {
        private MessagesContext _context;
       

        public MessagesRepository(MessagesContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete Messages
        /// </summary>
        /// <param name="messagesId"></param>
        public async Task DeleteMessage(string messagesId)
        {
            Messages messages = (from u in _context.Messages
                             where u.MessageId == messagesId
                             select u).FirstOrDefault();

            _context.Messages.Remove(messages);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Messages By Id
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        public async Task<Messages> GetMessagesById(string messageId)
        {

            Messages blog = (from u in _context.Messages
                             where u.MessageId == messageId
                             select u).FirstOrDefault();

            return  blog;
        }

        /// <summary>
        /// Get Messages
        /// </summary>
        /// <returns></returns>
        public async Task<List<Messages>> GetMessages()
        {

            return await _context.Messages.ToListAsync();
        }

        /// <summary>
        /// Insert Message
        /// </summary>
        /// <param name="messages"></param>
        public async Task InsertMessage(Messages messages)
        {
            messages.MessageId = Guid.NewGuid().ToString();

            _context.Messages.Add(messages);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Message
        /// </summary>
        /// <param name="messages"></param>
        public async Task UpdateMessage(Messages messages)
        {
            _context.Entry(messages).State = EntityState.Modified;
            Save();
        }
      
    }
}
