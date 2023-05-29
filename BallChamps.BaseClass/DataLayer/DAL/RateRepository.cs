using BallChamps.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class RateRepository : IRateRepository, IDisposable
    {
        private RateContext _context;


        public RateRepository(RateContext context)
        {
            this._context = context;
            
        }
             
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Get All Rate List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Rate>> GetRates()
        {

            return await _context.Rate.ToListAsync();
        }

    }
}
