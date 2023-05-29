using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;


namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Campaign Controller
    /// </summary>
    [Route("api/[controller]")]
    public class CampaignController : Controller
    {
        public IConfiguration Configuration { get; }
        private ICampaignRepository campaignRepository;

        /// <summary>
        /// Campaign Controller Constructor
        /// </summary>
        /// <param name="campaignContext"></param>
        public CampaignController(CampaignContext campaignContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.campaignRepository = new CampaignRepository(campaignContext, configuration);
        }

        /// <summary>
        /// Get All Campaigns
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCampaigns")]
        public async  Task<List<Campaign>> GetCampaigns()
        {
            try
            {
                return await campaignRepository.GetCampaigns();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Insert Campaign
        /// </summary>
        /// <param name="court"></param>
        //[Authorize]
        [HttpPost("InsertCampaign")]
        public async Task InsertCampaign([FromBody] Campaign campaign)
        {
            try
            {

                await campaignRepository.InsertCampaign(campaign);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Get Campaign By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetCampaignById")]
        //[Authorize]
        public async Task<Campaign> GetCampaignById(string campaignId)
        {

            try
            {
                return await campaignRepository.GetCampaignById(campaignId);
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
        [HttpPost("DeleteCampaign")]
        //[Authorize]
        public void DeleteCampaign(string campaignId)
        {

            try
            {
                campaignRepository.DeleteCampaign(campaignId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        /// <summary>
        /// Create new Blog
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("CreateCampaign")]
        public void CreateCampaign([FromBody] Campaign campaign)
        {
            try
            {

                campaignRepository.InsertCampaign(campaign);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update Blog Info
        /// </summary>
        /// <param name="blog"></param>
        //[Authorize]
        [HttpPost("UpdateCampaign")]
        public void UpdateCampaign([FromBody] Campaign campaign)
        {
            try
            {
                campaignRepository.UpdateCampaign(campaign);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
