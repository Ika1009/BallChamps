using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IRateRepository : IDisposable
    {
        Task<List<Rate>> GetRates();
        
    }
}
