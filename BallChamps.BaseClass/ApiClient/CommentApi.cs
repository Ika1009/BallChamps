using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public static class CommentApi
    {
        static WebApi _api = new WebApi();
        public static async Task<List<CommentDTO>> GetCommentByUserProfileId(string userProfileId, string token)
        {

            List<CommentDTO> _comments = new List<CommentDTO>();

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
                    var response = await client.GetAsync("api/Comment/GetCommentByUserProfileId" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {


                        _comments = JsonConvert.DeserializeObject<List<CommentDTO>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }
                return _comments;
            }



        }

        public static async void CommentPlayerUpdate(Comment commentRate, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(commentRate);


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
                    var response = await client.PostAsync("api/Comment/CommentPlayerUpdate/", content);
                    var responseString = await response.Content.ReadAsStringAsync();

                    string responseUri = response.RequestMessage.RequestUri.ToString();

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

        public static async Task<bool> ValidateUserHasCommentedOnPlayerBefore(string CommentFromProfileId, string CommentToUserProfileId, string token)
        {

            Comment _courtWaitingList = new Comment();




            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/CommentRate/GetCommentByUserProfileId/");
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

            return false;

        }

        public static void CreateComment(Comment commentRate, string token)
        {




            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(commentRate);

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
                    var response = client.PostAsync("api/Comment/CreateComment/", content);
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




        public static async Task<string> GetCommentsCount(string userProfileId, string token)
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
                    var response = await client.GetAsync("api/Comment/GetCommentsCount/" + urlParameters);
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
    }
}
