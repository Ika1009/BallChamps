using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BallChamps.Services
{
    public static class APIService
    {
        private static readonly HttpClient httpClient = new();
        const string endpoint = "https://ballchampswebapi.azurewebsites.net/api/";

        public static async Task<bool> LoginAsync(string email, string password)
        {
            var loginModel = new { email, password };
            
            var json = JsonSerializer.Serialize(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endpoint + "/Authentication/BallChampsAuthenticate", content);

            if (response.IsSuccessStatusCode)
                return true;
            else
                throw new Exception( JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync())["message"]);
        }
    }
}
