using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class PlayerHistoryApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get PlayerHistorys
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<PlayerHistory>> GetPlayerHistorys(string token)
        {
           
            List<PlayerHistory> _blogss = new List<PlayerHistory>();
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerHistory/GetPlayerHistorys/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss =  JsonConvert.DeserializeObject<List<PlayerHistory>>(responseString);

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
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<PlayerHistory> GetPlayerHistoryById(string playerHistoryId, string token)
        {

            PlayerHistory _blog = new PlayerHistory();
            string urlParameters = "?playerHistoryId=" + playerHistoryId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerHistory/GetPlayerHistoryById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<PlayerHistory>(responseString);
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
        /// Update PlayerHistory By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> UpdatePlayerHistoryById(PlayerHistory blog, string token)
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
                    var response = await client.PostAsync("api/PlayerHistory/UpdatePlayerHistory/", content);
                    var responseString = response.Content.ReadAsStringAsync();

                    return response;
                }

                catch (Exception ex)
                {
                    var x = ex;
                }
                return null;
            }

        }



        /// <summary>
        /// Delete PlayerHistory
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletePlayerHistory(string playerHistoryId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
            Court _court = new Court();
            string urlParameters = "?playerHistoryId=" + playerHistoryId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync("api/PlayerHistory/DeletePlayerHistory/" + urlParameters);

                return response;

            }
        }

    }
}
