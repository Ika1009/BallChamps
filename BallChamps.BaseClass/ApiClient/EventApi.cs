using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient
{
    public class EventApi
    {
        static WebApi _api = new WebApi();

        public static async Task<List<Event>> GetBC_Events(string token)
        {

            List<Event> _height = new List<Event>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/BC_Event/GetBC_Events/");
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _height = JsonConvert.DeserializeObject<List<Event>>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return _height;

        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Event> GetBC_EventById(string bC_EventId, string token)
        {
           
            Event _blog = new Event();

            string urlParameters = "?bC_EventId=" + bC_EventId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/BC_Event/GetBC_EventById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<Event>(responseString);
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
        /// Update Blog By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static void UpdateBC_EventById(Event blog, string token)
        {
            
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(blog);

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
                    var response = client.PostAsync("api/Event/UpdateEvent/", content);
                    var responseString = response.Result.Content.ReadAsStringAsync();


                    if (response.Result.IsSuccessStatusCode)
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
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        public static void DeleteBlog(string bC_EventId, string token)
        {

            
            Event _blog = new Event();

            string urlParameters = "?bC_EventId=" + bC_EventId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Event/DeleteEvent/" + urlParameters);
                    var responseString = response.Result.Content.ReadAsStringAsync();


                    if (response.Result.IsSuccessStatusCode)
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
        /// Insert Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static void InsertBC_Event(Event blog, string token)
        {
            
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(blog);

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
                    var response = client.PostAsync("api/Event/InsertEvent/", content);
                    var responseString = response.Result.Content.ReadAsStringAsync();


                    if (response.Result.IsSuccessStatusCode)
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
