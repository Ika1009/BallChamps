using BallChamps.Domain;
using BallChampsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// </summary>
    [Route("api/[controller]")]   
    public class AuthenticationController : Controller
    {
        private IAuthenticateService _authenticateService;

        /// <summary>
        /// Authentication Controller
        /// </summary>
        /// <param name="authenticateService"></param>
        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

  

        /// <summary>
        /// Authenticate BallChamps User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("BallChampsAuthenticate")]
        public ActionResult BallChampsAuthenticate([FromBody] User model)
        {
            var userResult = _authenticateService.BallChampsAuthenticate(model.Email, model.Password);

            if (userResult == null)
                return BadRequest(new { message = "Email or Password is incorrect" });

            return Ok(userResult);
        }

       

    }
}
