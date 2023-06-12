using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BallChamps.Domain;
using Newtonsoft.Json;

namespace BallChamps.Services
{
    public static class APIService
    {
        private static readonly HttpClient httpClient = new();
        const string endpoint = "https://ballchampswebapi.azurewebsites.net/api";

        public static async Task<User> LoginAsync(string email, string password)
        {
            var loginModel = new { email, password };

            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endpoint + "/Authentication/BallChampsAuthenticate", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(responseString);

                return user;
            }
            else
            {
                var errorMessage = JsonConvert.DeserializeObject<Dictionary<string, string>>(await response.Content.ReadAsStringAsync())["message"];
                throw new Exception(errorMessage);
            }
        }
        /*public static async Task<List<Court>> GetCourtsAsync()
        {
            var response = await httpClient.GetAsync(endpoint + "/Court/GetCourts");
            
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Court>>(responseString.ToString());
                // JsonConvert.DeserializeObject<List<Court>>(responseString.ToString()); with the NewtonSoftJson
            }
            else
                throw new Exception( JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync())["message"]);
        }
        
        public static async Task<List<Profile>> GetAllProfilesAsync()
        {
            var response = await httpClient.GetAsync(endpoint + "/Profile/GetProfiles");
            
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Profile>>(responseString.ToString());
                // JsonConvert.DeserializeObject<List<Court>>(responseString.ToString()); with the NewtonSoftJson
            }
            else
                throw new Exception( JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync())["message"]);
        }*/
        
    }
}
