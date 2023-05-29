using System;

namespace BusinessLogic
{
    public class UserLevel
    {
        public string UpdateUserUserLevel(string wins, string losses, string rating)
        {
            var total = Convert.ToDouble(wins) + Convert.ToDouble(losses);

            var percent = Convert.ToDecimal(wins) / (Convert.ToDecimal(total));

            return percent.ToString(".###");
        }
    }
}
