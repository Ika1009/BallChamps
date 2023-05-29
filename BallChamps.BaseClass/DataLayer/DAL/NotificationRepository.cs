using ApiClient;
using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;


namespace DataLayer.DAL
{
    public class NotificationRepository : INotificationRepository, IDisposable
    {
        private NotificationContext _context;
       // private StorageAPI _storageAPI = new StorageAPI();

        public NotificationRepository(NotificationContext context)
        {
            this._context = context;
            
        }

        public async Task DeleteNotification(string notificationId)
        {
            Notification model = (from u in _context.Notification
                                  where u.NotificationId == notificationId
                                  select u).FirstOrDefault();

            _context.Notification.Remove(model);

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
       
        public async Task<Notification> GetNotificationById(string notificationId)
        {

            Notification model = (from u in _context.Notification
                               where u.NotificationId == notificationId
                                         select u).FirstOrDefault();

            

            return model;
        }

        public async Task<List<Notification>> GetNotifications()
        {
            return await _context.Notification.ToListAsync();
        }

        public async Task InsertNotification(Notification model)
        {
            model.NotificationId = Guid.NewGuid().ToString();
          //  product.ImagePath = "https://ballchampsstorage.blob.core.windows.net/productimage/" + product.ProductId + ".png";

            _context.Notification.Add(model);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        public async Task UpdateNotification(Notification model)
        {
            _context.Entry(model).State = EntityState.Modified;
        }

      

        #region Validation

       

        #endregion
    }
}
