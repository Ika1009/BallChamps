using System;

namespace BusinessLogic
{
    public class WinPercentage
    {
        public decimal UserWinPercentage(decimal wins, decimal losses)
        {
            if(wins == 0 && losses == 0)
            {
                return 0;
            }

            decimal total =  wins + losses;

            decimal percent = wins / total;

            return percent;
        }

    }
}
