using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IPlayerHistoryRepository : IDisposable
    {
        Task<List<PlayerHistory>> GetPlayerHistorys();
        Task<PlayerHistory> GetPlayerHistoryById(string Id);
        Task InsertPlayerHistory(PlayerHistory model);
        Task DeletePlayerHistory(string Id);
        Task UpdatePlayerHistory(PlayerHistory model);
        Task<int> Save();
    }
}
