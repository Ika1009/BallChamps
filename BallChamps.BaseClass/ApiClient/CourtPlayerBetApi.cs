using ApiClient.Helper;
using BallChamps.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class CourtPlayerBetApi
    {

        static WebApi _api = new WebApi();


        /// <summary>
        /// Insert Court  PlayerBet
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> InsertCourtPlayerBet(CourtPlayerBet courtPlayerBet, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(courtPlayerBet);
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
                    var response = await client.PostAsync("api/CourtPlayerBet/InsertCourtPlayerBet/", content);
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
        /// Update CourtPlayerBet By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> UpdateCourtPlayerBetByCourtId(CourtPlayerBet courtBet, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(courtBet);
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
                    var response = await client.PostAsync("api/CourtPlayerBet/UpdateCourtPlayerBetByCourtId/", content);
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
        /// Get Court Player Bet By Id
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtPlayerBet> GetCourtPlayerBetById(string courtPlayerBetId, string token)
        {
            CourtPlayerBet _court = new CourtPlayerBet();
            string urlParameters = "?courtPlayerBetId=" + courtPlayerBetId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtPlayerBet/GetCourtPlayerBetById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _court = JsonConvert.DeserializeObject<CourtPlayerBet>(responseString);

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
        /// Get Court Player Bet By Id
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtPlayerBet> GetCourtPlayerBetByCourtId(string courtId, string token)
        {
            CourtPlayerBet _court = new CourtPlayerBet();
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
                    var response = await client.GetAsync("api/CourtPlayerBet/GetCourtPlayerBetByCourtId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _court = JsonConvert.DeserializeObject<CourtPlayerBet>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _court;

        }

    }
}
