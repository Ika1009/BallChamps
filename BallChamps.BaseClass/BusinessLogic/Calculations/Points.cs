using System;

namespace BusinessLogic
{
    public class Points
    {
        public string UpdateUserPoints(string wins, string losses)
        {
            var total = Convert.ToDouble(wins) + Convert.ToDouble(losses);

            var percent = Convert.ToDecimal(wins) / (Convert.ToDecimal(total));

            return percent.ToString(".###");
        }
    }
}
