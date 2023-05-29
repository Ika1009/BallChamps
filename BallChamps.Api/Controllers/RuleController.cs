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
    /// Rule Controller
    /// </summary>
    [Route("api/[controller]")]
    public class RuleController : Controller
    {

        private IRuleRepository ruleRepository;

        /// <summary>
        /// Rule Controller Constructor
        /// </summary>
        /// <param name="ruleContext"></param>
        public RuleController(RuleContext ruleContext)
        {
            this.ruleRepository = new RuleRepository(ruleContext);
        }

        /// <summary>
        /// Get All Rules
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRules")]
        public async  Task<List<Rule>> GetRules()
        {
            try
            {
                return await ruleRepository.GetRules();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }

        /// <summary>
        /// Get Rule By Id
        /// </summary>
        /// <param name="ruleId"></param>
        /// <returns></returns>
        [HttpGet("GetRuleById")]
        [Authorize]
        public async Task<Rule> GetRuleById(string ruleId)
        {

            try
            {
                return await ruleRepository.GetRuleById(ruleId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return null;
        }

        /// <summary>
        /// Delete Rule
        /// </summary>
        /// <param name="ruleId"></param>
        [HttpPost("DeleteRule")]
        [Authorize]
        public void DeleteRule(string ruleId)
        {
            try
            {
                ruleRepository.DeleteRule(ruleId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }

        /// <summary>
        /// Create new Rule
        /// </summary>
        /// <param name="rule"></param>
        [Authorize]
        [HttpPost("CreateRule")]
        public void CreateRule([FromBody] Rule rule)
        {
            try
            {

                ruleRepository.InsertRule(rule);

            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }


        /// <summary>
        /// Update Rule Info
        /// </summary>
        /// <param name="rule"></param>
        [Authorize]
        [HttpPost("UpdateRule")]
        public void UpdateRule([FromBody] Rule rule)
        {
            try
            {
                ruleRepository.UpdateRule(rule);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }
    }
}
