using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Followers Controller
    /// </summary>
    [Route("api/[controller]")]
    //[Authorize]
    public class FollowersController : Controller
    {
        string ballchampsConnectionString;
        private IFollowersRepository followersRepository;
        //private IUserProfileRepository userProfileRepository;
        public IConfiguration Configuration { get; }


        /// <summary>
        /// Followers Controller
        /// </summary>
        /// <param name="followersContext"></param>
        /// <param name="userProfileContext"></param>
        public FollowersController(FollowersContext followersContext,  IConfiguration configuration)
        {
            Configuration = configuration;
            //this.userProfileRepository = new UserProfileRepository(userProfileContext,null);
            this.followersRepository = new FollowersRepository(followersContext);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }



        /// <summary>
        ///  Get the userProfiles of Users that the current user if is Following
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        // [Authorize]
        [HttpGet("GetCurrentFollowingUserProfiles")]
        public async Task<List<FollowDTO>> GetCurrentFollowingUserProfiles(string userProfileId)
        {
             List<FollowDTO> userProfileList = new List<FollowDTO>();
            try
            {
                var list = await followersRepository.GetCurrentFollowingUserProfiles(userProfileId, ballchampsConnectionString);

                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        /// <summary>
        ///  Get the userProfiles of Users that are following current user
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        // [Authorize]
        [HttpGet("GetCurrentFollowersUserProfiles")]
        public async Task<List<FollowDTO>> GetCurrentFollowersUserProfiles(string userProfileId)
        {
            List<FollowDTO> userProfileList = new List<FollowDTO>();
            try
            {
                var list = await followersRepository.GetCurrentFollowersUserProfiles(userProfileId, ballchampsConnectionString);

               
                return list;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        ///  Unfollow user
        /// </summary>
        /// <param name="followedByUserProfileId"></param>
        /// <param name="userProfileId"></param>
        [HttpPost("UnFollow")]
        public void UnFollow(string followedByUserProfileId, string userProfileId)
        {

            try
            {
                followersRepository.UnFollow(followedByUserProfileId, userProfileId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        /// <summary>
        /// Create Follower
        /// </summary>
        /// <param name="followers"></param>
        [HttpPost("Follow")]
        public void Follow([FromBody] Followers followers)
        {

            try
            {

                followersRepository.Follow(followers);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }


        /// <summary>
        /// Followers Count
        /// </summary>
        /// <param name="userProfileId"></param>
        //[Authorize]
        [HttpGet("FollowersCount")]
        public async Task<int> FollowersCount(string userProfileId)
        {
            try
            {
              return await followersRepository.FollowersCount(userProfileId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 00000;
        }

        /// <summary>
        /// Following Count
        /// </summary>
        /// <param name="userProfileId"></param>
        [HttpGet("FollowingCount")]
        public async Task<int> FollowingCount(string userProfileId)
        {
            try
            {
                return await followersRepository.FollowingCount(userProfileId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 00000;
        }

        /// <summary>
        /// IsFollowingUserProfile
        /// </summary>
        /// <param name="followingUserProfileId"></param>
        /// <param name="userProfileId"></param>
        [HttpGet("IsFollowingUserProfile")]
        public async Task<bool> IsFollowingUserProfile(string followingUserProfileId, string userProfileId)
        {

            return await followersRepository.IsFollowingUserProfile(userProfileId,followingUserProfileId);


        }
    }
}
