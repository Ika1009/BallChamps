using DataLayer;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BallChamps.Domain;
using BallChampsApi.Services;
using BallChampsApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace BallChampsApi.Services
{
    /// <summary>
    /// Authenticate Service
    /// </summary>
    public class AuthenticateService : IAuthenticateService
    {

        private readonly AppSettings _appSettings;
        /// <summary>
        /// AuthenticateService
        /// </summary>
        /// <param name="appSettings"></param>
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }



        /// <summary>
        /// BallChamps Authenticate
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User BallChampsAuthenticate(string email, string password)
        {
            //var user = users.SingleOrDefault(x => x.Email == email && x.Password == password);

            User? User = new User();

            using (var context = new BallChampsDBContext())
            {

                User = context.User.FirstOrDefault(x => x.Email == email && x.Password == password);
                if (User == null)
                {
                   // User = context.User.FirstOrDefault(x => x.UserName == email && x.Password == password);
                }

                //return null is user is not fould
                if (User == null)
                    return null;

                //If user is found
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Key);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, User.UserId.ToString()),
                        //new Claim(ClaimTypes.Role, user.Role, "Player")

                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                User.Token = tokenHandler.WriteToken(token);

                return User;
            }



        }





    }
    }

