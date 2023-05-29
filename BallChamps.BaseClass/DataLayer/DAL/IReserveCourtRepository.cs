using BallChamps.Domain;
using DataLayer.DTO;

namespace DataLayer.DAL
{
    public interface IReserveCourtRepository : IDisposable
    {
        Task<List<ReserveCourt>> GetReserveCourts();
        Task<ReserveCourt> GetReserveCourtById(string Id);
        Task<ReserveCourtDTO> ReserveCourtByUserProfileId(string Id, string connStr);
        Task<List<ReserveCourtDTO>> GetCourtReserveCourtsByCourtId(string Id, string connStr);
        Task InsertReserveCourt(ReserveCourt model);
        Task DeleteReserveCourt(string Id);
        Task ApproveReserveCourt(string Id);
        Task CancelReserveCourt(string Id);
        Task UpdateReserveCourt(ReserveCourt model);
        Task<int> Save();
    }
}
