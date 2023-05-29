using BallChamps.Domain;
using DataLayer.DTO;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IPlayerInviteRepository : IDisposable
    {
        Task<List<PlayerInvite>> GetPlayerInvites();
        Task<List<UserProfileDTO>> GetPlayerInvitesByPrivateRunId(string privateRunId, string connStr);
        Task<List<UserProfileDTO>> GetInvitedPlayers(string reserveCourtId, string connStr);
        Task<List<UserProfileDTO>> GetPlayersInvitesByReserveCourtId(string reserveCourtId, string connStr);
        Task<PlayerInvite> GetPlayerInviteById(string Id);
        Task<List<PlayerInviteDTO>> GetPlayerInvitesForUserProfileId(string Id, string connStr);
        Task<List<PlayerInviteDTO>> GetPlayerInvitesByUserProfileId(string Id, string connStr);
        Task InsertPlayerInvite(PlayerInvite model);
        Task DeletePlayerInvite(string ReserveCourtId, string UserProfileId);
        Task UpdatePlayerInvite(PlayerInvite model);
        Task <int> ConfirmedPlayerInvite(string reserveCourtId);
        Task<int> DeclinedPlayerInvite(string reserveCourtId);
        Task<int> PendingPlayerInvite(string reserveCourtId);
        Task<int> InvitedPlayerInvite(string reserveCourtId);
        Task<int> Save();
    }
}
