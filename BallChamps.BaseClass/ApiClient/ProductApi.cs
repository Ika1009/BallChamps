using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class ProductApi
    {
        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Products
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Product>> GetProducts(string token)
        {
           
            List<Product> _product = new List<Product>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Product/GetProducts/");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _product = JsonConvert.DeserializeObject<List<Product>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _product;

        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Product> GetProductById(string productId, string token)
        {

           
            Product _product = new Product();
            string urlParameters = "?productId=" + productId;
            var clientBaseAddress = _api.Intial();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Product/GetProductById" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _product = JsonConvert.DeserializeObject<Product>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }

            }

            return _product;
        }

        /// <summary>
        /// Update Product By Id
        /// </summary>
        /// <param name="product"></param>
        /// <param name="token"></param>
        public static async Task UpdateProductById(Product product, string token)
        {
          

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(product);
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
                    var response = client.PostAsync("api/Product/UpdateProduct/", content);
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
        /// Delete Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="token"></param>
        public static async Task<HttpResponseMessage> DeleteProduct(string productId, string token)
        {
            HttpResponseMessage returnMessage = new HttpResponseMessage();
           
            Product _product = new Product();

            string urlParameters = "?productId=" + productId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                var response = await client.DeleteAsync("api/Product/DeleteProduct/" + urlParameters);
                return response;

            }

        }

        /// <summary>
        /// Insert Product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="token"></param>
        public static async Task InsertProduct(Product product, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(product);

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
                    var response = client.PostAsync("api/Product/InsertProduct/", content);
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
