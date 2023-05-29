using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;
using WebMatrix.WebData;
using Newtonsoft.Json.Linq;
using BallChampsBaseClass.Common.Model;
using BallChamps.Messaging;
using Microsoft.Extensions.Configuration;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        
        private IUserRepository userRepository;

        /// <summary>
        /// User Controller
        /// </summary>
        /// <param name="bC_UserContext"></param>
        /// <param name="userProfileContext"></param>
        public UserController(UserContext userContext, ProfileContext profileContext)
        {

            
            this.userRepository = new UserRepository(userContext, profileContext);
           
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUsers")]
        //[Authorize]
        public async Task<List<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }

        /// <summary>
        /// Get UserId
        /// </summary>
        /// <param name="bC_UserId"></param>
        /// <returns></returns>
        [HttpGet("GetUserId")]
        //[Authorize]
        public async Task<User> GetUserId(string userId)
        {
            try
            {
                return await userRepository.GetUserById(userId);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


      

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="user"></param>
        [HttpPost("CreateUser")]
        public void CreateUser([FromBody] User user)
        {

            try
            {
                var result  = userRepository.InsertUser(user);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpDelete("DeleteUserById")]
        public HttpResponseMessage DeleteUserById(string userId)
        {
            return null;
        }


        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        //[Authorize]
        [HttpPost("UpdateUser")]
        public void UpdateUser([FromBody] User user)
        {

            try
            {
                userRepository.UpdateUser(user);

            }
            catch
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);

            }

        }

        /// <summary>
        /// Delete User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost("ResetPasswordLinkEmail")]
        public async Task<string> ResetPasswordLinkEmail(string email)
        {
            Messaging messaging = new Messaging(null);

            try
            {
               var user = userRepository.VerifyEmail(email);

                if(user == null)
                {
                    return "User not found";
                }
                else
                {

                    string resetCode = Guid.NewGuid().ToString();

                    PasswordReset passwordReset = new PasswordReset();
                    passwordReset.user = user;
                    passwordReset.Link = "test";
                    passwordReset.ResetURL = "/User/ForgotPassword/" + resetCode;
                    passwordReset.Token = "";
                    passwordReset.ResetCode = resetCode;

                    messaging.SendPasswordResetLinkEmail(passwordReset);

                    return "Send Email";
                }
            }
            catch(Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);

            }

            return null;

        }

        private string CreateRandomToken()
        {
           
                return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));

        }

        /// <summary>
        /// UserProfile Username Exist
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("UserProfileUsernameExist")]
        //[Authorize]
        public async Task<bool> ProfileUsernameExist(string userName)
        {
            bool result = false;

            try
            {
               // result = await userRepositoryUsernameExist(userName);
               

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

    }
}
