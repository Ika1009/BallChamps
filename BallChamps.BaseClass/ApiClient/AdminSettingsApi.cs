using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class AdminSettingsApi
    {

        static WebApi _api = new WebApi();
        public static async Task<AdminSettings> GetInstallURLs()
        {
            
            AdminSettings _adminSettings = new AdminSettings();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer ");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/AdminSettings/GetInstallURLs/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _adminSettings = JsonConvert.DeserializeObject<AdminSettings>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _adminSettings;
        }

        public static async Task<AdminSettings> GetAdminSettingsById(string adminSettingsId, string token)
        {


            
            AdminSettings _adminSettings = new AdminSettings();

            string urlParameters = "?adminSettingsId=" + adminSettingsId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/AdminSettings/GetAdminSettingsById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _adminSettings = JsonConvert.DeserializeObject<AdminSettings>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _adminSettings;

        }
        public static void UpdateAdminSettingsById(AdminSettings adminSettings, string token)
        {
            

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(adminSettings);

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
                    var response = client.PostAsync("api/AdminSettings/UpdateAdminSettings/", content);
                    var responseString = response.Result.Content.ReadAsStringAsync();


                    if (response.Result.IsSuccessStatusCode)
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