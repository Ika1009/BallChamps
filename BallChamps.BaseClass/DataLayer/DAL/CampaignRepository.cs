using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataLayer.DAL
{
    public class CampaignRepository : ICampaignRepository, IDisposable
    {
        public IConfiguration Configuration { get; }
        private CampaignContext _context;
        string CampaignDefaultImageURL;

        /// <summary>
        /// Campaign Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public CampaignRepository(CampaignContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;
            this.CampaignDefaultImageURL = Configuration.GetSection("campaignImageDefaultURL:DefaultURL").Value;

        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Campaign By Id
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public async Task<Campaign> GetCampaignById(string campaignId)
        {

            Campaign model = (from u in _context.Campaign
                              where u.CampaignId == campaignId
                              select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get Campaigns
        /// </summary>
        /// <returns></returns>
        public async Task<List<Campaign>> GetCampaigns()
        {
            return await _context.Campaign.ToListAsync();
        }

        /// <summary>
        /// Insert Campaign
        /// </summary>
        /// <param name="campaign"></param>
        public async Task InsertCampaign(Campaign campaign)
        {
            campaign.CampaignId = Guid.NewGuid().ToString();
            campaign.CampaignNumber = Common.Functions.GenerateSixDigit();
            campaign.ImagePath = CampaignDefaultImageURL + campaign.CampaignId + ".png";
            campaign.ObjType = "Campaign";

            _context.Campaign.AddAsync(campaign);
            Save();
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Campaign Info
        /// </summary>
        /// <param name="campaign"></param>
        public async Task UpdateCampaign(Campaign campaign)
        {
            _context.Entry(campaign).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Delete Campaign
        /// </summary>
        /// <param name="campaignId"></param>
        public async Task DeleteCampaign(string campaignId)
        {
            Campaign model = (from u in _context.Campaign
                              where u.CampaignId == campaignId
                              select u).FirstOrDefault();

            _context.Campaign.Remove(model);
            Save();

        }
    }
}
