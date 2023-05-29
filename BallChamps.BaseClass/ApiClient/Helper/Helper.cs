using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Helper
{
    public class WebApi
    {
     
        public HttpClient Intial()
        {
            var Client = new HttpClient();

            //Production Enviornment
            Client.BaseAddress = new Uri("https://ballchampswebapi.azurewebsites.net");

            //Client.BaseAddress = new Uri("https://ballchampswebapi.ballchamps.com");

            //Staging Enviornment
            //Client.BaseAddress = new Uri("https://userxcelapi-staging.azurewebsites.net/");

            //Dev enviornment
            //Client.BaseAddress = new Uri("https://ballchampsapis-dev.azurewebsites.net");


            //Local
            //Client.BaseAddress = new Uri("https://localhost:44396/");


            ///swagger/index.html

            return Client;
        }


    }
}
