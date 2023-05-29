using BallChamps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallChampsBaseClass.Common.Model
{
    public class PasswordReset
    {
        public Task<User> user { get; set; }
        public string Link { get; set; }
        public string ResetURL { get; set; }
        public string Token { get; set; }
        public string ResetCode { get; set; }
    }
}
