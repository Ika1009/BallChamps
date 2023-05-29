using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public static class UserApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task CreateUser(User user, string token)
        {        

            var userJsonString = JsonConvert.SerializeObject(user);

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
                    var response = await client.PostAsync("api/User/CreateUser/", content);

                }

                catch (Exception ex)
                {
                    var x = ex;

                }

            }

        }

        /// <summary>
        /// Get User By Id 
        /// </summary>
        /// <param name="bC_UserId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<User> GetUserById(string userId, string token)
        {

            User _user = new User();
            string urlParameters = "?userId=" + userId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/User/GetUserId" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _user = JsonConvert.DeserializeObject<User>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return _user;
        }

        /// <summary>
        /// Get UserProfileId By UserName
        /// </summary>
        /// <param name="bC_UserId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<string> GetUserProfileIdByUserName(string userName, string token)
        {

            string _user = string.Empty;
            string urlParameters = "?userName=" + userName;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/User/GetUserProfileIdByUserName" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _user = JsonConvert.DeserializeObject<string>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return _user;
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="bC_User"></param>
        /// <param name="token"></param>
        public static async Task UpdateUser(User User, string token)
        {
            var userJsonString = JsonConvert.SerializeObject(User);
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
                    var response = await client.PostAsync("api/User/UpdateUser", content);

                }

                catch (Exception ex)
                {
                    var x = ex;

                }

            }

        }

        /// <summary>
        /// Get Staff Users
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<User>> GetStaffUsers(string token)
        {
            List<User> _user = new List<User>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/User/GetStaffUsers");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _user = JsonConvert.DeserializeObject<List<User>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return _user;
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<User>> GetUsers(string token)
        {
            List<User> _user = new List<User>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/User/GetUsers");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _user = JsonConvert.DeserializeObject<List<User>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return _user;
        }

        /// <summary>
        /// Forgot Password
        /// </summary>
        /// <param name="bC_UserId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<User> ForgotPassword(string email, string token)
        {

            User _user = new User();
            string urlParameters = "?email=" + email;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/User/ForgotPassword" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _user = JsonConvert.DeserializeObject<User>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());

                }

            }
            return _user;
        }
    }
}
