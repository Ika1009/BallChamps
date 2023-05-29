using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BallChamps.Domain;
using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// Event Controller
    /// </summary>
    [Route("api/[controller]")]
    public class EventController : Controller
    {

        private IEventRepository eventRepository;
        
        private readonly IConfiguration _configuration;


        /// <summary>
        /// Event Controller
        /// </summary>
        /// <param name="bC_EventContext"></param>
        /// <param name="configuration"></param>
        public EventController(EventContext bC_EventContext, IConfiguration configuration)
        {

            this._configuration = configuration;
            this.eventRepository = new EventRepository(bC_EventContext);

        }

        /// <summary>
        /// Get Events
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetEvents")]
        //[Authorize]
        public async Task<List<Event>> GetEvents()
        {
            return await eventRepository.GetEvents();
        }

        /// <summary>
        /// Get EventId
        /// </summary>
        /// <param name="bC_EventId"></param>
        /// <returns></returns>
        [HttpGet("GetEventId")]
        //[Authorize]
        public async Task<Event>? GetEventId(string eventId)
        {
            try
            {
                return await eventRepository.GetEventById(eventId);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Create new Event
        /// </summary>
        /// <param name="eent"></param>
        [HttpPost("CreateEvent")]
        public void CreateEvent([FromBody] Event _event)
        {
           

            try
            {
                eventRepository.InsertEvent(_event);

               
            }
            catch (Exception ex)
            {
                var x = ex;
            }

        }

        /// <summary>
        /// Delete EventId
        /// </summary>
        /// <param name="bC_EventId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("DeleteEventById")]
        public HttpResponseMessage DeleteEventById(string bC_EventId)
        {
            return null;
        }

        /// <summary>
        /// Update Event
        /// </summary>
        /// <param name="_event"></param>
        [Authorize]
        [HttpPost("UpdateEvent")]
        public void UpdateBC_Event([FromBody] Event _event)
        {

            try
            {
                eventRepository.UpdateEvent(_event);

            }
            catch
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest);

            }

        }
      
    }
}
