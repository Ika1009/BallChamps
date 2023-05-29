using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class PostApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Posts
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Post>> GetPosts(string token)
        {

            List<Post> _blogss = new List<Post>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Post/GetPosts/");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _blogss = JsonConvert.DeserializeObject<List<Post>>(responseString);

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
        /// Get Post By Id
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Post> GetPostById(string postId, string token)
        {

            Post _post = new Post();

            string urlParameters = "?postId=" + postId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Post/GetPostById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _post = JsonConvert.DeserializeObject<Post>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }
            return _post;
        }

        /// <summary>
        /// Update Post By Id
        /// </summary>
        /// <param name="post"></param>
        /// <param name="token"></param>
        public static void UpdatePostById(Post post, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(post);

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
                    var response = client.PostAsync("api/Post/UpdatePost/", content);
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


        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="token"></param>
        public static void DeletePost(string postId, string token)
        {

            Post _post = new Post();

            string urlParameters = "?postId=" + postId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Post/DeletePost/" + urlParameters);
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

        /// <summary>
        /// Insert Post
        /// </summary>
        /// <param name="post"></param>
        /// <param name="token"></param>
        public static void InsertPost(Post post, string token)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(post);

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
                    var response = client.PostAsync("api/Post/InsertPost/", content);
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
