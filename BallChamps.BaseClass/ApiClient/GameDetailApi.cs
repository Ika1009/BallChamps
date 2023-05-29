using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class GameDetailApi
    {
        static WebApi _api = new WebApi();
        public static async Task<List<GameDetail>> GetGameDetails(string token)
        {
            
            List<GameDetail> _blogss = new List<GameDetail>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/GameDetail/GetGameDetails/");
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _blogss = JsonConvert.DeserializeObject<List<GameDetail>>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _blogss;

        }
        public static async Task<GameDetail> GetGameDetailById(string gameDetailId, string token)
        {



           
            GameDetail _gameDetail = new GameDetail();

            string urlParameters = "?gameDetailId=" + gameDetailId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/GameDetail/GetGameDetailById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _gameDetail = JsonConvert.DeserializeObject<GameDetail>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _gameDetail;

        }


        public static async Task<List<GameDetail>> GetGameDetailByUserProfileId(string userProfileId, string token)
        {



            
            List<GameDetail> _gameDetail = new List<GameDetail>();

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
                    var response = await client.GetAsync("api/GameDetail/GetGameDetailByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _gameDetail = JsonConvert.DeserializeObject<List<GameDetail>>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _gameDetail;

        }
        public static void UpdateGameDetailById(GameDetail gameDetail, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(gameDetail);

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
                    var response = client.PostAsync("api/GameDetail/UpdateGameDetail/", content);
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

        public static void DeleteGameDetail(string blogId, string token)
        {

           
            GameDetail _blog = new GameDetail();

            string urlParameters = "?blogId=" + blogId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/GameDetail/DeleteGameDetail/" + urlParameters);
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

        public static void InsertGameDetail(GameDetail gameDetail, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(gameDetail);

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
                    var response = client.PostAsync("api/GameDetail/InsertGameDetail/", content);
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
