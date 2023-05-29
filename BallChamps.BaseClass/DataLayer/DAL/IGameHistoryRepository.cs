using BallChamps.Domain;
using DataLayer.DTO;

namespace DataLayer.DAL
{
    public interface IGameHistoryRepository : IDisposable
    {

        Task<List<PlayerHistoryDTO>> GetGameHistoryByUserProfileId(string userProfileId, string connStr);
        Task InsertGameHistory(GameHistory gameHistory, List<PlayerHistory> playerHistory, string connStr);
        Task<List<GameHistoryDTO>> GetGameHistoryByGameNumber(string gameNumber, string connStr);
        Task<int> Save();

    }
}
