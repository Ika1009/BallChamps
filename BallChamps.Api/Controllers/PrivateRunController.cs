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
    public class PrivateRunController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        private IPrivateRunRepository privateRunRepository;
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        /// <summary>
        /// Blog Controller Constructor
        /// </summary>
        /// <param name="blogContext"></param>
        public PrivateRunController(PrivateRunContext privateRunContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.privateRunRepository = new PrivateRunRepository(privateRunContext, Configuration);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }

        /// <summary>
        /// Get All PrivateRuns
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetPrivateRuns")]
        public async  Task<List<PrivateRun>> GetPrivateRuns()
        {
            try
            {
                return await privateRunRepository.GetPrivateRuns();
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
        [HttpGet("GetPrivateRunById")]
        //[Authorize]
        public async Task<PrivateRun> GetPrivateRunById(string privateRunId)
        {

            try
            {
                return await privateRunRepository.GetPrivateRunById(privateRunId);
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
        [HttpGet("GetPrivateRunByHostId")]
        //[Authorize]
        public async Task<PrivateRunDTO> GetPrivateRunByHostId(string userProfileId)
        {

            try
            {
                
                return await privateRunRepository.GetPrivateRunByHostId(userProfileId, ballchampsConnectionString);
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
        [HttpDelete("DeletePrivateRun")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeletePrivateRun(string privateRunId)
        {

            try
            {
                await privateRunRepository.DeletePrivateRun(privateRunId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeletePrivateRun");

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
        [HttpPost("CreatePrivateRun")]
        public void CreatePrivateRun([FromBody] PrivateRun privateRun)
        {
            try
            {

                privateRunRepository.InsertPrivateRun(privateRun);

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
        [HttpPost("UpdatePrivateRun")]
        public void UpdatePrivateRun([FromBody] PrivateRun privateRun)
        {
            try
            {
                privateRunRepository.UpdatePrivateRun(privateRun);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
