using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class SquadApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Squads
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Squad>> GetSquads(string token)
        {
           
            List<Squad> _blogss = new List<Squad>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Squad/GetSquads/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss = JsonConvert.DeserializeObject<List<Squad>>(responseString);

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
        /// Get Squad By Id
        /// </summary>
        /// <param name="squadId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<SquadDTO>> GetSquadById(string squadId, string token)
        {
            
            List<SquadDTO> _blog = new List<SquadDTO>();

            string urlParameters = "?squadId=" + squadId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Squad/GetSquadById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<List<SquadDTO>>(responseString);
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
        /// Get Squad By Id
        /// </summary>
        /// <param name="squadId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<SquadDTO>> GetSquadByUserProfileId(string userProfileId, string token)
        {
            
            List<SquadDTO> _blog = new List<SquadDTO>();

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
                    var response = await client.GetAsync("api/Squad/GetSquadByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<List<SquadDTO>>(responseString);
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
        public static void UpdateSquadById(Squad blog, string token)
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
                    var response = client.PostAsync("api/Squad/UpdateSquad/", content);
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
        /// Delete Squad
        /// </summary>
        /// <param name="squadId"></param>
        /// <param name="token"></param>
        public static void DeleteSquad(string squadId, string token)
        {

            
            Blog _blog = new Blog();

            string urlParameters = "?squadId=" + squadId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Squad/DeleteSquad/" + urlParameters);
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
        /// Insert Squad
        /// </summary>
        /// <param name="squad"></param>
        /// <param name="token"></param>
        public static void InsertSquad(Squad squad, string token)
        {
        

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(squad);

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
                    var response = client.PostAsync("api/Squad/InsertSquad/", content);
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
