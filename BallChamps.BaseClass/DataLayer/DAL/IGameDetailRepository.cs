using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IGameDetailRepository : IDisposable
    {
        Task<List<GameDetail>> GetGameDetails();
        Task<GameDetail> GetGameDetailById(string gameDetailId);
        Task<List<GameDetail>> GetGameDetailByUserProfileId(string userProfileId);
        Task InsertGameDetail(GameDetail gameDetail);
        Task DeleteGameDetail(string gameDetailId);
        Task UpdateGameDetail(GameDetail gameDetail);       
        Task<int> Save();

    }
}
