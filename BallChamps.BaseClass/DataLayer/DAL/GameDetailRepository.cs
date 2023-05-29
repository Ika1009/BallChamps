using BallChamps.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataLayer.DAL
{
    public class GameDetailRepository : IGameDetailRepository, IDisposable
    {
        private GameDetailContext _context;
        private CourtContext _courtContext;

        public GameDetailRepository(GameDetailContext context, CourtContext courtContext)
        {
            this._context = context;
            this._courtContext = courtContext;

        }

        /// <summary>
        /// Delete Game Detail
        /// </summary>
        /// <param name="blogId"></param>
        public async Task DeleteGameDetail(string gameDetailId)
        {
            GameDetail gameDetail = (from u in _context.GameDetail
                               where u.GameDetailId == gameDetailId
                               select u).FirstOrDefault();

            _context.GameDetail.Remove(gameDetail);

        }
       
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Game Detail By Id
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        public async Task<GameDetail> GetGameDetailById(string Id)
        {

            GameDetail model = (from u in _context.GameDetail
                               where u.GameDetailId == Id
                               select u).FirstOrDefault();

            return model;
        }

        /// <summary>
        /// Get GameDetail By UserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        public async Task<List<GameDetail>> GetGameDetailByUserProfileId(string userProfileId)
        {
            List<GameDetail> results = new List<GameDetail>();

            //GameDetail gameDetail = (from u in _context.GameDetail
            //                         where u.GameDetailId == gameDetailId
            //                         select u).ToListAsync();
            

            foreach (var item in _context.GameDetail)
            {
                List<string> listStrLineElements;
                listStrLineElements = item.TeamA.Split(',').ToList();

                var itemCourtName = _courtContext.Court.Where(x => x.CourtId == item.CourtId).Select(g=>g.CourtName).FirstOrDefault();

                foreach (var st in listStrLineElements)
                {
                    if(st == userProfileId)
                    {

                        if(item.WinningTeam == "A")
                        {
                            item.WinningTeam = "Team A";
                            item.WinOrLose = "Win";
                        }
                        else
                        {
                            item.WinningTeam = "Team B";
                            item.WinOrLose = "Lose";
                        }

                        //string courtName = _courtContext.Court.Select(x => x.CourtName == item.CourtId).Where;
                        //var courtName = _courtContext.Court.Where(x => x.CourtId == item.CourtId).Distinct();

                        item.CourtName = itemCourtName;

                        results.Add(item);
                    }
                }


                List<String> listStrLineElementsTeamB;


                listStrLineElementsTeamB = item.TeamB.Split(',').ToList();

                foreach (var st in listStrLineElementsTeamB)
                {
                    if (st == userProfileId)
                    {

                        if (item.WinningTeam == "B")
                        {
                            item.WinningTeam = "Team B";
                            item.WinOrLose = "Lose";
                        }
                        else
                        {
                            item.WinningTeam = "Team A";
                            item.WinOrLose = "Win";
                        }

                        string courtName = _courtContext.Court.Where(x => x.CourtName == item.CourtId).Select(g => g.CourtName.First()).ToString();

                        item.CourtName = courtName;

                        results.Add(item);
                    }
                }
            }



            return results;
        }

        /// <summary>
        /// Get Game Details
        /// </summary>
        /// <returns></returns>
        public async Task<List<GameDetail>> GetGameDetails()
        {

            return await _context.GameDetail.ToListAsync();
        }

        /// <summary>
        /// Insert Game Detail
        /// </summary>
        /// <param name="model"></param>
        public async Task InsertGameDetail(GameDetail model)
        {
            model.GameDetailId = Guid.NewGuid().ToString();

            _context.GameDetail.Add(model);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update Model Info
        /// </summary>
        /// <param name="model"></param>
        public async Task UpdateGameDetail(GameDetail model)
        {
            _context.Entry(model).State = EntityState.Modified;
            Save();
        }

       
    }
}
