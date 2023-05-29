
using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface ISquadRepository : IDisposable
    {
        Task<List<Squad>> GetSquads();
        Task<Squad> GetSquadById(string blogId);
        Task InsertSquad(Squad blog);
        Task DeleteSquad(string blogId);
        Task UpdateSquad(Squad blog);
        Task UpdateSquadImage(string blogId);
        Task<int> Save();
    }
}
