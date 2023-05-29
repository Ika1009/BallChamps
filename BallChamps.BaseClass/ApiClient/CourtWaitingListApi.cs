using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class CourtWaitingListApi
    {

        static WebApi _api = new WebApi(); 

        /// <summary>
        /// Insert Guest Player To Court Waiting List
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task InsertGuestPlayerToCourtWaitingList(string userName, string courtId, string token)
        {

            CourtWaitingList _courtWaitingList = new CourtWaitingList();
            string urlParameters = "?userName=" + userName;
            string urlParametersTwo = "?courtId=" + courtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtWaitingList/InsertGuestPlayerToCourtWaitingList/" + urlParameters + urlParametersTwo);
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
        /// Insert Player To Court Waiting List
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task InsertPlayerToCourtWaitingList(string profileId, string courtId, string token)
        {

            CourtWaitingList courtWaitingList = new CourtWaitingList();
            courtWaitingList.ProfileId = profileId;
            courtWaitingList.CourtId = courtId;
            var userJsonString = JsonConvert.SerializeObject(courtWaitingList);
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent(userJsonString, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync("api/CourtWaitingList/InsertPlayerToCourtWaitingList", content);
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
        /// Get UserWaiting List Court Id By UserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtWaitingList> GetUserWaitingListCourtIdByUserProfileId(string userProfileId, string token)
        {

            CourtWaitingList _courtWaitingList = new CourtWaitingList();
            string urlParameters = "?userProfiledId=" + userProfileId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtWaitingList/GetUserWaitingListCourtIdByUserProfileId/" + urlParameters);
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


            return null;
        }

        /// <summary>
        /// Remove Player From Court Waiting List
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task RemovePlayerFromCourtWaitingList(string userProfileId,  string token)
        {

            CourtWaitingList _courtWaitingList = new CourtWaitingList();
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
                    var response = await client.PostAsync("api/CourtWaitingList/RemovePlayerFromCourtWaitingList" + urlParameters, null);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

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
        /// Get Court Waiting List By CourtId
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<CourtWaitingListDTO>> GetCourtWaitingListByCourtId(string courtId, string token)
        {

            List<CourtWaitingListDTO> _courtWaitingList = new List<CourtWaitingListDTO>();
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
                    var response = await client.GetAsync("api/CourtWaitingList/GetCourtWaitingListByCourtId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _courtWaitingList = JsonConvert.DeserializeObject<List<CourtWaitingListDTO>>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }


            return _courtWaitingList;
        }

        /// <summary>
        /// Is UserProfile Signed Up At Court
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="courtId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> IsUserProfileSignedUpAtCourt(string userProfileId, string courtId, string token)
        {

            bool isSignedUp = false;
            string result = string.Empty;
            string urlParameter = "?userProfileId=" + userProfileId;
            string urlParameterTwo = "&courtId=" + courtId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtWaitingList/IsUserProfileSignedUpAtCourt" + urlParameter + urlParameterTwo);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        isSignedUp = JsonConvert.DeserializeObject<bool>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }


            return isSignedUp;
        }

        /// <summary>
        /// Is UserProfile SignedUp At Any Court
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> IsUserProfileSignedUpAtAnyCourt(string userProfileId, string token)
        {

            bool isSignedUp = false;


            string urlParameterTwo = "?userProfileId=" + userProfileId;


            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CourtWaitingList/IsUserProfileSignedUpAtAnyCourt" + urlParameterTwo);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        isSignedUp = JsonConvert.DeserializeObject<bool>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }


            return isSignedUp;
        }

        /// <summary>
        /// Get Court UserProfile Is SignedUp At
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<CourtWaitingListDTO> GetCourtUserProfileIsSignedUpAt(string userProfileId, string token)
        {

            CourtWaitingListDTO _courtWaitingList = new CourtWaitingListDTO();
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
                    var response = await client.GetAsync("api/CourtWaitingList/GetCourtUserProfileIsSignedUpAt" + urlParameters);
 
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _courtWaitingList = JsonConvert.DeserializeObject<CourtWaitingListDTO>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }


            return _courtWaitingList;
        }

        /// <summary>
        /// Update CourtWaitingListDTO By Id
        /// </summary>
        /// <param name="court"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task UpdateCourtWaitingListById(CourtWaitingListDTO courtWaitingListDTO, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(courtWaitingListDTO);

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
                    var response = await client.PostAsync("api/CourtWaitingList/UpdateCourtWaitingListById/", content);
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
    }
}
