using System;

namespace BusinessLogic
{
    public class Rank
    {
        public string UpdateUserRank(string wins, string losses)
        {
            var total = Convert.ToDouble(wins) + Convert.ToDouble(losses);

            var percent = Convert.ToDecimal(wins) / (Convert.ToDecimal(total));

            return percent.ToString(".###");
        }
    }
}
