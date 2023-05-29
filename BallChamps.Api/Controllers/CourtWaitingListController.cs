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
    /// CourtWaitingList Controller
    /// </summary>
    [Route("api/[controller]")]
    //[Authorize]
    public class CourtWaitingListController : ControllerBase
    {
        string ballchampsConnectionString;
       
        private ICourtWaitingListRepository courtWaitingListRepository;

        /// <summary>
        /// CourtWaitingList Controller
        /// </summary>
        /// <param name="courtWaitingListContext"></param>
        public CourtWaitingListController(CourtWaitingListContext courtWaitingListContext)
        {
            
            this.courtWaitingListRepository = new CourtWaitingListRepository(courtWaitingListContext);
           
        }

        /// <summary>
        /// Insert Player To Cour tWaiting List
        /// </summary>
      
        [HttpPost("InsertPlayerToCourtWaitingList")]
       // [Authorize]
        public void InsertPlayerToCourtWaitingList([FromBody] CourtWaitingList courtWaitingList)
        {
            try
            {
                courtWaitingListRepository.InsertPlayerToCourtWaitingList(courtWaitingList);
            }
            catch (Exception ex)
            {
                var x = ex;
            }
        }

        /// <summary>
        /// ClearCourtWaitingList
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpPost("ClearCourtWaitingList")]
        // [Authorize]
        public void ClearCourtWaitingList(string courtId)
        {
            try
            {
                courtWaitingListRepository.ClearCourtWaitingList(courtId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }

        /// <summary>
        /// Get CourtWaitingList By CourtId
        /// </summary>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpGet("GetCourtWaitingListByCourtId")]
        //[Authorize]
        public async Task<List<CourtWaitingList>> GetCourtWaitingListByCourtId(string courtId)
        {
            try
            {
                var data = await courtWaitingListRepository.GetCourtWaitingListByCourtId(courtId);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;

        }

        /// <summary>
        /// Remove PlayerFromCourtWaitingList
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpPost("RemovePlayerFromCourtWaitingList")]
        public async Task RemovePlayerFromCourtWaitingList(string userProfileId)
        {
            await courtWaitingListRepository.RemovePlayerFromCourtWaitingList(userProfileId);
        }

        /// <summary>
        /// IsUserProfileSignedUpAtCourt
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="courtId"></param>
        /// <returns></returns>
        [HttpGet("IsProfileSignedUpAtCourt")]
        public async Task<bool> IsProfileSignedUpAtCourt(string profileId, string courtId)
        {
            return await  courtWaitingListRepository.IsProfileSignedUpAtCourt(profileId, courtId);
        }

        /// <summary>
        /// IsUserProfileSignedUp At AnyCourt
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [HttpGet("IsProfileSignedUpAtAnyCourt")]
        public async Task<bool> IsProfileSignedUpAtAnyCourt(string userProfileId)
        {
            return await courtWaitingListRepository.IsProfileSignedUpAtAnyCourt(userProfileId);
        }
         
        /// <summary>
        /// Get Court UserProfile Is Signed Up At
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [HttpGet("GetCourtProfileIsSignedUpAt")]
        public async Task<CourtWaitingList> GetCourtProfileIsSignedUpAt(string profileId)
        {

            try
            {
                var data = await courtWaitingListRepository.GetCourtProfileIsSignedUpAt(profileId);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }


        /// <summary>
        /// Update CourtWaiting List By Id
        /// </summary>
        /// <param name="court"></param>
        //[Authorize]
        [HttpPost("UpdateCourtWaitingListById")]
        public async Task UpdateCourtWaitingListById([FromBody] CourtWaitingList courtWaitingList)
        {
            try
            {
                await courtWaitingListRepository.UpdateCourtWaitingListById(courtWaitingList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
