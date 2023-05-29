using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Validation
    {

        public bool ValidateUsernameFormat(string username)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>,";
            foreach (var item in specialChar)
            {
                if (username.Contains(item)) return true;
            }

            return false;
        }


        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsUserNameAvailable(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }
}
