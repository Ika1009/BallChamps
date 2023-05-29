using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Rate Controller
    /// </summary>
    [Route("api/[controller]")]
    public class RateController : Controller
    {

        private IRateRepository rateRepository;

        /// <summary>
        /// Rate Controller
        /// </summary>
        /// <param name="rateContext"></param>
        public RateController(RateContext rateContext)
        {

            this.rateRepository = new RateRepository(rateContext);

        }

        /// <summary>
        /// Get Rates
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRates")]
        public async  Task<List<Rate>> GetRates()
        {
            try
            {
                return await rateRepository.GetRates();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }
    }
}
