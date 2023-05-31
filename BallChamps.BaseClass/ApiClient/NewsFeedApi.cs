using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public static class NewsFeedApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get News Feed By Id
        /// </summary>
        /// <param name="newsFeedId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<NewsFeed> GetNewsFeedById(string newsFeedId, string token)
        {
           
            NewsFeed _court = new NewsFeed();
            string urlParameters = "?newsFeedId=" + newsFeedId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/NewsFeed/GetNewsFeedById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _court = JsonConvert.DeserializeObject<NewsFeed>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _court;

        }

        /// <summary>
        /// Get News Feeds
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<NewsFeed>> GetNewsFeeds(string token)
        {
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/NewsFeed/GetNewsFeeds/");
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<List<NewsFeed>>(responseString);
                    else
                        throw new Exception("Something went wrong!");
                }

                catch (Exception ex)
                {
                    return new List<NewsFeed>();
                }

            }
        }

        /// <summary>
        /// Update NewsFeed By Id
        /// </summary>
        /// <param name="newsFeed"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task UpdateNewsFeedById(NewsFeed newsFeed, string token)
        {
    
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(newsFeed);
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
                    var response = client.PostAsync("api/NewsFeed/UpdateNewsFeed/", content);
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
        /// Insert NewsFeed
        /// </summary>
        /// <param name="newsFeed"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> InsertNewsFeed(NewsFeed newsFeed, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(newsFeed);
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
                    var response = await client.PostAsync("api/NewsFeed/InsertNewsFeed/", content);
                    var responseString = response.Content.ReadAsStringAsync();
                    return response;
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return null;

        }

        /// <summary>
        /// Delete Court
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteNewsFeed(string newsFeedId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
            Court _court = new Court();
            string urlParameters = "?newsFeedId=" + newsFeedId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync("api/NewsFeed/DeleteNewsFeed/" + urlParameters);

                return response;

            }



        }

        /// <summary>
        /// ExistInNewsFeed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ObjectType"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> ExistInNewsFeed(string id, string ObjectType, string token)
        {
            
            bool existResult = false;

            string urlParameters = "?Id=" + id;
            string urlParameters2 = "&objectType=" + ObjectType;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/NewsFeed/ExistInNewsFeed/" + urlParameters + urlParameters2);
                    var responseString = await response.Content.ReadAsStringAsync();


                        existResult = JsonConvert.DeserializeObject<bool>(responseString);

                    
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return existResult;
        }

    }
}
