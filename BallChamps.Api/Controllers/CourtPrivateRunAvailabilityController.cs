using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BallChampsApi.Controllers
{

    /// <summary>
    /// CourtPrivateRunAvailability Controller
    /// </summary>
    [Route("api/[controller]")] 
    public class CourtPrivateRunAvailabilityController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        private ICourtPrivateRunAvailabilityRepository courtPrivateRunAvailabilityRepository;
        /// <summary>
        /// Blog Controller Constructor
        /// </summary>
        /// <param name="blogContext"></param>
        public CourtPrivateRunAvailabilityController(CourtPrivateRunAvailabilityContext courtPrivateRunAvailabilityContext)
        {
            this.courtPrivateRunAvailabilityRepository = new CourtPrivateRunAvailabilityRepository(courtPrivateRunAvailabilityContext);
        }

        /// <summary>
        /// Get All CourtPrivateRunAvailabilitys
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCourtPrivateRunAvailabilitys")]
        public async  Task<List<CourtPrivateRunAvailability>> GetCourtPrivateRunAvailabilitys()
        {
            try
            {
                return await courtPrivateRunAvailabilityRepository.GetCourtPrivateRunAvailabilitys();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get CourtPrivateRunAvailability By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetCourtPrivateRunAvailabilityById")]
        //[Authorize]
        public async Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityById(string courtPrivateRunAvailabilityId)
        {

            try
            {
                return await courtPrivateRunAvailabilityRepository.GetCourtPrivateRunAvailabilityById(courtPrivateRunAvailabilityId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Delete CourtPrivateRunAvailability
        /// </summary>
        /// <param name="blogId"></param>
        [HttpDelete("DeleteCourtPrivateRunAvailability")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeleteCourtPrivateRunAvailability(string courtPrivateRunAvailabilityId)
        {

            try
            {
                await courtPrivateRunAvailabilityRepository.DeleteCourtPrivateRunAvailability(courtPrivateRunAvailabilityId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeleteCourtPrivateRunAvailability");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Create new CourtPrivateRunAvailability
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("CreateCourtPrivateRunAvailability")]
        public void CreateBlog([FromBody] CourtPrivateRunAvailability courtPrivateRunAvailability)
        {
            try
            {

                courtPrivateRunAvailabilityRepository.InsertCourtPrivateRunAvailability(courtPrivateRunAvailability);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update CourtPrivateRunAvailability Info
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("UpdateCourtPrivateRunAvailability")]
        public void UpdateCourtPrivateRunAvailability([FromBody] CourtPrivateRunAvailability courtPrivateRunAvailability)
        {
            try
            {
                courtPrivateRunAvailabilityRepository.UpdateCourtPrivateRunAvailability(courtPrivateRunAvailability);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
