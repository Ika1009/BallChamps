using BallChamps.Domain;
using Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private UserContext _context;
        private ProfileContext _profileContext;
        string UserProfileImageDefaultURL;
        public IConfiguration Configuration { get; }


        /// <summary>
        /// User Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userProfileContext"></param>
        public UserRepository(UserContext context, ProfileContext profileContext)
        {

            this._profileContext = profileContext;
            this._context = context;
          
        }

        
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User> GetUserById(string userId)
        {

            User user = (from u in _context.User
                            where u.UserId == userId
                            select u).FirstOrDefault();

            return user;
        }

      

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<User> VerifyEmail(string email)
        {

            User user = (from u in _context.User
                         where u.Email == email
                         select u).FirstOrDefault();

            return user;
        }

        /// <summary>
        /// Get All User List
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetUsers()
        {

            return await _context.User.ToListAsync();
        }

        /// <summary>
        /// Insert User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task InsertUser(User user)
        {
            Profile profile = new Profile();

            try
            {
                var userId = Guid.NewGuid().ToString();
                var profileId = Guid.NewGuid().ToString();


                //User
                user.UserId = userId;
                user.LastLoginDate = DateTime.Now;
                user.SignUpDate = DateTime.Now;

                //Profile
                profile.ProfileId = profileId;
                profile.ProfileNumber = Functions.GenerateSixDigit();
                


                await _profileContext.Profile.AddAsync(profile);
                await _context.User.AddAsync(user);

                await Save();
               
            }
            catch (Exception ex)
            {
                
            }


        }

       
        /// <summary>
        /// Update User Info
        /// </summary>
        /// <param name="user"></param>
        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Update User Info
        /// </summary>
        /// <param name="user"></param>
        public async Task UpdateUserResetCode(Task<User> user)
        {
            
            _context.Entry(user).Property(x => x.Result.ResetCode).IsModified = true;

            Save();
            
        }

        /// <summary>
        /// Update User Info
        /// </summary>
        /// <param name="user"></param>
        public async Task PasswordReset(User user)
        {
            User model = _context.User.Single(x => x.UserId == user.UserId);
            model.Password = user.Password;

            _context.User.Update(model);
            Save();

        }

        /// <summary>
        /// Get Staff Users
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetStaffUsers()
        {
            Task<List<User>> user = (from u in _context.User
                                        where u.AccessLevel == "Staff"
                                       select u).ToListAsync();
            

            return user;
        }

     
        /// <summary>
        /// Delete userId
        /// </summary>
        /// <param name="userId"></param>
        public async Task DeleteUserById(string userId)
        {

            try
            {

                User? data = (from u in _context.User
                              where u.UserId == userId
                              select u).FirstOrDefault();

                _context.User.Remove(data);
                await Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

    }
}
