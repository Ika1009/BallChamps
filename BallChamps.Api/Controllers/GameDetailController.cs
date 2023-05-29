using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// GameDetail Controller
    /// </summary>
    [Route("api/[controller]")]
    public class GameDetailController : Controller
    {

        private IGameDetailRepository? gameDetailRepository;
        //private ICourtRepository? courtRepository;

        /// <summary>
        /// GameDetail Controller
        /// </summary>
        /// <param name="gameDetailContext"></param>
        /// <param name="courtContext"></param>
        public GameDetailController(GameDetailContext gameDetailContext, CourtContext courtContext)
        {

            this.gameDetailRepository = new GameDetailRepository(gameDetailContext, courtContext);
            

        }

        /// <summary>
        /// GetGameDetails
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetGameDetails")]
        public async  Task<List<GameDetail>> GetGameDetails()
        {
            try
            {
                return await gameDetailRepository.GetGameDetails();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }

        /// <summary>
        /// Get GameDetail By Id
        /// </summary>
        /// <param name="gameDetailId"></param>
        /// <returns></returns>
        [HttpGet("GetGameDetailById")]
       
        public async Task<GameDetail> GetGameDetailById(string gameDetailId)
        {

           
                return await gameDetailRepository.GetGameDetailById(gameDetailId);


              

               // return data;

           

            
        }

        /// <summary>
        /// Get GameDetail By UserProfile Id
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        [HttpGet("GetGameDetailByUserProfileId")]
       
        public async Task<List<GameDetail>> GetGameDetailByUserProfileId(string userProfileId)
        {

            try
            {
                return await gameDetailRepository.GetGameDetailByUserProfileId(userProfileId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return null;
        }

        /// <summary>
        /// Delete GameDetail
        /// </summary>
        /// <param name="gameDetailId"></param>
        [HttpPost("DeleteGameDetail")]
        [Authorize]
        public void DeleteGameDetail(string gameDetailId)
        {

            try
            {
                gameDetailRepository.DeleteGameDetail(gameDetailId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }


        }

        /// <summary>
        /// Create GameDetail
        /// </summary>
        /// <param name="gameDetail"></param>
        [Authorize]
        [HttpPost("CreateGameDetail")]
        public void CreateGameDetail([FromBody] GameDetail gameDetail)
        {
            try
            {

                gameDetailRepository.InsertGameDetail(gameDetail);

            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }

        /// <summary>
        /// Update Rule
        /// </summary>
        /// <param name="gameDetail"></param>
        [Authorize]
        [HttpPost("UpdateRule")]
        public void UpdateRule([FromBody] GameDetail gameDetail)
        {
            try
            {
                gameDetailRepository.UpdateGameDetail(gameDetail);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }
    }
}
