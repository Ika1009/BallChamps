using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface INotificationRepository : IDisposable
    {
        Task<List<Notification>> GetNotifications();
        Task<Notification> GetNotificationById(string notificationId);
        Task InsertNotification(Notification notification);
        Task DeleteNotification(string notificationId);
        Task UpdateNotification(Notification notification);    
        Task<int> Save();
    }
}
