using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using DataLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallChampsApi.Controllers
{
    
    /// <summary>
    /// Blog Controller
    /// </summary>
    [Route("api/[controller]")]
    public class ReserveCourtController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        private IReserveCourtRepository reserveCourtRepository;
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        /// <summary>
        /// ReserveCourt Controller Constructor
        /// </summary>
        /// <param name="blogContext"></param>
        public ReserveCourtController(ReserveCourtContext reserveCourtContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.reserveCourtRepository = new ReserveCourtRepository(reserveCourtContext, Configuration);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }

        /// <summary>
        /// Get All ReserveCourts
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetReserveCourts")]
        public async  Task<List<ReserveCourt>> GetReserveCourts()
        {
            try
            {
                return await reserveCourtRepository.GetReserveCourts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        /// <summary>
        /// Get ReserveCourt By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("ReserveCourtByUserProfileId")]
        //[Authorize]
        public async Task<ReserveCourtDTO> ReserveCourtByUserProfileId(string userProfileId)
        {

            try
            {
                return await reserveCourtRepository.ReserveCourtByUserProfileId(userProfileId, ballchampsConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        /// <summary>
        /// Get ReserveCourt By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetReserveCourtById")]
        //[Authorize]
        public async Task<ReserveCourt> GetReserveCourtById(string reserveCourtId)
        {

            try
            {
                return await reserveCourtRepository.GetReserveCourtById(reserveCourtId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        /// <summary>
        /// Get CourtReserveCourtsByCourtId
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetCourtReserveCourtsByCourtId")]
        //[Authorize]
        public async Task<List<ReserveCourtDTO>> GetCourtReserveCourtsByCourtId(string courtId)
        {

            try
            {
                return await reserveCourtRepository.GetCourtReserveCourtsByCourtId(courtId, ballchampsConnectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Delete ReserveCourt
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("DeleteReserveCourt")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeleteReserveCourt(string reserveCourtId)
        {

            try
            {
                await reserveCourtRepository.DeleteReserveCourt(reserveCourtId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeleteReserveCourt");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }


        /// <summary>
        /// Delete ReserveCourt
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("ApproveReserveCourt")]
        //[Authorize]
        public async Task<HttpResponseMessage> ApproveReserveCourt(string reserveCourtId)
        {

            try
            {
                await reserveCourtRepository.ApproveReserveCourt(reserveCourtId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "ApproveReserveCourt");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Delete ReserveCourt
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("CancelReserveCourt")]
        //[Authorize]
        public async Task<HttpResponseMessage> CancelReserveCourt(string reserveCourtId)
        {

            try
            {
                await reserveCourtRepository.CancelReserveCourt(reserveCourtId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "ApproveReserveCourt");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Create new ReserveCourt
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("InsertReserveCourt")]
        public void CreateReserveCourt([FromBody] ReserveCourt model)
        {
            try
            {

                reserveCourtRepository.InsertReserveCourt(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update ReserveCourt Info
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("UpdateReserveCourt")]
        public void UpdateBlog([FromBody] ReserveCourt model)
        {
            try
            {
                reserveCourtRepository.UpdateReserveCourt(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
