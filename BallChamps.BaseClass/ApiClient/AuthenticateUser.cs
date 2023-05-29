using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public static class AuthenticateUser
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Authenticate Users
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Username"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static async Task<User> AuthenticateUsers(string Email, string Username, string Password)
        {

            User user = new User();
            var values = new User();
            values.Email = Email;
            values.Password = Password;
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(values);
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");


                    var response = await client.PostAsync("api/Authentication/BallChampsAuthenticate", content);
                   
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        user = JsonConvert.DeserializeObject<User>(responseString.ToString());
                       
                    }
                    else
                    {
                        //user.ErrorMessage = response.IsSuccessStatusCode.ToString() + " "+ "Error";
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return user;

        }
    }
}
