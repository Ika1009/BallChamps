using BallChamps.Domain;
using DataLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataLayer.DAL
{
    /// <summary>
    /// Court Waiting List Repository
    /// </summary>
    public class CourtWaitingListRepository : ICourtWaitingListRepository, IDisposable
    {
       
       
        private CourtWaitingListContext _context;

        /// <summary>
        /// CourtWaitingList Repository
        /// </summary>
        /// <param name="context"></param>
        public CourtWaitingListRepository(CourtWaitingListContext context)
        {
            
            this._context = context;
          
        }

        /// <summary>
        /// Clear CourtWaiting List
        /// </summary>
        /// <param name="courtId"></param>
        public async Task ClearCourtWaitingList(string courtId)
        {
            var rows = from u in _context.CourtWaitingList select u;

            foreach (var row in rows)
            {
                _context.CourtWaitingList.Remove(row);
            }

            Save();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get CourtWaitingList By CourtId
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<List<CourtWaitingList>> GetCourtWaitingListByCourtId(string courtId)
        {
            List<CourtWaitingList> courtWaitingListDTO = new List<CourtWaitingList>();
            try
            {
                
             

                //foreach(var item in courtWaitingListDTO)
                //{
                //    if (item.HasImage == false)
                //    {
                //        item.ImagePath = UserProfileDefaultImagePath;
                //    }
                //}
                


                return courtWaitingListDTO.OrderBy(item=>item.Pos).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Get CourtWaitingLists
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<CourtWaitingList>> GetCourtWaitingLists()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetWaitingListCourtByUserProfileId
        /// </summary>
        /// <param name="userProfileId"></param>
        public async Task GetWaitingListCourtByProfileId(string profileId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert GuestPlayer To CourtWaitingList
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="courtId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task InsertGuestPlayerToCourtWaitingList(string userName, string courtId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert Player To CourtWaitingList
        /// </summary>
        /// <param name="courtWaitingList"></param>
        public async Task InsertPlayerToCourtWaitingList(CourtWaitingList courtWaitingList )
        {
            CourtWaitingList _courtWaitingList = new CourtWaitingList();

            try
            {

                int count = _context.CourtWaitingList.ToList().Where(x => x.CourtId == courtWaitingList.CourtId).Count();

                courtWaitingList.CourtWaitingListId = Guid.NewGuid().ToString();
                courtWaitingList.SignUpTime = DateTime.Now;
                
                
                courtWaitingList.Pos = (count + 1);

                if (Convert.ToInt32(courtWaitingList.Pos) <= 5)
                {
                    courtWaitingList.Img = "RedSquad.png";
                    courtWaitingList.Status = "On Court";
                    courtWaitingList.Team = "Red";
                }
                else if (Convert.ToInt32(courtWaitingList.Pos) >= 5 && Convert.ToInt32(courtWaitingList.Pos) < 10)
                {
                    courtWaitingList.Img = "BlueSquad.png";
                    courtWaitingList.Status = "On Court";
                    courtWaitingList.Team = "Blue";
                }
                else if (Convert.ToInt32(courtWaitingList.Pos) >= 10)
                {
                    courtWaitingList.Img = "NextSquad.png";
                    courtWaitingList.Status = "Waiting";
                    courtWaitingList.Team = string.Empty;
                }


                try
                {
                    _context.CourtWaitingList.Add(courtWaitingList);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// Is UserProfile SignedUp At Court
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="courtId"></param>
        /// <returns></returns>
        public async Task<bool> IsUserProfileSignedUpAtCourt(string profileId, string courtId)
        {
            bool isSignedUp = (from u in _context.CourtWaitingList
                               where u.CourtId == courtId && u.ProfileId == profileId
                               select u).Any();

            return isSignedUp; 
        }

        /// <summary>
        /// Is UserProfile SignedUpAt Any Court
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public async Task<bool> IsProfileSignedUpAtAnyCourt(string profile)
        {
            bool isSignedUp = (from u in _context.CourtWaitingList
                               where u.ProfileId == profile
                               select u).Any();

            return isSignedUp;
        }

        /// <summary>
        /// Remove Player From CourtWaitingList
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <returns></returns>
        public async Task RemovePlayerFromCourtWaitingList(string profileId)
        {
            CourtWaitingList courtWaitingList = (from u in _context.CourtWaitingList
                                                  where u.ProfileId == profileId
                                                  select u).FirstOrDefault();

            _context.CourtWaitingList.Remove(courtWaitingList);

            Save();
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update CourtWaiting List By Id
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public async Task UpdateCourtWaitingListById(CourtWaitingList courtWaitingListDTO)
        {

            try
            {

                using (SqlConnection conn = new SqlConnection(""))
                {
                    using (SqlCommand comm = new SqlCommand("UpdateCourtWaitingListById"))
                    {
                        //User Table Fields
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Connection = conn;
                        comm.Parameters.AddWithValue("@UserProfileId", courtWaitingListDTO.ProfileId);
                        comm.Parameters.AddWithValue("@CourtId", courtWaitingListDTO.CourtId);
                        comm.Parameters.AddWithValue("@Pos", courtWaitingListDTO.Pos);
                        
                        conn.Open();
                        comm.ExecuteNonQuery();

                    }

                    conn.Close();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        /// <summary>
        /// Update Player Position
        /// </summary>
        /// <param name="courtId"></param>
        /// <param name="userProfileId"></param>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        public async Task UpdatePlayerPosition(string courtId, string profileId, int newPosition)
        {
            //Update Players Positon
            CourtWaitingList model = _context.CourtWaitingList.Single(x => x.ProfileId == profileId);
            model.Pos = newPosition;

            if (Convert.ToInt32(newPosition) <= 5)
            {
                model.Img = "RedSquad.png";
            }
            else if (Convert.ToInt32(newPosition) > 5 && Convert.ToInt32(newPosition) <= 10)
            {
                model.Img = "BlueSquad.png";
            }
            else
            {
                model.Img = "NextSquad.png";
            }


            _context.CourtWaitingList.Update(model);
            Save();

        }

        /// <summary>
        /// Get Court UserProfile Is SignedUp At
        /// </summary>
        /// <param name="userProfileId"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        public async Task<CourtWaitingList> GetCourtProfileIsSignedUpAt(string profileId, string connStr)
        {
           

            CourtWaitingList courtWaitingListDTOTemp = new CourtWaitingList();
            try
            {
                
            
                return (courtWaitingListDTOTemp);
            }
            catch (Exception ex)
            {
               

              Console.WriteLine(ex.ToString());
                return (courtWaitingListDTOTemp);
            }

            

          
        }

        public Task<bool> IsProfileSignedUpAtCourt(string profile, string courtId)
        {
            throw new NotImplementedException();
        }

        public Task<CourtWaitingList> GetCourtProfileIsSignedUpAt(string profile)
        {
            throw new NotImplementedException();
        }
    }

}
