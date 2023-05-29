using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BallChamps.Domain;

namespace DataLayer.DAL
{
    public interface IRuleRepository : IDisposable
    {
        Task<List<Rule>> GetRules();
        Task<Rule> GetRuleById(string ruleId);
        Task InsertRule(Rule rule);
        Task DeleteRule(string ruleId);
        Task UpdateRule(Rule rule);        
        Task<int> Save();

    }
}
