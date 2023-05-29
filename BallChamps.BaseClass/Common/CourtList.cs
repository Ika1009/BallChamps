using ApiClient;
using DataLayer.DTO;


namespace BallChampsBaseClass.Common
{
    public static class CourtList
    {

        public static async Task<bool> UpdateCourtList(string CourtId, List<CourtWaitingListDTO> newList, string token)
        {
            bool result;

            try
            {

                foreach (var item in newList)
                {
                    item.CourtId = CourtId;
                    item.UserProfileId = await UserApi.GetUserProfileIdByUserName(item.UserName, token);
                    await CourtWaitingListApi.UpdateCourtWaitingListById(item, token);
                }

                result = true;
            }
            catch(Exception ex)
            {

                result = false;
            }

            return result;
        }
        public static async Task<bool> ReorderPlayerCourtList(string CourtId, string token)
        {
            bool result;

            var currentlist = await CourtWaitingListApi.GetCourtWaitingListByCourtId(CourtId, token);

            try
            {

                foreach (var item in currentlist)
                {
                    item.CourtId = CourtId;
                    item.UserProfileId = await UserApi.GetUserProfileIdByUserName(item.UserName, token);
                    item.Pos = currentlist.IndexOf(item) + 1;
                    await CourtWaitingListApi.UpdateCourtWaitingListById(item, token);
                }

                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return result;
        }

    }
}
