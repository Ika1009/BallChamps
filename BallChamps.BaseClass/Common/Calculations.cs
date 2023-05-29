
using DataLayer.DTO;


namespace BallChampsBaseClass.Common
{
    public static class Calculations
    {

        /// <summary>
        /// betting Chance Calculation
        /// </summary>
        /// <param name="courtWaitingList"></param>
        /// <returns></returns>
        public static (decimal,decimal) bettingChanceCalculation(List<CourtWaitingListDTO> courtWaitingList)
        {
            decimal winPercentageRedTeamTotal = 0;
            decimal winPercentageBlueTeamTotal = 0;

            decimal TotalOfBothTeams;

            decimal redTeamWinPercentageResult;
            decimal blueTeamWinPercentageResult;


            foreach (var item in courtWaitingList)
            {
                if(item.Team == "Red")
                {
                    winPercentageRedTeamTotal++;
                }

                if (item.Team == "Blue")
                {
                    winPercentageBlueTeamTotal++;
                }
            }


            TotalOfBothTeams = winPercentageRedTeamTotal + winPercentageBlueTeamTotal;

            redTeamWinPercentageResult = winPercentageRedTeamTotal / TotalOfBothTeams;
            blueTeamWinPercentageResult = winPercentageBlueTeamTotal / TotalOfBothTeams;


           
            return (redTeamWinPercentageResult, blueTeamWinPercentageResult);
        }

    }
}
