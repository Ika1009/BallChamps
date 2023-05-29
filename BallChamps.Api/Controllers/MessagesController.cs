
using BallChamps.Domain;
using DataLayer;
using DataLayer.BallChamps;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Messages Controller
    /// </summary>
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {

        private IMessagesRepository messagesRepository;
        /// <summary>
        /// Messages Controller Constructor
        /// </summary>
        /// <param name="messagesContext"></param>
        public MessagesController(MessagesContext messagesContext)
        {
            this.messagesRepository = new MessagesRepository(messagesContext);

        }


        /// <summary>
        /// Get All Messagess
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetMessagess")]
        public async  Task<List<Messages>> GetMessagess()
        {
            try
            {
                return await messagesRepository.GetMessages();
            }
            catch (Exception ex)
            {
                var x = ex;
            }
            return null;
        }


        /// <summary>
        /// Get Messages By Id
        /// </summary>
        /// <param name="messagesId"></param>
        /// <returns></returns>
        [HttpGet("GetMessagesById")]
        [Authorize]
        public async Task<Messages> GetMessagesById(string messagesId)
        {

            try
            {
                return await messagesRepository.GetMessagesById(messagesId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

            return null;
        }


        /// <summary>
        /// Delete Messages
        /// </summary>
        /// <param name="messagesId"></param>
        [HttpPost("DeleteMessage")]
        [Authorize]
        public void DeleteMessage(string messagesId)
        {

            try
            {
                messagesRepository.DeleteMessage(messagesId);
            }
            catch (Exception ex)
            {
                var x = ex;
            }


        }


        /// <summary>
        /// Create new Messages
        /// </summary>
        /// <param name="messages"></param>
        [Authorize]
        [HttpPost("CreateMessages")]
        public void CreateMessages([FromBody] Messages messages)
        {
            try
            {

                messagesRepository.InsertMessage(messages);

            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }



        /// <summary>
        /// Update Messages Info
        /// </summary>
        /// <param name="messages"></param>
        [Authorize]
        [HttpPost("UpdateMessage")]
        public void UpdateMessage([FromBody] Messages messages)
        {
            try
            {
                messagesRepository.UpdateMessage(messages);
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }
    }
}
