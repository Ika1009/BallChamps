using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface ICourtPrivateRunAvailabilityRepository : IDisposable
    {
        Task<List<CourtPrivateRunAvailability>> GetCourtPrivateRunAvailabilitys();
        Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityById(string Id);
        Task<CourtPrivateRunAvailability> GetCourtPrivateRunAvailabilityByCourtId(string Id);
        Task InsertCourtPrivateRunAvailability(CourtPrivateRunAvailability blog);
        Task DeleteCourtPrivateRunAvailability(string Id);
        Task UpdateCourtPrivateRunAvailability(CourtPrivateRunAvailability model);
        Task<int> Save();
    }
}
