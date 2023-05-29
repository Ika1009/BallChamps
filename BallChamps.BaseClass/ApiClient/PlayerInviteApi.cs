using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class PlayerInviteApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Blogs
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<PlayerInvite>> GetPlayerInvites(string token)
        {
           
            List<PlayerInvite> _blogss = new List<PlayerInvite>();
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/GetPlayerInvites/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss =  JsonConvert.DeserializeObject<List<PlayerInvite>>(responseString);

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
        public static async Task<PlayerInvite> GetPlayerInviteById(string playerInviteId, string token)
        {

            PlayerInvite _blog = new PlayerInvite();
            string urlParameters = "?playerInviteId=" + playerInviteId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/GetPlayerInviteById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<PlayerInvite>(responseString);
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
        /// Get Player Invites For User Profile Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<PlayerInviteDTO>> GetPlayerInvitesForUserProfileId(string userProfileId, string token)
        {

            List<PlayerInviteDTO> _blog = new List<PlayerInviteDTO>();
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
                    var response = await client.GetAsync("api/PlayerInvite/GetPlayerInvitesForUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<List<PlayerInviteDTO>>(responseString);
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
        ///GetPlayerInvitesByUserProfileId
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<PlayerInviteDTO>> GetPlayerInvitesByUserProfileId(string userProfileId, string token)
        {

            List<PlayerInviteDTO> _blog = new List<PlayerInviteDTO>();
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
                    var response = await client.GetAsync("api/PlayerInvite/GetPlayerInvitesByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<List<PlayerInviteDTO>>(responseString);
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
        /// Get Player Invites For User Profile Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<UserProfileDTO>> GetPlayersInvitesByReserveCourtId(string reserveCourtId, string token)
        {

            List<UserProfileDTO> _blog = new List<UserProfileDTO>();
            string urlParameters = "?reserveCourtId=" + reserveCourtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/GetPlayersInvitesByReserveCourtId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<List<UserProfileDTO>>(responseString);
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
        /// Update PlayerInvite By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> UpdatePlayerInviteById(PlayerInvite playerInvite, string token)
        {
           
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerInvite);
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
                    var response = await client.PostAsync("api/PlayerInvite/UpdatePlayerInvite/", content);
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
        /// Insert PlayerInvite
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> InsertPlayerInvite(PlayerInvite playerInvite,  string token)
        {
 
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(playerInvite);
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
                    var response = await client.PostAsync("api/PlayerInvite/InsertPlayerInvite/", content);
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
        /// Delete PlayerInvite
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeletePlayerInvite(string reserveCourtId,string userProfileId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
            Court _court = new Court();
            string urlParameters = "?reserveCourtId=" + reserveCourtId;
            string urlParametersTwo = "?userProfileId=" + userProfileId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync("api/PlayerInvite/DeletePlayerInvite/" + urlParameters + urlParametersTwo);

                return response;

            }
        }


        /// <summary>
        /// Confirmed PlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<int> ConfirmedPlayerInvite(string reserveCourtId, string token)
        {

            int _blog = 0;
            string urlParameters = "?reserveCourtId=" + reserveCourtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/ConfirmedPlayerInvite/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<int>(responseString);
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
        /// Declined PlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<int> DeclinedPlayerInvite(string reserveCourtId, string token)
        {

            int _blog = 0;
            string urlParameters = "?reserveCourtId=" + reserveCourtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/DeclinedPlayerInvite/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<int>(responseString);
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
        /// PendingPlayerInvite PlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<int> PendingPlayerInvite(string reserveCourtId, string token)
        {

            int _blog = 0;
            string urlParameters = "?reserveCourtId=" + reserveCourtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/PendingPlayerInvite/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<int>(responseString);
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
        /// Confirmed PlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<int> InvitedPlayerInvite(string reserveCourtId, string token)
        {

            int _blog = 0;
            string urlParameters = "?reserveCourtId=" + reserveCourtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/PlayerInvite/InvitedPlayerInvite/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<int>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _blog;
        }
    }
}
