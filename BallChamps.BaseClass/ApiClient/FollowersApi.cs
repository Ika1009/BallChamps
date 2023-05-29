using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Nancy.Json;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class FollowersApi
    {


        static WebApi _api = new WebApi();

        public static async Task<string> FollowersCount(string userProfileId, string token)
        {
            string count = "0";
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
                    var response = await client.GetAsync("api/Followers/FollowersCount/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        count = JsonConvert.DeserializeObject<string>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return count;
        }

        public static async Task<string> FollowingCount(string userProfileId, string token)
        {

            string count = "0";
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
                    var response = await client.GetAsync("api/Followers/FollowingCount/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        count = JsonConvert.DeserializeObject<string>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return count;
        }

        public static async Task<List<Followers>> GetFollowersByUserProfileId(string UserProfileId, string token)
        {

            List<Followers> followersList = new List<Followers>();
            string urlParameters = "?userProfileId=" + UserProfileId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Followers/GetFollowersById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        followersList = JsonConvert.DeserializeObject<List<Followers>>(responseString);

                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return followersList;
        }

        public static async Task<List<Followers>> GetFollowingByUserProfileId(string UserProfileId, string token)
        {

            List<Followers> followersList = new List<Followers>();
            string urlParameters = "?userProfileId=" + UserProfileId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Followers/GetFollowingUsersById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        followersList = JsonConvert.DeserializeObject<List<Followers>>(responseString);

                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return followersList;
        }

        public static async Task<List<FollowDTO>> GetCurrentFollowingUserProfiles(string UserProfileId, string token)
        {
            List<FollowDTO> followersList = new List<FollowDTO>();
            string urlParameters = "?userProfileId=" + UserProfileId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Followers/GetCurrentFollowingUserProfiles" + urlParameters);
                    string responseUri = response.RequestMessage.RequestUri.ToString();
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        followersList = JsonConvert.DeserializeObject<List<FollowDTO>>(responseString);

                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return followersList;
        }

        public static async Task<List<FollowDTO>> GetCurrentFollowersUserProfiles(string UserProfileId, string token)
        {
            List<FollowDTO> followersList = new List<FollowDTO>();
            string urlParameters = "?userProfileId=" + UserProfileId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Followers/GetCurrentFollowersUserProfiles" + urlParameters);
                    string responseUri = response.RequestMessage.RequestUri.ToString();
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        followersList = JsonConvert.DeserializeObject<List<FollowDTO>>(responseString);
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return followersList;
        }

        public static async Task Follow(string FollowedByUserProfileId, string UserProfileId, string token)
        {

            Followers _follow = new Followers();

            _follow.UserProfileId = UserProfileId;
            _follow.FollowedByUserProfileId = FollowedByUserProfileId;


            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(_follow);

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
                    var response = await client.PostAsync("api/Followers/Follow", content);
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

        public static async Task UnFollow(string followedByUserProfileId, string userProfileId, string token)
        {
            string urlParameters = "?followedByUserProfileId=" + followedByUserProfileId;
            string urlParameterTwo = "&userProfileId=" + userProfileId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                try
                {
                    var response = await client.PostAsync("api/Followers/UnFollow" + urlParameters + urlParameterTwo, null);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseUri = response.RequestMessage.RequestUri.ToString();
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;

                }

            }

        }
        public static async Task<bool> IsFollowingUserProfile(string followedByUserProfileId, string userProfileId, string token)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            string isFollowing = string.Empty;
            bool isFlag = false;
            string urlParameters = "?followingUserProfileId=" + followedByUserProfileId;
            string urlParameterTwo = "&userProfileId=" + userProfileId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    var response = client.GetAsync("api/Followers/IsFollowingUserProfile" + urlParameters + urlParameterTwo).Result;
                    string responseUri = response.RequestMessage.RequestUri.ToString();
                    isFollowing = await response.Content.ReadAsStringAsync();
                    isFlag = js.Deserialize<bool>(isFollowing);
                }

                catch (Exception ex)
                {
                    var x = ex;

                }
                return isFlag;
            }

        }
    }
}
