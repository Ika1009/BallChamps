
using BallChamps.Domain;

namespace BallChampsApi.Services
{
    /// <summary>
    /// IAuthenticate Service
    /// </summary>
    public interface IAuthenticateService
    {

       
        /// <summary>
        /// BallChamps Authenticate
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User BallChampsAuthenticate(string email, string password);


      

    }
}
