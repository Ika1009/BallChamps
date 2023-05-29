using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class AdminApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Update User Profile Rank By Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        public static async void UpdateUserProfileById_Admin(Profile profile, string token)
        {
           
            Profile _profile = new Profile();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(profile);

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
                    var response = await client.PostAsync("api/Admin/UpdateProfileById_Admin/", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _profile = JsonConvert.DeserializeObject<Profile>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

    }
}
