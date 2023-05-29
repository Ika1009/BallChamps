using BallChamps.Domain;
using DataLayer.DTO;


namespace DataLayer.DAL
{
    public interface ICourtWaitingListRepository : IDisposable
    {      
        Task<List<CourtWaitingList>> GetCourtWaitingListByCourtId(string courtId);
        Task InsertPlayerToCourtWaitingList(CourtWaitingList courtWaitingList);
        Task InsertGuestPlayerToCourtWaitingList(string userName, string courtId);
        Task ClearCourtWaitingList(string courtId);
        Task RemovePlayerFromCourtWaitingList(string profileId);
        //Task UpdateCourtWaitingList(CourtWaitingList courtWaitingList);
        Task GetWaitingListCourtByProfileId(string profileId);
        Task UpdatePlayerPosition(string courtId, string profileId, int newPosition);
        Task<bool> IsProfileSignedUpAtCourt(string profile, string courtId);
        Task<bool> IsProfileSignedUpAtAnyCourt(string profile);
        Task<CourtWaitingList> GetCourtProfileIsSignedUpAt(string profile);
        Task UpdateCourtWaitingListById(CourtWaitingList courtWaitingList);
        Task<int> Save();

    }
}
