using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class NotificationApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Notifications
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Notification>> GetNotifications(string token)
        {
            
            List<Notification> _blogss = new List<Notification>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Notification/GetNotifications/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss = JsonConvert.DeserializeObject<List<Notification>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _blogss;
        }

        /// <summary>
        /// Get Notification By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Notification> GetNotificationById(string notificationId, string token)
        {
            
            Notification _blog = new Notification();

            string urlParameters = "?notificationId=" + notificationId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Notification/GetNotificationById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<Notification>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _blog;
        }

        /// <summary>
        /// Update Notification By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task UpdateNotificationById(Notification notification, string token)
        {
           

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(notification);

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync("api/Notification/UpdateNotification/", content);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

        }

        /// <summary>
        /// Delete Notification
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        public static async Task DeleteNotification(string notificationId, string token)
        {

            

            string urlParameters = "?notificationId=" + notificationId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Notification/DeleteNotification/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }
        }

        /// <summary>
        /// Insert Notification
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task InsertNotification(Notification notification, string token)
        {
          

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(notification);

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync("api/Notification/InsertNotification/", content);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

        }
    }
}
