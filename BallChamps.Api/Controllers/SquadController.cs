using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using DataLayer.DTO;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Squad Controller
    /// </summary>
    [Route("api/[controller]")]
    public class SquadController : Controller
    {
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        private ISquadRepository squadRepository;

        /// <summary>
        /// Squad Controller Constructor
        /// </summary>
        /// <param name="squadContext"></param>
        public SquadController(SquadContext squadContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.squadRepository = new SquadRepository(squadContext);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }

        /// <summary>
        /// Get All Squads
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetSquads")]
        public async  Task<List<Squad>> GetSquads()
        {
            try
            {
                return await squadRepository.GetSquads();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get Squad By Id
        /// </summary>
        /// <param name="squadId"></param>
        /// <returns></returns>
        [HttpGet("GetSquadById")]
        //[Authorize]
        public async Task<List<SquadDTO>> GetSquadById(string squadId)
        {

            List<SquadDTO>? squadDTO = new List<SquadDTO>();
            try
            {
                
                using (SqlConnection conn = new SqlConnection(ballchampsConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand("GetSquadById"))
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@squadId", squadId);
                        conn.Open();
                        comm.ExecuteNonQuery();

                        SqlDataReader dr = comm.ExecuteReader();

                        //check if there are records
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                SquadDTO? squadDTOTemp = new SquadDTO();

                                squadDTOTemp.SquadId = dr["SquadId"].ToString();
                                squadDTOTemp.Owner = (bool)dr["Owner"];
                                squadDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                squadDTOTemp.Captain = dr["Captain"].ToString();
                                squadDTOTemp.Position = dr["Position"].ToString();
                                squadDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                squadDTOTemp.SkillTwo = dr["SkillTwo"].ToString();
                                squadDTOTemp.Rank = dr["Rank"].ToString();
                                squadDTOTemp.Rate = dr["Rate"].ToString();
                                squadDTOTemp.Type = dr["Type"].ToString();
                                squadDTOTemp.StarRating = (int)dr["StarRating"];
                                squadDTOTemp.WinPercentage = (decimal)dr["WinPercentage"];


                                squadDTO.Add(squadDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }


                return squadDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;

        }


        /// <summary>
        /// Get Squad By Id
        /// </summary>
        /// <param name="squadId"></param>
        /// <returns></returns>
        [HttpGet("GetSquadByUserProfileId")]
        //[Authorize]
        public async Task<List<SquadDTO>> GetSquadByUserProfileId(string userProfileId)
        {

            List<SquadDTO> squadDTO = new List<SquadDTO>();
            try
            {
                
                using (SqlConnection conn = new SqlConnection(ballchampsConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand("GetSquadByUserProfileId"))
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
                                SquadDTO squadDTOTemp = new SquadDTO();

                                squadDTOTemp.SquadId = dr["SquadId"].ToString();
                                squadDTOTemp.Owner = (bool)dr["Owner"];
                                squadDTOTemp.UserProfileId = dr["UserProfileId"].ToString();
                                squadDTOTemp.Captain = dr["Captain"].ToString();
                                squadDTOTemp.Position = dr["Position"].ToString();
                                squadDTOTemp.SkillOne = dr["SkillOne"].ToString();
                                squadDTOTemp.SkillTwo = dr["SkillTwo"].ToString();
                                squadDTOTemp.Rank = dr["Rank"].ToString();
                                squadDTOTemp.ImagePath = dr["ImagePath"].ToString();
                                squadDTOTemp.ProfileUserName = dr["ProfileUserName"].ToString();
                                squadDTOTemp.Type = dr["Type"].ToString();
                                squadDTOTemp.StarRating = (int)dr["StarRating"];
                                squadDTOTemp.WinPercentage = (decimal)dr["WinPercentage"];


                                squadDTO.Add(squadDTOTemp);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }

                    }

                    conn.Close();

                }


                return squadDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;

        }


        /// <summary>
        /// Delete Squad
        /// </summary>
        /// <param name="blogId"></param>
        [HttpPost("DeleteSquad")]
        [Authorize]
        public void DeleteSquad(string squadId)
        {

            try
            {
                squadRepository.DeleteSquad(squadId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        /// <summary>
        /// Create new Squad
        /// </summary>
        /// <param name="blog"></param>
        [Authorize]
        [HttpPost("CreateSquad")]
        public void CreateSquad([FromBody] Squad squad)
        {
            try
            {

                squadRepository.InsertSquad(squad);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        /// <summary>
        /// Update Squad Info
        /// </summary>
        /// <param name="squad"></param>
        [Authorize]
        [HttpPost("UpdateSquad")]
        public void UpdateBlog([FromBody] Squad squad)
        {
            try
            {
                squadRepository.UpdateSquad(squad);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
