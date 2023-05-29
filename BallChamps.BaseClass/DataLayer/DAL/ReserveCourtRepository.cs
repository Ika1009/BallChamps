using BallChamps.Domain;
using Common;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    public class ReserveCourtRepository : IReserveCourtRepository, IDisposable
    {
        private ReserveCourtContext _context;
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Reserve CourtRepository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public ReserveCourtRepository(ReserveCourtContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;
            
        }

        /// <summary>
        /// GetReserveCourtById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ReserveCourt> GetReserveCourtById(string Id)
        {

            ReserveCourt model = (from u in _context.ReserveCourt
                                  where u.ReserveCourtId == Id
                             select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// ReserveCourtByUserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<ReserveCourtDTO> ReserveCourtByUserProfileId(string userProfileId, string connStr)
        {

            ReserveCourtDTO userProfileDTOTemp = new ReserveCourtDTO();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("ReserveCourtByUserProfileId"))
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

                                //ReserveCourt Table
                                userProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();
                                userProfileDTOTemp.CourtId = dr["CourtId"].ToString();
                                userProfileDTOTemp.HostUserProfileId = dr["HostUserProfileId"].ToString();
                                userProfileDTOTemp.AvailableTimes = dr["AvailableTimes"].ToString();
                                userProfileDTOTemp.ReserveDay = dr["ReserveDay"].ToString();
                                userProfileDTOTemp.ReserveCourtNumber = dr["ReserveCourtNumber"].ToString();
                                userProfileDTOTemp.Status = dr["Status"].ToString();
                                userProfileDTOTemp.PerPlayerCost = (int)dr["PerPlayerCost"];
                                userProfileDTOTemp.PlayerLimit = (int)dr["PlayerLimit"];
                                userProfileDTOTemp.ReserveDate = (DateTime)dr["ReserveDate"];
                                userProfileDTOTemp.Description = dr["Description"].ToString();
                                userProfileDTOTemp.Title = dr["Title"].ToString();
                                userProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                userProfileDTOTemp.ReserveCost = (decimal)dr["ReserveCost"];

                                //Court Table
                                userProfileDTOTemp.CourtName = dr["CourtName"].ToString();
                                userProfileDTOTemp.Address = dr["Address"].ToString();
                                userProfileDTOTemp.City = dr["City"].ToString();
                                userProfileDTOTemp.State = dr["State"].ToString();
                                userProfileDTOTemp.Zip = dr["Zip"].ToString();
                                userProfileDTOTemp.Rating = dr["Rating"].ToString();
                                userProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                userProfileDTOTemp.Longitude = dr["Longitude"].ToString();
                                userProfileDTOTemp.Latitude = dr["Latitude"].ToString();
                                userProfileDTOTemp.SignUpTime = (DateTime)dr["SignUpTime"];
                                userProfileDTOTemp.StatusIndicatorImage = dr["StatusIndicatorImage"].ToString();
                                userProfileDTOTemp.Type = dr["Type"].ToString();
                                userProfileDTOTemp.StartDate = (DateTime)dr["StartDate"];
                                userProfileDTOTemp.EndDate = (DateTime)dr["EndDate"];
                                userProfileDTOTemp.StartTime = (DateTime)dr["StartTime"];
                                userProfileDTOTemp.EndTime = (DateTime)dr["EndTime"];
                                userProfileDTOTemp.CourtNumber = dr["CourtNumber"].ToString();
                                userProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                userProfileDTOTemp.OpenClosed = dr["OpenClosed"].ToString();
                                userProfileDTOTemp.ObjType = dr["ObjType"].ToString();
                                userProfileDTOTemp.BetStatus = dr["BetStatus"].ToString();
                                userProfileDTOTemp.BetCost = (int)dr["BetCost"];
                                userProfileDTOTemp.ReserveCost = (decimal)dr["ReserveCost"];
                                userProfileDTOTemp.CourtCoordinator = dr["CourtCoordinator"].ToString();

                                ////PrivateRun Table
                                //userProfileDTOTemp.PrivateRunId = dr["PrivateRunId"].ToString();
                                
                                //userProfileDTOTemp.PlayerLimit = (int)dr["PlayerLimit"];
                                //userProfileDTOTemp.Description = dr["Description"].ToString();
                                //userProfileDTOTemp.Title = dr["Title"].ToString();
                                //userProfileDTOTemp.PR_Status = dr["PR_Status"].ToString();
                                //userProfileDTOTemp.CreatedTime = (DateTime)dr["CreatedTime"];

                                //UserProfile Table
                                userProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();

                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }

                

                return userProfileDTOTemp;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get CourtReserve Courts By CourtId
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<ReserveCourtDTO>> GetCourtReserveCourtsByCourtId(string courtId, string connStr)
        {

            List<ReserveCourtDTO> userProfileDTOTempList = new List<ReserveCourtDTO>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetCourtReserveCourtsByCourtId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@courtId", courtId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {

                                ReserveCourtDTO UserProfileDTOTemp = new ReserveCourtDTO();

                                //ReserveCourt Table
                                UserProfileDTOTemp.ReserveCourtId = dr["ReserveCourtId"].ToString();
                                UserProfileDTOTemp.CourtId = dr["CourtId"].ToString();
                                UserProfileDTOTemp.HostUserProfileId = dr["HostUserProfileId"].ToString();
                                UserProfileDTOTemp.AvailableTimes = dr["AvailableTimes"].ToString();
                                UserProfileDTOTemp.ReserveDay = dr["ReserveDay"].ToString();
                                UserProfileDTOTemp.ReserveCourtNumber = dr["ReserveCourtNumber"].ToString();
                                UserProfileDTOTemp.Status = dr["Status"].ToString();

                                //Court Table
                                UserProfileDTOTemp.CourtName = dr["CourtName"].ToString();
                                UserProfileDTOTemp.Address = dr["Address"].ToString();
                                UserProfileDTOTemp.City = dr["City"].ToString();
                                UserProfileDTOTemp.State = dr["State"].ToString();
                                UserProfileDTOTemp.Zip = dr["Zip"].ToString();
                                UserProfileDTOTemp.Rating = dr["Rating"].ToString();
                                UserProfileDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                UserProfileDTOTemp.Longitude = dr["Longitude"].ToString();
                                UserProfileDTOTemp.Latitude = dr["Latitude"].ToString();
                                UserProfileDTOTemp.SignUpTime = (DateTime)dr["SignUpTime"];
                                UserProfileDTOTemp.StatusIndicatorImage = dr["StatusIndicatorImage"].ToString();
                                UserProfileDTOTemp.Type = dr["Type"].ToString();
                                UserProfileDTOTemp.StartDate = (DateTime)dr["StartDate"];
                                UserProfileDTOTemp.EndDate = (DateTime)dr["EndDate"];
                                UserProfileDTOTemp.StartTime = (DateTime)dr["StartTime"];
                                UserProfileDTOTemp.EndTime = (DateTime)dr["EndTime"];
                                UserProfileDTOTemp.CourtNumber = dr["CourtNumber"].ToString();
                                UserProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                UserProfileDTOTemp.OpenClosed = dr["OpenClosed"].ToString();
                                UserProfileDTOTemp.ObjType = dr["ObjType"].ToString();
                                UserProfileDTOTemp.BetStatus = dr["BetStatus"].ToString();
                                UserProfileDTOTemp.BetCost = (int)dr["BetCost"];
                                UserProfileDTOTemp.ReserveCost = (decimal)dr["ReserveCost"];
                                UserProfileDTOTemp.CourtCoordinator = dr["CourtCoordinator"].ToString();

                                //PrivateRun Table
                                UserProfileDTOTemp.PrivateRunId = dr["PrivateRunId"].ToString();
                                UserProfileDTOTemp.PerPersonCost = (int)dr["PerPersonCost"];
                                UserProfileDTOTemp.PlayerLimit = (int)dr["PlayerLimit"];
                                UserProfileDTOTemp.Description = dr["Description"].ToString();
                                UserProfileDTOTemp.Title = dr["Title"].ToString();
                                UserProfileDTOTemp.PR_Status = dr["PR_Status"].ToString();
                                UserProfileDTOTemp.CreatedTime = (DateTime)dr["CreatedTime"];

                                //UserProfile Table
                                UserProfileDTOTemp.UserProfileNumber = dr["UserProfileNumber"].ToString();

                                userProfileDTOTempList.Add(UserProfileDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }



                return userProfileDTOTempList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get All ReserveCourts List
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReserveCourt>> GetReserveCourts()
        {
            return await _context.ReserveCourt.ToListAsync();
        }

        /// <summary>
        /// Insert ReserveCourt
        /// </summary>
        /// <param name="model"></param>
        public async Task InsertReserveCourt(ReserveCourt model)
        {
            model.ReserveCourtId = Guid.NewGuid().ToString();
            model.ReserveCourtNumber = Functions.GenerateSixDigit();
            model.Status = "Pending";

            _context.ReserveCourt.Add(model);
            Save();
        }

        /// <summary>
        /// Update ReserveCourt
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateReserveCourt(ReserveCourt model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Delete ReserveCourt
        /// </summary>
        /// <param name="Id"></param>
        public async Task DeleteReserveCourt(string Id)
        {
            ReserveCourt model = (from u in _context.ReserveCourt
                         where u.ReserveCourtId == Id
                         select u).FirstOrDefault();

            _context.ReserveCourt.Remove(model);
            Save();

        }

        /// <summary>
        /// Approve ReserveCourt
        /// </summary>
        /// <param name="Id"></param>
        public async Task ApproveReserveCourt(string Id)
        {
            ReserveCourt model = (from u in _context.ReserveCourt
                                  where u.ReserveCourtId == Id
                                  select u).FirstOrDefault();

            model.Status = "Reserved";

            
            Save();

        }

        /// <summary>
        /// Approve ReserveCourt
        /// </summary>
        /// <param name="Id"></param>
        public async Task CancelReserveCourt(string Id)
        {
            ReserveCourt model = (from u in _context.ReserveCourt
                                  where u.ReserveCourtId == Id
                                  select u).FirstOrDefault();

            model.Status = "Canceled";
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
    }
}
