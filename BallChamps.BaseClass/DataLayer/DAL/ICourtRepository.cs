using BallChamps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface ICourtRepository : IDisposable
    {
        Task<List<Court>> GetCourts();
        Task<Court> GetCourtById(string courtId);
        Task InsertCourt(Court courts);
        Task DeleteCourt(string courtId);
        Task UpdateCourt(Court court);
        Task<bool> CourtNameExist(string courtName);
        Task<int> Save();
    }
}
