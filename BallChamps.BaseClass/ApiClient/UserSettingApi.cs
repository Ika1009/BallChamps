using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class UserSettingApi
    {

        static WebApi _api = new WebApi();


        /// <summary>
        /// Get User Setting By User ProfileId
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<UserSetting> GetUserSettingByUserProfileId(string userProfileId, string token)
        {

            UserSetting _UserSetting = new UserSetting();

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
                    var response = await client.GetAsync("api/UserSetting/GetUserSettingByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _UserSetting = JsonConvert.DeserializeObject<UserSetting>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _UserSetting;
        }

        /// <summary>
        /// Update UserSetting By UserProfile Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> UpdateUserSettingByUserProfileId(UserSetting blog, string token)
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
                    var response = await client.PostAsync("api/UserSetting/UpdateUserSettingByUserProfileId/", content);
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

    }
}
