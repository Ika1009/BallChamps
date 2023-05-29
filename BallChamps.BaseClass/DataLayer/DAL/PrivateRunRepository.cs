using BallChamps.Domain;
using BusinessLogic;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    public class PrivateRunRepository : IPrivateRunRepository, IDisposable
    {
        private PrivateRunContext _context;
        public IConfiguration Configuration { get; }
        /// <summary>
        /// PrivateRun Repository
        /// </summary>
        /// <param name="context"></param>
        public PrivateRunRepository(PrivateRunContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;
            
        }

        /// <summary>
        /// Get PrivateRun By Id
        /// </summary>
        /// <param name="privateRunId"></param>
        /// <returns></returns>
        public async Task<PrivateRun> GetPrivateRunById(string privateRunId)
        {

            PrivateRun model = (from u in _context.PrivateRun
                               where u.PrivateRunId == privateRunId
                                select u).FirstOrDefault();

            return  model;
        }

        /// <summary>
        /// Get PrivateRun By Host Id
        /// </summary>
        /// <param name="privateRunId"></param>
        /// <returns></returns>
        public async Task<PrivateRunDTO> GetPrivateRunByHostId(string userProfileId, string connStr)
        {

            PrivateRunDTO userProfileDTOTemp = new PrivateRunDTO();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GetPrivateRunByHostId"))
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

                                //PrivateRun
                                userProfileDTOTemp.CourtId = dr["CourtId"].ToString();
                                userProfileDTOTemp.HostUserProfileId = dr["HostUserProfileId"].ToString();
                                userProfileDTOTemp.PrivateRunId = dr["PrivateRunId"].ToString();
                                userProfileDTOTemp.PerPersonCost = (int)dr["PerPersonCost"];
                                userProfileDTOTemp.PlayerLimit = (int)dr["PlayerLimit"];
                                userProfileDTOTemp.Description = dr["Description"].ToString();
                                userProfileDTOTemp.Title = dr["Title"].ToString();
                                userProfileDTOTemp.Status = dr["Status"].ToString();
                                userProfileDTOTemp.CreatedTime = (DateTime)dr["CreatedTime"];

                                //Court
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
                                userProfileDTOTemp.Status = dr["Status"].ToString();
                                userProfileDTOTemp.StatusIndicatorImage = dr["StatusIndicatorImage"].ToString();
                                userProfileDTOTemp.Type = dr["Type"].ToString();
                                userProfileDTOTemp.StartDate = (DateTime)dr["StartDate"];
                                userProfileDTOTemp.EndDate = (DateTime)dr["EndDate"];
                                userProfileDTOTemp.StartTime = (DateTime)dr["StartTime"];
                                userProfileDTOTemp.EndTime = (DateTime)dr["EndTime"];
                                userProfileDTOTemp.CourtNumber = dr["CourtNumber"].ToString();
                                userProfileDTOTemp.Description = dr["Description"].ToString();
                                userProfileDTOTemp.CreatedDate = (DateTime)dr["CreatedDate"];
                                userProfileDTOTemp.OpenClosed = dr["OpenClosed"].ToString();
                                userProfileDTOTemp.ObjType = dr["ObjType"].ToString();
                                userProfileDTOTemp.BetStatus = dr["BetStatus"].ToString();
                                userProfileDTOTemp.BetCost = (int)dr["BetCost"];
                                userProfileDTOTemp.ReserveCost = (Decimal)dr["ReserveCost"];
                                userProfileDTOTemp.AvailableTimes = dr["AvailableTimes"].ToString();
                                userProfileDTOTemp.CourtCoordinator = dr["CourtCoordinator"].ToString();
                              
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
        /// Get PrivateRuns List
        /// </summary>
        /// <returns></returns>
        public async Task<List<PrivateRun>> GetPrivateRuns()
        {
            return await _context.PrivateRun.ToListAsync();
        }

        /// <summary>
        /// Insert PrivateRun
        /// </summary>
        /// <param name="blog"></param>
        public async Task InsertPrivateRun(PrivateRun model)
        {
            model.PrivateRunId = Guid.NewGuid().ToString();
            model.Status = "Pending";
            model.CreatedTime = DateTime.Now;
            

            _context.PrivateRun.Add(model);
            Save();
        }

        /// <summary>
        /// Update PrivateRun
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdatePrivateRun(PrivateRun model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Delete PrivateRun
        /// </summary>
        /// <param name="privateRunId"></param>
        public async Task DeletePrivateRun(string privateRunId)
        {
            PrivateRun model = (from u in _context.PrivateRun
                                where u.PrivateRunId == privateRunId
                                select u).FirstOrDefault();

            _context.PrivateRun.Remove(model);
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
