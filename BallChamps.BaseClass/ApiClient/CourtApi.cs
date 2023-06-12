using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public static class CourtApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Court By Id
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Court> GetCourtById(string courtId, string token)
        {
            Court _court = new Court();
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
                    var response = await client.GetAsync("api/Court/GetCourtById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _court = JsonConvert.DeserializeObject<Court>(responseString);

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
        /// Get Court Signed Up By UserProfieId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtDTO> GetCourtSignedUpByUserProfieId(string userProfileId, string token)
        {
           
            CourtDTO _court = new CourtDTO();

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
                    var response = await client.GetAsync("api/Court/GetCourtSignedUpByUserProfieId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _court = JsonConvert.DeserializeObject<CourtDTO>(responseString);


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
        /// Get Courts
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Court>> GetCourts(string token)
        {
           
            List<Court> _court = new List<Court>();
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Court/GetCourts/");
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _court = JsonConvert.DeserializeObject<List<Court>>(responseString);

                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new Exception("Token is expired");
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
        /// Update Court By Id
        /// </summary>
        /// <param name="court"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task UpdateCourtById(Court court, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(court);

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
                    var response = await client.PostAsync("api/Court/UpdateCourt/", content);
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
        /// Delete Court
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteCourt(string courtId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
           
            Court _court = new Court();

            string urlParameters = "?courtId=" + courtId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync("api/Court/DeleteCourt/" + urlParameters);

                return response;

            }



        }

        /// <summary>
        /// Create Court
        /// </summary>
        /// <param name="court"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task CreateCourt(Court court, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(court);
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
                    var response = await client.PostAsync("api/Court/CreateCourt/", content);
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
        /// Court Name Exist
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> CourtNameExist(string courtName, string token)
        {
           
            bool existResult = false;

            string urlParameters = "?courtName=" + courtName;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Court/CourtNameExist/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        existResult = JsonConvert.DeserializeObject<bool>(responseString);


                    }
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
