using BallChamps.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallChamps.Services
{
    public static class UserService
    {
        public static User CurrentUser { get; set; }

        public static async Task SetTokenAsync(string token)
        {
            await SecureStorage.SetAsync("user_token", token);
        }

        public static async Task<string> GetTokenAsync()
        {
            return await SecureStorage.GetAsync("user_token");
        }
        public static void RemoveToken()
        {
            SecureStorage.Remove("user_token");
        }
    }
}
