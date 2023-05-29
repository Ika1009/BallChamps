using ApiClient.Helper;
using BallChamps.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class CourtPrivateRunAvailabilityApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get CourtPrivateRunAvailabilitys
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<CourtPrivateRunAvailability>> GetCourtPrivateRunAvailabilitys(string token)
        {
           
            List<CourtPrivateRunAvailability> _blogss = new List<CourtPrivateRunAvailability>();
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtPrivateRunAvailability/GetCourtPrivateRunAvailabilitys/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss =  JsonConvert.DeserializeObject<List<CourtPrivateRunAvailability>>(responseString);

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
        /// Get CourtPrivateRunAvailability By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityById(string courtPrivateRunAvailabilityId, string token)
        {

            CourtPrivateRunAvailability _blog = new CourtPrivateRunAvailability();
            string urlParameters = "?courtPrivateRunAvailabilityId=" + courtPrivateRunAvailabilityId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtPrivateRunAvailability/GetCourtPrivateRunAvailabilityById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<CourtPrivateRunAvailability>(responseString);
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
        /// Get CourtPrivateRunAvailability By Court Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityByCourtId(string courtId, string token)
        {

            CourtPrivateRunAvailability _blog = new CourtPrivateRunAvailability();
            string urlParameters = "?courtId=" + courtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtPrivateRunAvailability/GetCourtPrivateRunAvailabilityByCourtId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<CourtPrivateRunAvailability>(responseString);
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
        /// Update CourtPrivateRunAvailability By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> UpdateCourtPrivateRunAvailabilityById(CourtPrivateRunAvailability model, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(model);
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
                    var response = await client.PostAsync("api/CourtPrivateRunAvailability/UpdateCourtPrivateRunAvailability/", content);
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
        /// Insert CourtPrivateRunAvailability
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> InsertCourtPrivateRunAvailability(CourtPrivateRunAvailability model, string token, IConfiguration configuration)
        {
 
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(model);
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
                    var response = await client.PostAsync("api/CourtPrivateRunAvailability/InsertCourtPrivateRunAvailability/", content);
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
        /// Delete CourtPrivateRunAvailability
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteCourtPrivateRunAvailability(string courtPrivateRunAvailabilityId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
            Court _court = new Court();
            string urlParameters = "?courtPrivateRunAvailabilityId=" + courtPrivateRunAvailabilityId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync("api/CourtPrivateRunAvailability/DeleteCourtPrivateRunAvailability/" + urlParameters);

                return response;

            }
        }

    }
}
