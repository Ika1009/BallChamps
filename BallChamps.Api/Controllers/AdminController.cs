using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Admin Controller
    /// </summary>
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        string ballchampsConnectionString;
        private IAdminRepository adminRepository;
        private IProfileRepository userProfilRepository;



        /// <summary>
        /// Admin Controller
        /// </summary>
        /// <param name="bC_UserContext"></param>
        /// <param name="userProfileContext"></param>
        public AdminController(CourtWaitingListContext courtWaitingContext, UserContext userContext, ProfileContext userProfileContext)
        {

            this.adminRepository = new AdminRepository(courtWaitingContext, userProfileContext, userContext);
            this.userProfilRepository = new ProfileRepository(userProfileContext);
 
        }


        ///// <summary>
        ///// Admin Create User
        ///// </summary>
        ///// <param name="_bC_User"></param>
        //[HttpPost("AdminCreateUser")]
        //public void CreateUser([FromBody] User user)
        //{
        //    UserProfile userProfile = new UserProfile();

        //    userProfile.ProfileUserName = user.UserName;

        //    try
        //    {
        //        adminRepository.InsertUser(user);

        //    }
        //    catch (Exception ex)
        //    {
        //        var x = ex;
        //    }

        //}


        /// <summary>
        /// Get All GetUser_Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers_Admin")]
        public async Task<List<User>> GetUsers_Admin()
        {
            try
            {
                var data = await adminRepository.GetUsers_Admin();

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Admin Create User
        /// </summary>
        /// <param name="userId"></param>
        [HttpGet("GetUserById_Admin")]
        public async Task<User> GetUserById_Admin(string userId)
        {

            try
            {
                return await adminRepository.GetUserById_Admin(userId);

            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }


        /// <summary>
        /// Admin Delete User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete("AdminDeleteUserById")]
        public HttpResponseMessage DeleteUserById(string userId)
        {
            return null;
        }


        /// <summary>
        /// Admin Update User
        /// </summary>
        /// <param name="user"></param>
        //[Authorize]
        [HttpPost("UpdateProfileById_Admin")]
        public void UpdateProfileById_Admin([FromBody] Profile profile)
        {

            try
            {
                //adminRepository.UpdateProfileById_Admin(profile);

            }
            catch
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);

            }

        }

    }
}
