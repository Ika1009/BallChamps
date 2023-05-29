using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DAL
{
    public class UserSettingRepository : IUserSettingRepository, IDisposable
    {
        private UserSettingContext _context;

        /// <summary>
        /// UserSetting Repository
        /// </summary>
        /// <param name="context"></param>
        public UserSettingRepository(UserSettingContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Update UserSetting By Id Info
        /// </summary>
        /// <param name="blog"></param>
        public async Task UpdateUserSetting(UserSetting blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
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
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
