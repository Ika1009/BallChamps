using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using DataLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace BallChampsApi.Controllers
{

    /// <summary>
    /// PrivateRun Controller
    /// </summary>
    [Route("api/[controller]")]
    public class PlayerInviteController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        private IPlayerInviteRepository playerInviteRepository;
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Blog Controller Constructor
        /// </summary>
        /// <param name="blogContext"></param>
        public PlayerInviteController(PlayerInviteContext playerInviteContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.playerInviteRepository = new PlayerInviteRepository(playerInviteContext, Configuration);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }

        /// <summary>
        /// Get All PrivateRuns
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlayerInvites")]
        public async  Task<List<PlayerInvite>> GetPlayerInvites()
        {
            try
            {
                return await playerInviteRepository.GetPlayerInvites();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get Player Invites For UserProfileId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlayerInvitesForUserProfileId")]
        public async Task<List<PlayerInviteDTO>> GetPlayerInvitesForUserProfileId(string reserveCourtId)
        {
            try
            {
                return await playerInviteRepository.GetPlayerInvitesForUserProfileId(reserveCourtId, ballchampsConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// GetPlayerInvitesByUserProfileId
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPlayerInvitesByUserProfileId")]
        public async Task<List<PlayerInviteDTO>> GetPlayerInvitesByUserProfileId(string userProfileId)
        {
            try
            {
                return await playerInviteRepository.GetPlayerInvitesByUserProfileId(userProfileId, ballchampsConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetPlayerInviteById")]
        //[Authorize]
        public async Task<PlayerInvite> GetPlayerInviteById(string privateRunId)
        {

            try
            {
                return await playerInviteRepository.GetPlayerInviteById(privateRunId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetPlayersInvitesByReserveCourtId")]
        //[Authorize]
        public async Task<List<UserProfileDTO>> GetPlayersInvitesByReserveCourtId(string reserveCourtId)
        {

            try
            {
                
                return await playerInviteRepository.GetPlayersInvitesByReserveCourtId(reserveCourtId, ballchampsConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("DeletePlayerInvite")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeletePlayerInvite(string reserveCourtId, string userProfileId)
        {

            try
            {
                await playerInviteRepository.DeletePlayerInvite(reserveCourtId, userProfileId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeletePlayerInvite");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Create new PrivateRun
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("InsertPlayerInvite")]
        public void CreatePlayerInvite([FromBody] PlayerInvite playerInvite)
        {
            try
            {

                playerInviteRepository.InsertPlayerInvite(playerInvite);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update PrivateRun Info
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("UpdatePlayerInvite")]
        public void UpdatePlayerInvite([FromBody] PlayerInvite playerInvite)
        {
            try
            {
                playerInviteRepository.UpdatePlayerInvite(playerInvite);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        /// <summary>
        /// Confirmed PlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("ConfirmedPlayerInvite")]
        //[Authorize]
        public async Task<int> ConfirmedPlayerInvite(string reserveCourtId)
        {

            try
            {

                return await playerInviteRepository.ConfirmedPlayerInvite(reserveCourtId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 0;
        }

        /// <summary>
        /// DeclinedPlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("DeclinedPlayerInvite")]
        //[Authorize]
        public async Task<int> DeclinedPlayerInvite(string reserveCourtId)
        {

            try
            {

                return await playerInviteRepository.DeclinedPlayerInvite(reserveCourtId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 0;
        }

        /// <summary>
        /// DeclinedPlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("PendingPlayerInvite")]
        //[Authorize]
        public async Task<int> PendingPlayerInvite(string reserveCourtId)
        {

            try
            {

                return await playerInviteRepository.PendingPlayerInvite(reserveCourtId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 0;
        }

        /// <summary>
        /// DeclinedPlayerInvite
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("InvitedPlayerInvite")]
        //[Authorize]
        public async Task<int> InvitedPlayerInvite(string reserveCourtId)
        {

            try
            {

                return await playerInviteRepository.InvitedPlayerInvite(reserveCourtId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return 0;
        }
    }
}
