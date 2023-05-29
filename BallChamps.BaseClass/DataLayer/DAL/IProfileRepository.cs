using BallChamps.Domain;
using DataLayer.DTO;

namespace DataLayer.DAL
{
    public interface IProfileRepository : IDisposable
    {
        Task<List<Profile>> GetProfiles();
        Task<Profile> GetProfileById(string ProfileId);
        Task DeleteProfileById(string ProfileId);
        Task UpdateProfile(Profile Profile);
        Task InsertProfile(Profile Profile);

        Task<int> Save();

    }
}
