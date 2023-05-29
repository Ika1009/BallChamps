using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface ICampaignRepository : IDisposable
    {
        Task<List<Campaign>> GetCampaigns();
        Task<Campaign> GetCampaignById(string campaignId);
        Task InsertCampaign(Campaign campaign);
        Task DeleteCampaign(string campaignId);
        Task UpdateCampaign(Campaign campaign);
        Task<int> Save();
    }
}
