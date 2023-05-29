using ApiClient.Helper;
using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace ApiClient
{
    public class ProfileApi
    {
        
        #region Variables
        static CloudBlobClient _blobClient;
        static CloudBlobContainer _blobContainer;
        const string _blobContainerName = "userprofileimage";
        const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=ballchampsstorage;AccountKey=Qz0NfTCxrBnoZCm+JATQLaPBqnHp6WpGVyMnGSENkgSSDjGWrGDOaxhlXHYvUuex6uhsZhjQfwilg959tl/LyQ==;EndpointSuffix=core.windows.net";
        static WebApi _api = new WebApi();
        #endregion

        /// <summary>
        /// Return all UserProfiles
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<Profile>> GetProfiles(string token)
        {
            List<Profile> _profiles = new List<Profile>();

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Profile/GetProfiles/");
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _profiles = JsonConvert.DeserializeObject<List<Profile>>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return _profiles;
        }

        /// <summary>
        /// Get User Profile By Id
        /// </summary>
        /// <param name="userProfiledId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<Profile> GetProfileById(string profiledId, string token)
        {

            Profile _userProfile = new Profile();

            string urlParameters = "?profileId=" + profiledId;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await client.GetAsync("api/Profile/GetProfileById" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _userProfile = JsonConvert.DeserializeObject<Profile>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }

            return _userProfile;
        }

        /// <summary>
        /// Update User Profile By Id
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="token"></param>
        public static async Task UpdateUserProfileById(UserProfileDTO userProfile, string token)
        {
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(userProfile);

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
                    var response = await client.PostAsync("api/UserProfile/UpdateUserProfile/", content);
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
        /// Create UserProfile
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task CreateUserProfile(UserProfileDTO userProfile, string token)
        {

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(userProfile);

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
                    var response = await client.PostAsync("api/UserProfile/CreateUserProfile/", content);
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
        /// Update User Profile Image
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="stream"></param>
        /// <param name="file"></param>
        /// <param name="token"></param>
        public async static void UpdateUserProfileImage(string userProfileId, Stream stream, string file, string token)
        {
            
            string filePath = string.Empty;
            string uniqueFileName = null;
            string fullpath = "";
            string fileExt = ".png";
            string imagePath = "";

            uniqueFileName = userProfileId + fileExt;

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            _blobClient = storageAccount.CreateCloudBlobClient();
            _blobContainer = _blobClient.GetContainerReference(_blobContainerName);

            await _blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            try
            {
                BlobContinuationToken blobContinuationToken = null;
                do
                {
                    var blob = _blobContainer.GetBlockBlobReference($"{uniqueFileName}");
                    Task<bool> flag = blob.ExistsAsync();
                    if (flag.Result)
                    {

                        blob.DeleteAsync().Wait();
                        var blobx = _blobContainer.GetBlockBlobReference(uniqueFileName);
                        using (var streamFile = File.OpenRead(file))
                            blobx.UploadFromStreamAsync(streamFile).Wait();

                    }
                    else
                    {

                        var blobx = _blobContainer.GetBlockBlobReference(uniqueFileName);
                        using (var streamFile = File.OpenRead(file))
                            blobx.UploadFromStreamAsync(streamFile).Wait();

                    }

                }
                while (blobContinuationToken != null);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            fullpath = filePath;
            imagePath = uniqueFileName;

        }

        /// <summary>
        /// Update User Profile Rank By Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="token"></param>
        public static async void UpdateUserProfileRankById(UserProfileDTO userProfileId, string token)
        {

            UserProfileDTO _userProfile = new UserProfileDTO();

            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(userProfileId);

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
                    var response = await client.PostAsync("api/UserProfile/UpdateUserProfileRankById/", content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _userProfile = JsonConvert.DeserializeObject<UserProfileDTO>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }


        /// <summary>
        /// Is UserProfile Username Exist
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> UserProfileUsernameExist(string userName, string token)
        {

            bool _userProfile = false;

            string urlParameters = "?userName=" + userName;

            var clientBaseAddress = _api.Intial();
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Clear();
                client.BaseAddress = clientBaseAddress.BaseAddress;
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {

                    var response = await client.GetAsync("api/UserProfile/UserProfileUsernameExist" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _userProfile = JsonConvert.DeserializeObject<bool>(responseString);

                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return _userProfile;

        }

        /// <summary>
        /// Get Followers By UserProfileId
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<UserProfileDTO>> GetFollowersByUserProfileId(string userProfileId, string token)
        {
            List<UserProfileDTO> _userProfiles = new List<UserProfileDTO>();
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
                    var response = await client.GetAsync("api/UserProfile/GetFollowersByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _userProfiles = JsonConvert.DeserializeObject<List<UserProfileDTO>>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return _userProfiles;
        }

        /// <summary>
        /// Get Following By UserProfileId
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<List<UserProfileDTO>> GetFollowingByUserProfileId(string userProfileId, string token)
        {
            List<UserProfileDTO> _userProfiles = new List<UserProfileDTO>();
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
                    var response = await client.GetAsync("api/UserProfile/GetFollowingByUserProfileId/" + urlParameters);
                    var responseString = await response.Content.ReadAsStringAsync();
                    string responseUri = response.RequestMessage.RequestUri.ToString();

                    if (response.IsSuccessStatusCode)
                    {
                        _userProfiles = JsonConvert.DeserializeObject<List<UserProfileDTO>>(responseString);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return _userProfiles;
        }

    }
}
