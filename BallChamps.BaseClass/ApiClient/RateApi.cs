using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class RateApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Rates
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Rate>> GetRates(string token)
        {
            
            List<Rate> _rate = new List<Rate>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Rate/GetRates/");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _rate = JsonConvert.DeserializeObject<List<Rate>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _rate;

        }
    }
}
