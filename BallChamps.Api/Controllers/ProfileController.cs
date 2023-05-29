using System.Net;
using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// UserProfile Controller
    /// </summary>
    [Route("api/[controller]")]
    public class ProfileController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        static HttpClient client = new HttpClient();
        
       
       
        private IProfileRepository profileRepository;

        /// <summary>
        /// Profile Controller
        /// </summary>
        /// <param name="userProfileContext"></param>
        public ProfileController(ProfileContext profileContext)
        {
            
           
            this.profileRepository = new ProfileRepository(profileContext);
           
            
        }

        /// <summary>
        /// Get User Profiles
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("GetProfiles")]
        //[Authorize]
        public async Task<List<Profile>> GetUserProfiles()
        {
            try
            {
                var data = await profileRepository.GetProfiles();
                return data;

            }
            catch(Exception ex)
            {
                
            }

            return null;

        }

        /// <summary>
        /// Get Profile By Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        /// 

        [HttpGet("GetProfileById")]
        //[Authorize]
        public async Task<Profile> GetProfileById(string profileId)
        {
            try
            {
                return await profileRepository.GetProfileById(profileId);
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        /// <summary>
        /// Delete UserProfile By Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("DeleteUserProfileById")]
        public async Task<HttpResponseMessage> DeleteUserProfileById(string profileId)
        {
            try
            {
                await profileRepository.DeleteProfileById(profileId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeleteProfileById");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Update Profile
        /// </summary>
        /// <param name="_userProfileList"></param>
        //[Authorize]
        [HttpPost("UpdateProfile")]
        public async Task UpdateProfile([FromBody] Profile profileList)
        {

            try
            {
                await profileRepository.UpdateProfile(profileList);
            }
            catch
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);

            }

        }

        /// <summary>
        /// GetFollowersByUserProfileId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFollowersByProfileId")]
        //[Authorize]
        public async Task<List<Profile>> GetFollowersByProfileId(string profileId)
        {

            try
            {
               // return await profileRepository.GetFollowersByProfileId(profileId);
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

        /// <summary>
        /// GetFollowersByUserProfileId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFollowingByUserProfileId")]
        //[Authorize]
        public async Task<List<Profile>> GetFollowingByProfileId(string profileId)
        {

            try
            {
                //return await profileRepository.GetFollowingByProfileId(profileId);
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }

    }

}


