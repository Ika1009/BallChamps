using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class GameHistoryApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Get GameHistory By UserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<PlayerHistoryDTO>> GetGameHistoryByUserProfileId(string userProfileId, string token)
        {

            List<PlayerHistoryDTO> _gameHistory = new List<PlayerHistoryDTO>();
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
                    var response = await client.GetAsync("api/GameHistory/GetGameHistoryByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _gameHistory = JsonConvert.DeserializeObject<List<PlayerHistoryDTO>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _gameHistory;

        }

        /// <summary>
        /// Get GameHistory By GameNumber
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<GameHistoryDTO>> GetGameHistoryByGameNumber(string gameNumber, string token)
        {

            List<GameHistoryDTO> _gameHistory = new List<GameHistoryDTO>();
            string urlParameters = "?gameNumber=" + gameNumber;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/GameHistory/GetGameHistoryByGameNumber/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _gameHistory = JsonConvert.DeserializeObject<List<GameHistoryDTO>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _gameHistory;

        }

        /// <summary>
        /// Insert GameHistory
        /// </summary>
        /// <param name="gameHistory"></param>
        /// <param name="token"></param>
        public static void InsertGameHistory(GameHistory gameHistory, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(gameHistory);
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
                    var response = client.PostAsync("api/GameHistory/InsertGameHistory/", content);
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
