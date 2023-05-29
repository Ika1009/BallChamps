using BallChamps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface ICourtSignUpRepository : IDisposable
    {
        Task<List<CourtWaitingList>> GetCourtSignUps();
        Task<CourtWaitingList> GetCourtSignUpByID(string courtSignUpId);
        Task InsertCourtSignUp(CourtWaitingList courtSignUp);
        Task DeleteCourtSignUp(string courtSignUpId);
        Task UpdateCourtSignUp(CourtWaitingList courtSignUp);
        Task SignUpUser(CourtWaitingList courtSignUp);
        Task<int> Save();
    }
}
