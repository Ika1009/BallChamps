using BallChamps.Domain;
using DataLayer.DTO;

namespace BallChampsBaseClass.BusinessLogic.Calculations
{
    public class SquadCal
    {

        public static int SquadRating(List<SquadDTO> squadList)
        {
            int rating = 0;

            foreach(var item in squadList)
            {
                if(item.StarRating == 1)
                {
                    rating = rating + 2;
                }
                if (item.StarRating == 2)
                {
                    rating = rating + 4;
                }
                if (item.StarRating == 3)
                {
                    rating = rating + 6;
                }
                if (item.StarRating == 4)
                {
                    rating = rating + 8;
                }
                if (item.StarRating == 5)
                {
                    rating = rating + 10;
                }


                if (item.WinPercentage >= 1)
                {
                    rating = rating + 10;
                }

                if (item.WinPercentage <= 8 && item.WinPercentage > 6)
                {
                    rating = rating + 8;
                }

                if (item.WinPercentage <= 6 && item.WinPercentage > 4)
                {
                    rating = rating + 6;
                }
                if (item.WinPercentage <= 4 && item.WinPercentage > 2)
                {
                    rating = rating + 4;
                }
                if (item.WinPercentage <= 2 && item.WinPercentage > 0)
                {
                    rating = rating + 2;
                }

            }




            return rating;
        }

    }
}
