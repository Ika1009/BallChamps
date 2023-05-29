using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using DataLayer.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Court Controller
    /// </summary>
    [Route("api/[controller]")]
    public class CourtController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        string ballchampsConnectionString;
        public IConfiguration Configuration { get; }
        private ICourtRepository courtRepository;

        /// <summary>
        /// Court Controller
        /// </summary>
        /// <param name="courtContext"></param>
        public CourtController(CourtContext courtContext, IConfiguration configuration)
        {
            Configuration = configuration;
            this.courtRepository = new CourtRepository(courtContext, Configuration);
            this.ballchampsConnectionString = Configuration.GetConnectionString("BallChamps_Staging");
        }

        /// <summary>
        /// Get Courts
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCourts")]
       
        public async Task<List<Court>> GetCourts()
        {
            try
            {
                return await courtRepository.GetCourts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get Court By Id
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpGet("GetCourtById")] 
        //[Authorize]
        public async Task<Court> GetCourtById(string courtId)
        {

            try
            {
                return await courtRepository.GetCourtById(courtId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get Court By Id
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpGet("GetCourtSignedUpByUserProfieId")]
        //[Authorize]
        public async Task<CourtDTO> GetCourtSignedUpByUserProfieId(string userProfileId)
        {

            CourtDTO courtWaitingListDTO = new CourtDTO();
            try
            {
                string StrQuery;
                using (SqlConnection conn = new SqlConnection(ballchampsConnectionString))
                {
                    using (SqlCommand comm = new SqlCommand("GetCourtSignedUpByUserProfieId"))
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
                              
                                courtWaitingListDTO.CourtWaitingListId = dr["CourtWaitingListId"].ToString();
                                courtWaitingListDTO.CourtId = dr["CourtId"].ToString();
                                
                                courtWaitingListDTO.SignUpTime = dr["SignUpTime"].ToString();
                                courtWaitingListDTO.CourtName = dr["CourtName"].ToString();
                                
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
        /// Delete Court
        /// </summary>
        /// <param name="courtId"></param>
        [HttpDelete("DeleteCourt")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeleteCourt(string courtId)
        {
            
            try
            {
                await courtRepository.DeleteCourt(courtId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeleteCourt");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Create Court
        /// </summary>
        /// <param name="court"></param>
        //[Authorize]
        [HttpPost("CreateCourt")]
        public async Task CreateCourt([FromBody] Court court)
        {
            try
            {

                await courtRepository.InsertCourt(court);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// Update Court
        /// </summary>
        /// <param name="court"></param>
        //[Authorize]
        [HttpPost("UpdateCourt")]
        public async Task UpdateCourt([FromBody] Court court)
        {
            try
            {
                await courtRepository.UpdateCourt(court);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

       

        /// <summary>
        /// CourtNameExist
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpGet("CourtNameExist")]
        //[Authorize]
        public async Task<bool> CourtNameExist(string courtName)
        {
            bool result = false;

            try
            {
                result = await courtRepository.CourtNameExist(courtName);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return result;
        }

    }
}
