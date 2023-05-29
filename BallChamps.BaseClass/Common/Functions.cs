using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Functions
    {
        public static string Get8Digits() 
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }

        public static string GenerateSixDigit()
        {
            Random rnd = new Random();
            string num = rnd.Next(100000, 999999).ToString();

            return num;
        }

        public static bool IsConnectedToInternet()
        {
            bool isConnected;
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("maps.google.com",80);
            isConnected = tcpClient.Connected;

            return isConnected;
        }
    }
}
