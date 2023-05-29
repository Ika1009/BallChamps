using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Notification Controller
    /// </summary>
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {

        private INotificationRepository notificationRepository;
        /// <summary>
        /// Notification Controller Constructor
        /// </summary>
        /// <param name="blogContext"></param>
        public NotificationController(NotificationContext notificationContext)
        {
            this.notificationRepository = new NotificationRepository(notificationContext);
        }

        /// <summary>
        /// Get All Notifications
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNotifications")]
        public async  Task<List<Notification>> GetNotifications()
        {
            try
            {
                return await notificationRepository.GetNotifications();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        ///// <summary>
        ///// Get Notification By Id
        ///// </summary>
        ///// <param name="blogId"></param>
        ///// <returns></returns>
        //[HttpGet("GetNotificationById")]
        ////[Authorize]
        //public async Task<Blog> GetNotificationById(string notificationId)
        //{

        //    try
        //    {
        //        return await notificationRepository.GetNotificationById(notificationId);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //    return null;
        //}

        /// <summary>
        /// Delete Notification
        /// </summary>
        /// <param name="blogId"></param>
        [HttpPost("DeleteNotification")]
        //[Authorize]
        public void DeleteNotification(string notificationId)
        {

            try
            {
                notificationRepository.DeleteNotification(notificationId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        /// <summary>
        /// Create new Notification
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("CreateNotification")]
        public void CreateNotification([FromBody] Notification notification)
        {
            try
            {

                notificationRepository.InsertNotification(notification);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update Notification Info
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("UpdateNotification")]
        public void UpdateBlog([FromBody] Notification notification)
        {
            try
            {
                notificationRepository.UpdateNotification(notification);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
