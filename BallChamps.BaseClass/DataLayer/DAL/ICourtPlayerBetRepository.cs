using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface ICourtPlayerBetRepository : IDisposable
    {
        Task UpdateCourtPlayerBetByCourtId(CourtPlayerBet courtBet);
        Task<List<CourtPlayerBet>> GetCourtPlayerBetByCourtId(string courtId);
        Task<int> Save();
    }
}
