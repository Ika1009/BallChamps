using BallChamps.Domain;
using BusinessLogic;
using Common;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    public class PlayerInviteRepository : IPlayerInviteRepository, IDisposable
    {
        private PlayerInviteContext _context;
        private WinPercentage _winpercentage = new WinPercentage();
        string UserProfileDefaultImagePath;
        public IConfiguration Configuration { get; }

        /// <summary>
        /// PlayerInvite Repository
        /// </summary>
        /// <param name="context"></param>
        public PlayerInviteRepository(PlayerInviteContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;
            this.UserProfileDefaultImagePath = Configuration.GetSection("ResourcesPath:UserProfileDefaultImagePath").Value;
        }

        /// <summary>
        /// Get PlayerInvite By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PlayerInvite> GetPlayerInviteById(string Id)
        {

            PlayerInvite model = (from u in _context.PlayerInvite
                         where u.PlayerInviteId == Id
                             select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get All PlayerInvites List
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlayerInvite>> GetPlayerInvites()
        {
            return await _context.PlayerInvite.ToListAsync();
        }

        /// <summary>
        /// Get All GetPlayerInvitesByPrivateRunId List
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserProfileDTO>> GetPlayerInvitesByPrivateRunId(string privateRunId, string connStr)
        {
            List<UserProfileDTO> courtWaitingListDTO = new List<UserProfileDTO>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetPlayerInvitesByPrivateRunId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@privateRunId", privateRunId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                UserProfileDTO UserProfileDTOTemp = new UserProfileDTO();

                                UserProfileDTOTemp.UserId = dr["UserId"].ToString();
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();
                                UserProfileDTOTemp.Email = dr["Email"].ToString();
                                UserProfileDTOTemp.SignUpDate = (DateTime)dr["SignUpDate"];
                                UserProfileDTOTemp.LastLoginDate = (DateTime)dr["LastLoginDate"];
                                UserProfileDTOTemp.Role = dr["Role"].ToString();
                                UserProfileDTOTemp.UserName = dr["UserName"].ToString();
                                UserProfileDTOTemp.AccessLevel = dr["AccessLevel"].ToString();
                                UserProfileDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                UserProfileDTOTemp.PhoneNumber = dr["PhoneNumber"].ToString();
                                UserProfileDTOTemp.FirstName = dr["FirstName"].ToString();
                                UserProfileDTOTemp.LastName = dr["LastName"].ToString();
                                UserProfileDTOTemp.Position = dr["Position"].ToString();
                                UserProfileDTOTemp.Age = dr["Age"].ToString();
                                UserProfileDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                UserProfileDTOTemp.SkillTwo = dr["SkillTwo"].ToString();
                                UserProfileDTOTemp.StyleOfPlay = dr["StyleOfPlay"].ToString();
                                UserProfileDTOTemp.Points = (int)dr["Points"];
                                UserProfileDTOTemp.Wins = (int)dr["Wins"];
                                UserProfileDTOTemp.Losses = (int)dr["Losses"];
                                UserProfileDTOTemp.Height = dr["Height"].ToString();
                                UserProfileDTOTemp.Sex = dr["Sex"].ToString();
                                UserProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                UserProfileDTOTemp.WinPercentage = (decimal)dr["WinPercentage"];
                                UserProfileDTOTemp.UserLevel = dr["UserLevel"].ToString();
                                UserProfileDTOTemp.PlayerRank = (int)dr["PlayerRank"];
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();
                                UserProfileDTOTemp.DOB = (DateTime)dr["DOB"];
                                UserProfileDTOTemp.ImageName = dr["ImageName"].ToString();
                                UserProfileDTOTemp.TotalPointsEarned = (int)dr["TotalPointsEarned"];
                                UserProfileDTOTemp.UserLevelImage = dr["UserLevelImage"].ToString();
                                UserProfileDTOTemp.StarRatingImage = dr["StarRatingImage"].ToString();
                                UserProfileDTOTemp.StarRating = (int)dr["StarRating"];
                                UserProfileDTOTemp.City = dr["City"].ToString();
                                UserProfileDTOTemp.State = dr["State"].ToString();
                                UserProfileDTOTemp.Zip = dr["Zip"].ToString();
                                UserProfileDTOTemp.HasImage = (bool)dr["HasImage"];

                                UserProfileDTOTemp.PrivateRunStatus = dr["PrivateRunStatus"].ToString();
                                UserProfileDTOTemp.PlayerInviteId = dr["PlayerInviteId"].ToString();


                                courtWaitingListDTO.Add(UserProfileDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }

                foreach (var item in courtWaitingListDTO)
                {

                    //Get Win Percentage 
                    item.WinPercentage = Math.Round(_winpercentage.UserWinPercentage(item.Wins, item.Losses), 3);

                    if (item.HasImage == false)
                    {
                        item.ImagePath = UserProfileDefaultImagePath;
                    }

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
        /// Get All GetPlayerInvitesByPrivateRunId List
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlayerInviteDTO>> GetPlayerInvitesForUserProfileId(string userProfileId, string connStr)
        {
            List<PlayerInviteDTO> courtWaitingListDTO = new List<PlayerInviteDTO>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetPlayerInvitesForUserProfileId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@userProfileId", userProfileId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                PlayerInviteDTO UserProfileDTOTemp = new PlayerInviteDTO();

                                UserProfileDTOTemp.CourtId = dr["CourtId"].ToString();
                                UserProfileDTOTemp.CourtName = dr["CourtName"].ToString();
                                UserProfileDTOTemp.Address = dr["Address"].ToString();
                                UserProfileDTOTemp.City = dr["City"].ToString();
                                UserProfileDTOTemp.State = dr["State"].ToString();
                                UserProfileDTOTemp.Zip = dr["Zip"].ToString();
                                UserProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();
                                UserProfileDTOTemp.HostUserProfileId = dr["HostUserProfileId"].ToString();
                                UserProfileDTOTemp.AvailableTimes = dr["AvailableTimes"].ToString();
                                UserProfileDTOTemp.ReserveDay = dr["ReserveDay"].ToString();
                                UserProfileDTOTemp.ReserveCourtNumber = dr["ReserveCourtNumber"].ToString();
                                UserProfileDTOTemp.Status = dr["Status"].ToString();
                                UserProfileDTOTemp.PlayerInviteId = dr["PlayerInviteId"].ToString();
                                UserProfileDTOTemp.PrivateRunId = dr["PrivateRunId"].ToString();
                                UserProfileDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                UserProfileDTOTemp.PlayerInviteNumber = dr["PlayerInviteNumber"].ToString();
                                UserProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();
                               

                              

                                courtWaitingListDTO.Add(UserProfileDTOTemp);
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
        /// Get All GetPlayerInvitesByPrivateRunId List
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlayerInviteDTO>> GetPlayerInvitesByUserProfileId(string userProfileId, string connStr)
        {
            List<PlayerInviteDTO> courtWaitingListDTO = new List<PlayerInviteDTO>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetPlayerInvitesByUserProfileId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@userProfileId", userProfileId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                PlayerInviteDTO UserProfileDTOTemp = new PlayerInviteDTO();

                                

                                UserProfileDTOTemp.CourtId= dr["CourtId"].ToString();
                                UserProfileDTOTemp.CourtName = dr["CourtName"].ToString();
                                UserProfileDTOTemp.Address = dr["Address"].ToString();
                                UserProfileDTOTemp.City = dr["City"].ToString();
                                UserProfileDTOTemp.State = dr["State"].ToString();
                                UserProfileDTOTemp.Zip = dr["Zip"].ToString();
                                UserProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();
                                UserProfileDTOTemp.UserName = dr["UserName"].ToString();

                                UserProfileDTOTemp.HostUserProfileId = dr["HostUserProfileId"].ToString();
                                UserProfileDTOTemp.AvailableTimes = dr["AvailableTimes"].ToString();
                                UserProfileDTOTemp.ReserveDay = dr["ReserveDay"].ToString();
                                UserProfileDTOTemp.ReserveCourtNumber = dr["ReserveCourtNumber"].ToString();
                                UserProfileDTOTemp.Status = dr["Status"].ToString();
                                UserProfileDTOTemp.ReserveDate = (DateTime)dr["ReserveDate"];
                                UserProfileDTOTemp.PlayerInviteId = dr["PlayerInviteId"].ToString();
                                
                                UserProfileDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                UserProfileDTOTemp.HostUserProfileId = dr["HostUserProfileId"].ToString();
                                UserProfileDTOTemp.PlayerInviteNumber = dr["PlayerInviteNumber"].ToString();
                                UserProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();
                                UserProfileDTOTemp.PlayerInviteStatus = dr["PlayerInviteStatus"].ToString();
                                UserProfileDTOTemp.UserId = dr["UserId"].ToString();
                                UserProfileDTOTemp.SignUpDate = (DateTime)dr["SignUpDate"];
                                
                                
                                
                                UserProfileDTOTemp.FirstName = dr["FirstName"].ToString();
                                UserProfileDTOTemp.LastName = dr["LastName"].ToString();


                                courtWaitingListDTO.Add(UserProfileDTOTemp);
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
        /// Insert New PlayerInvite
        /// </summary>
        /// <param name="model"></param>
        public async Task InsertPlayerInvite(PlayerInvite model)
        {
            model.PlayerInviteId = Guid.NewGuid().ToString();
            model.PlayerInviteNumber = Functions.GenerateSixDigit();
            model.CreatedDate = DateTime.Now;

            _context.PlayerInvite.Add(model);
            Save();
        }

        /// <summary>
        /// Update PlayerInvite Info
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdatePlayerInvite(PlayerInvite model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// DeletePlayerInvite
        /// </summary>
        /// <param name="ReserveCourtId"></param>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        public async Task DeletePlayerInvite(string ReserveCourtId, string userProfileId)
        {
            PlayerInvite blog = (from u in _context.PlayerInvite
                                 where u.PlayerInviteId == ReserveCourtId && u.UserProfileId == userProfileId
                                 select u).FirstOrDefault();

            _context.PlayerInvite.Remove(blog);

            Save();

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

        /// <summary>
        /// Get Invited Players
        /// </summary>
        /// <param name="reserveCourtId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<UserProfileDTO>> GetInvitedPlayers( string reserveCourtId, string connStr)
        {
            List<UserProfileDTO> courtWaitingListDTO = new List<UserProfileDTO>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetInvitedPlayers"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        
                        comm.Parameters.AddWithValue("@reserveCourtId", reserveCourtId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                UserProfileDTO UserProfileDTOTemp = new UserProfileDTO();

                                UserProfileDTOTemp.UserId = dr["UserId"].ToString();
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();
                                UserProfileDTOTemp.Email = dr["Email"].ToString();
                                UserProfileDTOTemp.SignUpDate = (DateTime)dr["SignUpDate"];
                                UserProfileDTOTemp.LastLoginDate = (DateTime)dr["LastLoginDate"];
                                UserProfileDTOTemp.Role = dr["Role"].ToString();
                                UserProfileDTOTemp.UserName = dr["UserName"].ToString();
                                UserProfileDTOTemp.AccessLevel = dr["AccessLevel"].ToString();
                                UserProfileDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                UserProfileDTOTemp.PhoneNumber = dr["PhoneNumber"].ToString();
                                UserProfileDTOTemp.FirstName = dr["FirstName"].ToString();
                                UserProfileDTOTemp.LastName = dr["LastName"].ToString();
                                UserProfileDTOTemp.Position = dr["Position"].ToString();
                                UserProfileDTOTemp.Age = dr["Age"].ToString();
                                UserProfileDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                UserProfileDTOTemp.SkillTwo = dr["SkillTwo"].ToString();
                                UserProfileDTOTemp.StyleOfPlay = dr["StyleOfPlay"].ToString();
                                UserProfileDTOTemp.Points = (int)dr["Points"];
                                UserProfileDTOTemp.Wins = (int)dr["Wins"];
                                UserProfileDTOTemp.Losses = (int)dr["Losses"];
                                UserProfileDTOTemp.Height = dr["Height"].ToString();
                                UserProfileDTOTemp.Sex = dr["Sex"].ToString();
                                UserProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                UserProfileDTOTemp.WinPercentage = (decimal)dr["WinPercentage"];
                                UserProfileDTOTemp.UserLevel = dr["UserLevel"].ToString();
                                UserProfileDTOTemp.PlayerRank = (int)dr["PlayerRank"];
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();
                                UserProfileDTOTemp.DOB = (DateTime)dr["DOB"];
                                UserProfileDTOTemp.ImageName = dr["ImageName"].ToString();
                                UserProfileDTOTemp.TotalPointsEarned = (int)dr["TotalPointsEarned"];
                                UserProfileDTOTemp.UserLevelImage = dr["UserLevelImage"].ToString();
                                UserProfileDTOTemp.StarRatingImage = dr["StarRatingImage"].ToString();
                                UserProfileDTOTemp.StarRating = (int)dr["StarRating"];
                                UserProfileDTOTemp.City = dr["City"].ToString();
                                UserProfileDTOTemp.State = dr["State"].ToString();
                                UserProfileDTOTemp.Zip = dr["Zip"].ToString();
                                UserProfileDTOTemp.HasImage = (bool)dr["HasImage"];

                                UserProfileDTOTemp.PlayerInviteId = dr["PlayerInviteId"].ToString();
                                UserProfileDTOTemp.PrivateRunId = dr["PrivateRunId"].ToString();
                                UserProfileDTOTemp.Status = dr["Status"].ToString();
                                UserProfileDTOTemp.PlayerInviteNumber = dr["PlayerInviteNumber"].ToString();
                                UserProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();



                                courtWaitingListDTO.Add(UserProfileDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }

                foreach (var item in courtWaitingListDTO)
                {

                    //Get Win Percentage 
                    item.WinPercentage = Math.Round(_winpercentage.UserWinPercentage(item.Wins, item.Losses), 3);

                    if (item.HasImage == false)
                    {
                        item.ImagePath = UserProfileDefaultImagePath;
                    }

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
        /// Get Players Invites By ReserveCourtId
        /// </summary>
        /// <param name="reserveCourtId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<UserProfileDTO>> GetPlayersInvitesByReserveCourtId(string reserveCourtId, string connStr)
        {
            List<UserProfileDTO> courtWaitingListDTO = new List<UserProfileDTO>();

            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetPlayersInvitesByReserveCourtId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;

                        comm.Parameters.AddWithValue("@reserveCourtId", reserveCourtId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                UserProfileDTO UserProfileDTOTemp = new UserProfileDTO();

                                UserProfileDTOTemp.UserId = dr["UserId"].ToString();
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();
                                UserProfileDTOTemp.Email = dr["Email"].ToString();
                                UserProfileDTOTemp.SignUpDate = (DateTime)dr["SignUpDate"];
                                UserProfileDTOTemp.LastLoginDate = (DateTime)dr["LastLoginDate"];
                                UserProfileDTOTemp.Role = dr["Role"].ToString();
                                UserProfileDTOTemp.UserName = dr["UserName"].ToString();
                                UserProfileDTOTemp.AccessLevel = dr["AccessLevel"].ToString();
                                UserProfileDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                UserProfileDTOTemp.PhoneNumber = dr["PhoneNumber"].ToString();
                                UserProfileDTOTemp.FirstName = dr["FirstName"].ToString();
                                UserProfileDTOTemp.LastName = dr["LastName"].ToString();
                                UserProfileDTOTemp.Position = dr["Position"].ToString();
                                UserProfileDTOTemp.Age = dr["Age"].ToString();
                                UserProfileDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                UserProfileDTOTemp.SkillTwo = dr["SkillTwo"].ToString();
                                UserProfileDTOTemp.StyleOfPlay = dr["StyleOfPlay"].ToString();
                                UserProfileDTOTemp.Points = (int)dr["Points"];
                                UserProfileDTOTemp.Wins = (int)dr["Wins"];
                                UserProfileDTOTemp.Losses = (int)dr["Losses"];
                                UserProfileDTOTemp.Height = dr["Height"].ToString();
                                UserProfileDTOTemp.Sex = dr["Sex"].ToString();
                                UserProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                UserProfileDTOTemp.WinPercentage = (decimal)dr["WinPercentage"];
                                UserProfileDTOTemp.UserLevel = dr["UserLevel"].ToString();
                                UserProfileDTOTemp.PlayerRank = (int)dr["PlayerRank"];
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();
                                UserProfileDTOTemp.DOB = (DateTime)dr["DOB"];
                                UserProfileDTOTemp.ImageName = dr["ImageName"].ToString();
                                UserProfileDTOTemp.TotalPointsEarned = (int)dr["TotalPointsEarned"];
                                UserProfileDTOTemp.UserLevelImage = dr["UserLevelImage"].ToString();
                                UserProfileDTOTemp.StarRatingImage = dr["StarRatingImage"].ToString();
                                UserProfileDTOTemp.StarRating = (int)dr["StarRating"];
                                UserProfileDTOTemp.City = dr["City"].ToString();
                                UserProfileDTOTemp.State = dr["State"].ToString();
                                UserProfileDTOTemp.Zip = dr["Zip"].ToString();
                                UserProfileDTOTemp.HasImage = (bool)dr["HasImage"];

                                UserProfileDTOTemp.PlayerInviteId = dr["PlayerInviteId"].ToString();
                                UserProfileDTOTemp.PrivateRunId = dr["PrivateRunId"].ToString();
                                UserProfileDTOTemp.Status = dr["Status"].ToString();
                                UserProfileDTOTemp.PlayerInviteNumber = dr["PlayerInviteNumber"].ToString();
                                UserProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();



                                courtWaitingListDTO.Add(UserProfileDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }

                foreach (var item in courtWaitingListDTO)
                {

                    //Get Win Percentage 
                    item.WinPercentage = Math.Round(_winpercentage.UserWinPercentage(item.Wins, item.Losses), 3);

                    if (item.HasImage == false)
                    {
                        item.ImagePath = UserProfileDefaultImagePath;
                    }

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
        /// Confirmed PlayerInvite
        /// </summary>
        /// <param name="reserveCourtId"></param>
        /// <returns></returns>
        public async Task<int> ConfirmedPlayerInvite(string reserveCourtId)
        {
            List<PlayerInvite> model = (from u in _context.PlayerInvite
                                  where u.ReserveCourtId == reserveCourtId && u.Status == "Confirmed"
                                  select u).ToList();

            return model.Count();
        }

        /// <summary>
        /// Declined PlayerInvite
        /// </summary>
        /// <param name="reserveCourtId"></param>
        /// <returns></returns>
        public async Task<int> DeclinedPlayerInvite(string reserveCourtId)
        {
            List<PlayerInvite> model = (from u in _context.PlayerInvite
                                        where u.ReserveCourtId == reserveCourtId && u.Status == "Declined"
                                        select u).ToList();

            return model.Count();
        }

        /// <summary>
        /// Pending PlayerInvite
        /// </summary>
        /// <param name="reserveCourtId"></param>
        /// <returns></returns>
        public async Task<int> PendingPlayerInvite(string reserveCourtId)
        {
            List<PlayerInvite> model = (from u in _context.PlayerInvite
                                        where u.ReserveCourtId == reserveCourtId && u.Status == "Waiting For Response"
                                        select u).ToList();

            return model.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserveCourtId"></param>
        /// <returns></returns>
        public async Task<int> InvitedPlayerInvite(string reserveCourtId)
        {
            List<PlayerInvite> model = (from u in _context.PlayerInvite
                                        where u.ReserveCourtId == reserveCourtId && u.Status == "Invite"
                                        select u).ToList();

            return model.Count();
        }
    }
}
