using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallChamps.Domain;
using DataLayer.DTO;

namespace DataLayer.DAL
{
    public interface IAdminRepository : IDisposable
    {
        Task WinningTeamUpdateInfo(List<CourtWaitingList> winningTeam);
        Task LossingTeamUpdateInfo(List<CourtWaitingList> lossingTeam);
        Task<User> GetUserById_Admin(string userId);
        Task<List<User>>GetUsers_Admin();
        Task UpdateUserProfileById_Admin(Profile profile);
    }
}
