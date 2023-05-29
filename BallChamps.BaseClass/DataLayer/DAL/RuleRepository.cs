using BallChamps.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataLayer.DAL
{
    public class RuleRepository : IRuleRepository, IDisposable
    {
        private RuleContext _context;

        public RuleRepository(RuleContext context)
        {
            this._context = context;
            
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blogId"></param>
        public async Task DeleteRule(string ruleId)
        {
            Rule rule = (from u in _context.Rule
                         where u.RuleId == ruleId
                         select u).FirstOrDefault();

            _context.Rule.Remove(rule);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Blog By ID
        /// </summary>
        /// <param name="RuleId"></param>
        /// <returns></returns>
        public async Task<Rule> GetRuleById(string ruleId)
        {

            Rule rule = (from u in _context.Rule
                         where u.RuleId == ruleId
                         select u).FirstOrDefault();

            return rule;
        }

        /// <summary>
        /// Get All Rules List
        /// </summary>
        /// <returns></returns>
        public async Task<List<Rule>> GetRules()
        {

            return await _context.Rule.ToListAsync();
        }

        /// <summary>
        /// Insert New Blog
        /// </summary>
        /// <param name="blog"></param>
        public async Task InsertRule(Rule rule)
        {
            rule.RuleId = Guid.NewGuid().ToString();

            _context.Rule.Add(rule);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Blog Info
        /// </summary>
        /// <param name="blog"></param>
        public async Task  UpdateRule(Rule rule)
        {
            _context.Entry(rule).State = EntityState.Modified;
            Save();
        }
       
    }
}
