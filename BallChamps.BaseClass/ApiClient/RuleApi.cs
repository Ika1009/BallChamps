using ApiClient.Helper;
using BallChamps.Domain;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ApiClient
{
    public class RuleApi
    {

        static WebApi _api = new WebApi();

        /// <summary>
        /// Get Rules
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Rule>> GetRules(string token)
        {
          
            List<Rule> _rule = new List<Rule>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Rule/GetRules/");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _rule = JsonConvert.DeserializeObject<List<Rule>>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }
            }

            return _rule;
        }

        /// <summary>
        /// Get Rule By Id
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Rule> GetRuleById(string ruleId, string token)
        {

            
            Rule _rule = new Rule();

            string urlParameters = "?ruleId=" + ruleId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Rule/GetRuleById/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();


                    if (response.IsSuccessStatusCode)
                    {
                        _rule = JsonConvert.DeserializeObject<Rule>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    var x = ex;
                }
            }
            return _rule;
        }

        /// <summary>
        /// Update Rule By Id
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="token"></param>
        public static void UpdateRuleById(Rule rule, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(rule);

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
                    var response = client.PostAsync("api/Rule/UpdateRule/", content);
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
        /// Delete Rule
        /// </summary>
        /// <param name="ruleId"></param>
        /// <param name="token"></param>
        public static void DeleteRule(string ruleId, string token)
        {

            Rule _rule = new Rule();

            string urlParameters = "?ruleId=" + ruleId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/Rule/DeleteRule/" + urlParameters);
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
        /// Insert Rule
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="token"></param>
        public static void InsertRule(Rule rule, string token)
        {
           

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(rule);

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
                    var response = client.PostAsync("api/Rule/InsertRule/", content);
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
