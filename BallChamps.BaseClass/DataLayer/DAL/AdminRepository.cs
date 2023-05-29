using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataLayer.DAL
{
    public class AdminRepository : IAdminRepository, IDisposable
    {

        private CourtWaitingListContext _context;
        private ProfileContext _contextProfile;
        private UserContext _contextUser;


        public AdminRepository(CourtWaitingListContext context, ProfileContext contextProfile, UserContext contextUser)
        {

            this._context = context;
            this._contextProfile = contextProfile;
            this._contextUser = contextUser;

        }

        /// <summary>
        /// Lossing Team Update Info
        /// </summary>
        /// <param name="lossingTeam"></param>
        /// <returns></returns>
        public async Task LossingTeamUpdateInfo(List<CourtWaitingList> lossingTeam)
        {
            foreach (var item in lossingTeam)
            {

                var player = (from u in _contextProfile.Profile
                              where u.ProfileId == item.ProfileId
                              select u).FirstOrDefault();

                player.Losses = player.Losses + 1;
                _contextProfile.Profile.Update(player);

                //Remove from courtlist
                var record = (from u in _context.CourtWaitingList
                              where u.ProfileId == item.ProfileId && u.CourtId == item.CourtId
                              select u).FirstOrDefault();

                _context.CourtWaitingList.Remove(record);


                Save();

            }
        }

        /// <summary>
        /// Winning Team Update Info
        /// </summary>
        /// <param name="winningTeam"></param>
        /// <returns></returns>
        public async Task WinningTeamUpdateInfo(List<CourtWaitingList> winningTeam)
        {
            foreach (var item in winningTeam)
            {
                var player = (from u in _contextProfile.Profile
                              where u.ProfileId == item.ProfileId
                              select u).FirstOrDefault();

                player.Points = player.Points + 2;
                player.Wins = player.Wins + 1;

                _contextProfile.Profile.Update(player);
                Save();

            }


        }

        /// <summary>
        /// Update UserProfile By Id_Admin
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public async Task UpdateUserProfileById_Admin(Profile profile)
        {
            
      
            _contextProfile.SaveChangesAsync();
            


        }

        /// <summary>
        /// Get User By Id_Admin
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetUserById_Admin(string userId)

        {
           
            try
            {
                
             


                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get Users_Admin
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<User>> GetUsers_Admin()
        {
            
            try
            {
                
            


                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            return null;


        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
