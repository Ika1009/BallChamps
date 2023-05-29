using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class CampaignApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Blogs
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Campaign>> GetCampaigns(string token)
        {
            
            List<Campaign> _blogss = new List<Campaign>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Campaign/GetCampaigns/");
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss = JsonConvert.DeserializeObject<List<Campaign>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _blogss;
        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Campaign> GetCampaignById(string campaignId, string token)
        {
           
            Campaign _blog = new Campaign();

            string urlParameters = "?campaignId=" + campaignId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Campaign/GetCampaignById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        _blog = JsonConvert.DeserializeObject<Campaign>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _blog;
        }

        /// <summary>
        /// Update Blog By Id
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task UpdateCampaignById(Campaign campaign, string token)
        {
            
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(campaign);

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
                    var response = await client.PostAsync("api/Campaign/UpdateCampaign/", content);
                    var responseString =  await response.Content.ReadAsStringAsync();


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
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="token"></param>
        public static async Task DeleteCampaign(string campaignId, string token)
        {

           
            Campaign _blog = new Campaign();

            string urlParameters = "?campaignId=" + campaignId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Campaign/DeleteCampaign/" + urlParameters);
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
        /// Insert Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="token"></param>
        public static async Task InsertCampaign(Campaign blog, string token)
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
                    var response = await client.PostAsync("api/Campaign/InsertCampaign/", content);
                    var responseString =  await response.Content.ReadAsStringAsync();


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
