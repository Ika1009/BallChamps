using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class InboxApi
    {
        static WebApi _api = new WebApi();

        public static async Task<List<Inbox>> GetInboxByUserProfileId(string userProfileId, string token)
        {

            List<Inbox> _inbox = new List<Inbox>();

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
                    var response = await client.GetAsync("api/Inbox/GetInboxByUserProfileId" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _inbox = JsonConvert.DeserializeObject<List<Inbox>>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return _inbox;

        }


        public static async Task<Inbox> GetInboxById(string inboxId, string token)
        {

            Inbox _inbox = new Inbox();

            string urlParameters = "?inboxId=" + inboxId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Inbox/GetInboxById" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {

                        _inbox = JsonConvert.DeserializeObject<Inbox>(responseString);


                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return _inbox;

        }

        public static void UpdateInboxById(Inbox inbox, string token)
        {
            
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(inbox);

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
                    var response = client.PostAsync("api/Inbox/UpdateInbox/", content);
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

        public static void DeleteInbox(string inboxId, string userProfileId, string token)
        {

           
            Inbox _inbox = new Inbox();

            string urlParameters = "?inboxId=" + inboxId;
            string urlParametersTwo = "?userProfileId=" + userProfileId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Inbox/DeleteInbox" + urlParameters + urlParametersTwo);
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

        public static void InsertInbox(Inbox inbox, string token)
        {



            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(inbox);

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
                    var response = client.PostAsync("api/Inbox/InsertInbox/", content);
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
