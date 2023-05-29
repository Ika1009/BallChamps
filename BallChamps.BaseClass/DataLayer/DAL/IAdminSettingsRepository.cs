using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IAdminSettingsRepository : IDisposable
    {
        Task<AdminSettings> GetInstallURLs();
        Task<AdminSettings> GetAdminSettingsById(string adminSettingsId);
        Task UpdateAdminSettings(AdminSettings adminSettings);
        Task<int> Save();

    }
}
