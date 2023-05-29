using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class PrivateRunApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get PrivateRuns
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<PrivateRun>> GetPrivateRuns(string token)
        {
           
            List<PrivateRun> _blogss = new List<PrivateRun>();
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PrivateRun/GetPrivateRuns/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss =  JsonConvert.DeserializeObject<List<PrivateRun>>(responseString);

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
        /// Get PrivateRun By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<PrivateRun> GetPrivateRunById(string privateRunId, string token)
        {

            PrivateRun _blog = new PrivateRun();
            string urlParameters = "?privateRunId=" + privateRunId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PrivateRun/GetPrivateRunById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<PrivateRun>(responseString);
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
        /// Get PrivateRun By HostId
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<PrivateRunDTO> GetPrivateRunHostById(string userProfileId, string token)
        {

            PrivateRunDTO _blog = new PrivateRunDTO();
            string urlParameters = "?userProfileId=" + userProfileId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PrivateRun/GetPrivateRunByHostId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<PrivateRunDTO>(responseString);
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
        /// Update PrivateRun By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> UpdatePrivateRunById(PrivateRun privateRun, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(privateRun);
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
                    var response = await client.PostAsync("api/PrivateRun/UpdatePrivateRun/", content);
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
        /// Insert PrivateRun
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> InsertPrivateRun(PrivateRun privateRun,  string token)
        {
 
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(privateRun);
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
                    var response = await client.PostAsync("api/PrivateRun/InsertPrivateRun/", content);
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
        /// Delete PrivateRun
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletePrivateRun(string privateRunId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
            Court _court = new Court();
            string urlParameters = "?privateRunId=" + privateRunId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync("api/PrivateRun/DeletePrivateRun/" + urlParameters);

                return response;

            }
        }

    }
}
