using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using DataLayer.DTO;
using Microsoft.AspNetCore.Mvc;


namespace BallChampsApi.Controllers
{
    /// <summary>
    /// GameHistory Controller
    /// </summary>
    [Route("api/[controller]")]
    public class GameHistoryController : Controller
    {
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        private IGameHistoryRepository gameHistoryRepository;

        /// <summary>
        /// GameHistory Controller
        /// </summary>
        /// <param name="gameHistoryContext"></param>
        public GameHistoryController(GameHistoryContext gameHistoryContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.gameHistoryRepository = new GameHistoryRepository(gameHistoryContext, configuration);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");

        }

        /// <summary>
        /// Get GameHistory By UserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [HttpGet("GetGameHistoryByUserProfileId")]
        
        public async Task<List<PlayerHistoryDTO>> GetGameHistoryByUserProfileId(string userProfileId )
        {

            try
            {

                return await gameHistoryRepository.GetGameHistoryByUserProfileId(userProfileId, ballchampsConnectionString);

            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }

        /// <summary>
        /// Get GameHistory By GameNumber 
        /// </summary>
        /// <param name="gameNumber"></param>
        /// <returns></returns>
        [HttpGet("GetGameHistoryByGameNumber")]

        public async Task<List<GameHistoryDTO>> GetGameHistoryByGameNumber(string gameNumber)
        {

            try
            {

                return await gameHistoryRepository.GetGameHistoryByGameNumber(gameNumber, ballchampsConnectionString);

            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }

        /// <summary>
        /// Create GameHistory
        /// </summary>
        /// <param name="gameHistory"></param>
        //[Authorize]
        [HttpPost("CreateGameHistory")]
        public async Task CreateGameHistory([FromBody] GameHistory gameHistory, List<PlayerHistory> playerHistoryList)
        {
            try
            {

                await gameHistoryRepository.InsertGameHistory(gameHistory, playerHistoryList, ballchampsConnectionString);

            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }


    }
}
