using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class AdminSettingsRepository : IAdminSettingsRepository, IDisposable
    {
        private AdminSettingsContext _context;

        /// <summary>
        /// AdminSettings Repository
        /// </summary>
        /// <param name="context"></param>
        public AdminSettingsRepository(AdminSettingsContext context)
        {
            this._context = context;
            
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
        /// Get AdminSettings By ID
        /// </summary>
        /// <param name="adminSettingsId"></param>
        /// <returns></returns>
        public async Task<AdminSettings> GetAdminSettingsById(string adminSettingsId)
        {

            AdminSettings adminSettings = (from u in _context.AdminSettings
                         where u.AdminSettingsId == adminSettingsId
                         select u).FirstOrDefault();

            return adminSettings;
        }

        /// <summary>
        /// Get Instal lURLs
        /// </summary>
        /// <returns></returns>
        public async Task<AdminSettings> GetInstallURLs()
        {
            AdminSettings adminSettings = _context.AdminSettings.Where(a => a.AdminSettingsId == "001231234").Select(a => new AdminSettings
            { 
                IOSInstallURL = a.IOSInstallURL,
                AndroidInstallURL = a.AndroidInstallURL,
            }).FirstOrDefault();

            return adminSettings;
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
        /// Update AdminSettings Info
        /// </summary>
        /// <param name="adminSettings"></param>
        public async Task UpdateAdminSettings(AdminSettings adminSettings)
        {
            _context.Entry(adminSettings).State = EntityState.Modified;
            Save();
        }

    }
}
