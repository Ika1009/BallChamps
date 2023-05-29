using BallChamps.Domain;
using DataLayer;
using DataLayer.BallChamps;
using DataLayer.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using System.Text.Json;

namespace BallChampsApi.Controllers
{
    /// <summary>
    /// NewsFeed Controller
    /// </summary>
    [Route("api/[controller]")]
    public class NewsFeedController : Controller
    {
        HttpResponseMessage returnMessage = new HttpResponseMessage();
        private INewsFeedRepository newsFeedRepository;
        /// <summary>
        /// NewsFeed Controller Constructor
        /// </summary>
        /// <param name="newsFeedContext"></param>
        public NewsFeedController(NewsFeedContext newsFeedContext, ProductContext contextProduct, CourtContext contextCourt, CampaignContext contextCampaign)
        {
            this.newsFeedRepository = new NewsFeedRepository(newsFeedContext, contextProduct, contextCourt, contextCampaign);
        }

        /// <summary>
        /// Get All NewsFeeds
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetNewsFeeds")]
        public async  Task<List<NewsFeed>> GetNewsFeeds()
        {
            try
            {
                return await newsFeedRepository.GetNewsFeeds();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Get NewsFeed By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        [HttpGet("GetNewsFeedById")]
        //[Authorize]
        public async Task<NewsFeed> GetNewsFeedById(string newsFeedId)
        {

            try
            {
                return await newsFeedRepository.GetNewsFeedById(newsFeedId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Delete NewsFeed
        /// </summary>
        /// <param name="newsFeedId"></param>
        [HttpDelete("DeleteNewsFeed")]
        //[Authorize]
        public async Task<HttpResponseMessage> DeleteNewsFeed(string newsFeedId)
        {

            try
            {
                await newsFeedRepository.DeleteNewsFeed(newsFeedId);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "DeleteNewsFeed");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return await Task.FromResult(returnMessage);

        }

        /// <summary>
        /// Insert NewsFeed
        /// </summary>
        /// <param name="newsFeed"></param>
        //[Authorize]
        [HttpPost("InsertNewsFeed")]
        public async Task<HttpResponseMessage> InsertNewsFeed([FromBody] NewsFeed newsFeed)
        {
            try
            {

                await newsFeedRepository.InsertNewsFeed(newsFeed);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "InsertNewsFeed");

                return await Task.FromResult(returnMessage);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return await Task.FromResult(returnMessage);
        }

        /// <summary>
        /// Update NewsFeed Info
        /// </summary>
        /// <param name="newsFeed"></param>
        //[Authorize]
        [HttpPost("UpdateNewsFeed")]
        public async Task<HttpResponseMessage> UpdateNewsFeed([FromBody] NewsFeed newsFeed)
        {
            try
            {
                await newsFeedRepository.UpdateNewsFeed(newsFeed);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "InsertNewsFeed");

                return await Task.FromResult(returnMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return await Task.FromResult(returnMessage);
        }


        /// <summary>
        /// ExistInNewFeed
        /// </summary>
        /// <param name="newsFeed"></param>
        //[Authorize]
        [HttpGet("ExistInNewsFeed")]
        public async Task<bool> ExistInNewsFeed(string Id, string objectType)
        {

            try
            {
                var result = await newsFeedRepository.ExistInNewFeed(Id, objectType);

                returnMessage.RequestMessage = new HttpRequestMessage(HttpMethod.Post, "ExistInNewFeed");

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
