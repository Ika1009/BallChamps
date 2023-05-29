using BallChamps.Domain;
using Common;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    public class GameHistoryRepository : IGameHistoryRepository, IDisposable
    {
        public IConfiguration Configuration { get; } 
        private GameHistoryContext _context;

        /// <summary>
        /// GameHistory Repository
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        public GameHistoryRepository(GameHistoryContext context, IConfiguration configuration)
        {
            Configuration = configuration;
            this._context = context;           
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
        /// Get GameHistory By UserProfileId
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<PlayerHistoryDTO>> GetGameHistoryByUserProfileId(string Id, string connStr)
        {

            List<PlayerHistoryDTO> playerHistoryDTOTempList = new List<PlayerHistoryDTO>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GameHistoryByUserProfileId"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@userProfileId", Id);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                PlayerHistoryDTO playerHistoryDTOTemp = new PlayerHistoryDTO();

                                playerHistoryDTOTemp.GameNumber = dr["GameNumber"].ToString();
                                playerHistoryDTOTemp.CourtId = dr["CourtId"].ToString();
                                playerHistoryDTOTemp.WinningTeam = dr["WinningTeam"].ToString();
                                playerHistoryDTOTemp.Status = dr["Status"].ToString();
                                playerHistoryDTOTemp.StartTime = (DateTime)dr["StartTime"];
                                playerHistoryDTOTemp.EndTime = (DateTime)dr["EndTime"];
                                playerHistoryDTOTemp.PlayerHistoryId = dr["PlayerHistoryId"].ToString();
                                playerHistoryDTOTemp.WinOrLose = dr["WinOrLose"].ToString();
                                playerHistoryDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                playerHistoryDTOTemp.GameHistoryId = dr["GameHistoryId"].ToString();
                                playerHistoryDTOTemp.CourtName = dr["CourtName"].ToString();

                                playerHistoryDTOTempList.Add(playerHistoryDTOTemp);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }

               

                return playerHistoryDTOTempList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get GameHistory By GameNumber
        /// </summary>
        /// <param name="gameNumber"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<GameHistoryDTO>> GetGameHistoryByGameNumber(string gameNumber, string connStr)
        {

            List<GameHistoryDTO> gameHistoryDTOTempList = new List<GameHistoryDTO>();
            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("GameHistoryByGameNumber"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@gameNumber", gameNumber);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                GameHistoryDTO gameHistoryDTOTemp = new GameHistoryDTO();

                                gameHistoryDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                gameHistoryDTOTemp.WinOrLose = dr["WinOrLose"].ToString();
                                gameHistoryDTOTemp.UserName = dr["UserName"].ToString();
                                gameHistoryDTOTemp.GameNumber = dr["GameNumber"].ToString();
                                gameHistoryDTOTemp.ImagePath = dr["ImagePath"].ToString();

                                gameHistoryDTOTempList.Add(gameHistoryDTOTemp);

                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }



                return gameHistoryDTOTempList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Insert GameHistory
        /// </summary>
        /// <param name="gameHistory"></param>
        /// <param name="playerHistory"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task InsertGameHistory(GameHistory gameHistory,List<PlayerHistory> playerHistory, string connStr)
        {
            string gameHistoryId = Guid.NewGuid().ToString();            
            string gameNumber = Functions.GenerateSixDigit();
            string playerHistoryId = string.Empty;

            try
            {

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand comm = new SqlCommand("InsertGameHistory"))
                    {
                        //GameHistory Table Fields
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@GameHistoryId", gameHistoryId);
                        comm.Parameters.AddWithValue("@CourtId", gameHistory.CourtId);
                        comm.Parameters.AddWithValue("@WinningTeam", gameHistory.WinningTeam);
                        comm.Parameters.AddWithValue("@Status", gameHistory.Status);
                        comm.Parameters.AddWithValue("@StartTime", gameHistory.StartTime);
                        comm.Parameters.AddWithValue("@EndTime", gameHistory.EndTime);
                        
                        conn.Open();
                        comm.ExecuteNonQuery();

                    }

                    conn.Close();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

            foreach (var item in playerHistory)
            {
                playerHistoryId = Guid.NewGuid().ToString();

                try
                {

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand comm = new SqlCommand("InsertPlayerHistory"))
                        {
                            //GameHistory Table Fields
                            comm.CommandType = CommandType.StoredProcedure;
                            comm.Connection = conn;
                            comm.Parameters.AddWithValue("@PlayerHistoryId", playerHistoryId);
                            comm.Parameters.AddWithValue("@GameHistoryId", gameHistoryId);
                            comm.Parameters.AddWithValue("@WinOrLose", item.WinOrLose);
                            comm.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                            comm.Parameters.AddWithValue("@Status", item.Status);
                            

                            conn.Open();
                            comm.ExecuteNonQuery();

                        }

                        conn.Close();

                    }



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());


                }
            }

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
