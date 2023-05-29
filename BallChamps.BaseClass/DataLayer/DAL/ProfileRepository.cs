using BallChamps.Domain;
using BusinessLogic;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace DataLayer.DAL
{
    public class ProfileRepository : IProfileRepository, IDisposable
    {

        #region Variables
        public IConfiguration Configuration { get; }
        private ProfileContext _context;
        private WinPercentage _winpercentage = new WinPercentage();
        string UserProfileDefaultImagePath;
        #endregion

        /// <summary>
        /// UserProfileRepository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public ProfileRepository(ProfileContext context)
        {
            
            this._context = context;         
         
        }


        public async Task InsertProfile(Profile profile)
        {

            await _context.Profile.AddAsync(profile);

            await Save();
        }

        /// <summary>
        /// Get UserProfile By Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<Profile> GetProfileById(string profileId)
        {

            
            try
            {

                Profile? profile = (from u in _context.Profile
                                 where u.ProfileId == profileId
                              select u).FirstOrDefault();

                return profile;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;

        }

       
       

        /// <summary>
        /// Get UserProfiles
        /// </summary>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<Profile>> GetProfiles()
        {

            try
            {

                return await _context.Profile.ToListAsync();
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
        /// Update UserProfile
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task UpdateProfile(Profile profile)
        {

            try
            {


                var existingPost = _context.Profile.Where(s => s.ProfileId == profile.ProfileId).FirstOrDefault<Profile>();

                if (existingPost != null)
                {
                    existingPost.FirstName = profile.FirstName;
                    existingPost.LastName = profile.LastName;
                    existingPost.City = profile.City;
                    existingPost.State = profile.State;
                    existingPost.Zip = profile.Zip;
                    existingPost.Age = profile.Age;
                    existingPost.Sex = profile.Sex;
                    existingPost.Height = profile.Height;
                    existingPost.Position = profile.Position;
                    existingPost.SkillOne = profile.SkillOne;
                    existingPost.SkillTwo = profile.SkillTwo;
                    existingPost.StyleOfPlay = profile.StyleOfPlay;
                   

                    await Save();
                }
                else
                {

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

               
            }

        
        }

        /// <summary>
        /// Delete UserProfile By Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        public async Task DeleteProfileById(string profileId)
        {
            Profile profile = (from u in _context.Profile
                                       where u.ProfileId == profileId
                               select u).FirstOrDefault();

            _context.Profile.Remove(profile);
            Save();
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
