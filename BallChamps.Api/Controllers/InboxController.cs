
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
    /// Inbox Controller
    /// </summary>
    [Route("api/[controller]")]
    public class InboxController : Controller
    {

        private IInboxRepository inboxRepository;
        /// <summary>
        /// Inbox Controller Constructor
        /// </summary>
        /// <param name="inboxContext"></param>
        public InboxController(InboxContext inboxContext)
        {
            this.inboxRepository = new InboxRepository(inboxContext);

        }

        /// <summary>
        /// Get Inbox By Id
        /// </summary>
        /// <param name="inboxId"></param>
        /// <returns></returns>
        [HttpGet("GetInboxByUserProfileId")]
      
        public async Task<List<Inbox>> GetInboxByUserProfileId(string userProfileId)
        {

            try
            {
                return await inboxRepository.GetInboxByUserProfileId(userProfileId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get Inbox By Id
        /// </summary>
        /// <param name="inboxId"></param>
        /// <returns></returns>
        [HttpGet("GetInboxById")]

        public async Task<Inbox> GetInboxById(string inboxId)
        {

            try
            {
                return await inboxRepository.GetInboxById(inboxId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }


        /// <summary>
        /// Delete Inbox
        /// </summary>
        /// <param name="inboxId"></param>
        [HttpPost("DeleteInbox")]
        [Authorize]
        public void DeleteInbox(string inboxId)
        {

            try
            {
                inboxRepository.DeleteInbox(inboxId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        /// <summary>
        /// Create new Inbox
        /// </summary>
        /// <param name="inbox"></param>

        [HttpPost("CreateInbox")]
        public void CreateBlog([FromBody] Inbox inbox)
        {
            try
            {

                inboxRepository.InsertInbox(inbox);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }



        /// <summary>
        /// Update Inbox Info
        /// </summary>
        /// <param name="inbox"></param>
        [Authorize]
        [HttpPost("UpdateInbox")]
        public void UpdateInbox([FromBody] Inbox inbox)
        {
            try
            {
                inboxRepository.UpdateInbox(inbox);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
