using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IUserSettingRepository : IDisposable
    {

        Task UpdateUserSetting(UserSetting model);
        Task<int> Save();
    }
}
