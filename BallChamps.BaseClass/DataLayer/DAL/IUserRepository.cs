using BallChamps.Domain;
using DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer.DAL
{
    public interface IUserRepository : IDisposable
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetStaffUsers();
        Task<User> GetUserById(string userId);
        Task<User> VerifyEmail(string email);
        Task InsertUser(User user);
        Task UpdateUserResetCode(Task<User> user);
        Task DeleteUserById(string profileId);
        Task UpdateUser(User user);
        Task PasswordReset(User user);
        Task<int> Save();
    }
}
