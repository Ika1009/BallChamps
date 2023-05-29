using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using System.Data;


namespace DataLayer.DAL
{
    public class FollowersRepository : IFollowersRepository, IDisposable
    {

        private FollowersContext _context;
        public FollowersRepository(FollowersContext context)
        {
            this._context = context;           
        }

        /// <summary>
        /// Unfollower
        /// </summary>
        /// <param name="followersId"></param>
        public async Task UnFollow(string FollowedByUserProfileId, string UserProfileId)
        {
            Followers followers = (from u in _context.Followers
                                   where u.UserProfileId == UserProfileId && u.FollowedByUserProfileId == FollowedByUserProfileId
                                   select u).FirstOrDefault();

            _context.Followers.Remove(followers);
            Save();

        }

        /// <summary>
        /// Get userProfile Followers Count
        /// </summary>
        /// <param name="UserProfileId"></param>
        /// <returns></returns>
        public async Task<int> FollowersCount(string UserProfileId)
        {
            var count = (from x in _context.Followers where x.UserProfileId == UserProfileId select x).Count();

                        return count;
        }

        /// <summary>
        /// Get userProfile Following Count
        /// </summary>
        /// <param name="UserProfileId"></param>
        /// <returns></returns>
        public async Task<int> FollowingCount(string UserProfileId)
        {
            var count = (from x in _context.Followers where x.FollowedByUserProfileId == UserProfileId select x).Count();

                        return count;
        }

        /// <summary>
        /// Get UserProfile followers list
        /// </summary>
        /// <param name="FollowerId"></param>
        /// <returns></returns>
        public async Task<List<FollowDTO>> GetCurrentFollowersUserProfiles(string UserProfileId, string connStr)
        {
            List<FollowDTO> courtWaitingListDTO = new List<FollowDTO>();
            try
            {
                
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetFollowersByUserProfileId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@userProfileId", UserProfileId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                FollowDTO courtWaitingListDTOTemp = new FollowDTO();

                                courtWaitingListDTOTemp.FollowedByUserProfileId = dr["FollowedByUserProfileId"].ToString();
                                courtWaitingListDTOTemp.ProfileUserName = dr["ProfileUserName"].ToString();
                                courtWaitingListDTOTemp.PlayerRank = dr["PlayerRank"].ToString();
                                courtWaitingListDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                courtWaitingListDTOTemp.City = dr["City"].ToString();
                                courtWaitingListDTOTemp.State = dr["State"].ToString();
                                courtWaitingListDTOTemp.Wins = dr["Wins"].ToString();
                                courtWaitingListDTOTemp.Losses = dr["Losses"].ToString();
                                courtWaitingListDTOTemp.WinPercentage = dr["WinPercentage"].ToString();
                                courtWaitingListDTOTemp.Position = dr["Position"].ToString();
                                courtWaitingListDTOTemp.Height = dr["Height"].ToString();
                                courtWaitingListDTOTemp.UserLevel = dr["UserLevel"].ToString();
                                courtWaitingListDTOTemp.StyleOfPlay = dr["StyleOfPlay"].ToString();
                                courtWaitingListDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                courtWaitingListDTOTemp.SkillTwo = dr["SkillTwo"].ToString();

                                courtWaitingListDTO.Add(courtWaitingListDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }


                return courtWaitingListDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get UserProfile followers list
        /// </summary>
        /// <param name="FollowerId"></param>
        /// <returns></returns>
        public async Task<List<FollowDTO>> GetCurrentFollowingUserProfiles(string UserProfileId, string connStr)
        {

            List<FollowDTO> courtWaitingListDTO = new List<FollowDTO>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetFollowingByUserProfileId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@userProfileId", UserProfileId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                FollowDTO courtWaitingListDTOTemp = new FollowDTO();

                                courtWaitingListDTOTemp.FollowedByUserProfileId = dr["FollowedByUserProfileId"].ToString();
                                courtWaitingListDTOTemp.ProfileUserName = dr["ProfileUserName"].ToString();
                                courtWaitingListDTOTemp.PlayerRank = dr["PlayerRank"].ToString();
                                courtWaitingListDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                courtWaitingListDTOTemp.City = dr["City"].ToString();
                                courtWaitingListDTOTemp.State = dr["State"].ToString();
                                courtWaitingListDTOTemp.Wins = dr["Wins"].ToString();
                                courtWaitingListDTOTemp.Losses = dr["Losses"].ToString();
                                courtWaitingListDTOTemp.WinPercentage = dr["WinPercentage"].ToString();
                                courtWaitingListDTOTemp.Position = dr["Position"].ToString();
                                courtWaitingListDTOTemp.Height = dr["Height"].ToString();
                                courtWaitingListDTOTemp.UserLevel = dr["UserLevel"].ToString();
                                courtWaitingListDTOTemp.StyleOfPlay = dr["StyleOfPlay"].ToString();
                                courtWaitingListDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                courtWaitingListDTOTemp.SkillTwo = dr["SkillTwo"].ToString();

                                courtWaitingListDTO.Add(courtWaitingListDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }


                return courtWaitingListDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Insert new following
        /// </summary>
        /// <param name="followers"></param>
        public async Task Follow(Followers followers)
        {
            followers.FollowersId = Guid.NewGuid().ToString();

            _context.Followers.Add(followers);
            Save();
        }

        /// <summary>
        /// IsFollowing UserProfile
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="followingUserProfileId"></param>
        /// <returns></returns>
        public async Task<bool> IsFollowingUserProfile(string userProfileId, string followingUserProfileId)
        {
            bool isFollowing = (from u in _context.Followers
                               where u.UserProfileId == userProfileId && u.FollowedByUserProfileId == followingUserProfileId
                                select u).Any();

            return isFollowing;
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
