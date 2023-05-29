using Azure.Core;
using BallChampsBaseClass.Common.Model;
using Microsoft.Extensions.Configuration;
using Nancy;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;

namespace BallChamps.Messaging
{
    public class Messaging
    {
        private readonly IConfiguration _configuration;


        public Messaging(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        // GET: SendMessages/ContactUs/
        /// <summary>
        /// ContactUs
        /// </summary>
        /// <returns></returns>     
        public async void ContactUs(string Name, string Email, string Message)
        {
            try
            {


                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("userxcelllc@gmail.com", "BallChamps Group");
                List<EmailAddress> tos = new List<EmailAddress>
          {
              new EmailAddress("erickcastillo404@gmail.com"),




          };
                var subject = "New inquiry via MSG website!!";
                var htmlContent = "<p>Email From : {0}</p><p> Name : {1}   </p><p>Message :{2}</p>";
                

                string bodyFormat = string.Format(htmlContent, Email, Name, Message);
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", bodyFormat, false);
                await client.SendEmailAsync(msg);
                //ViewBag.msg = "Message Has been Sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




        }


        // GET: SendMessages/SendTempPassword/
        /// <summary>
        /// SendTempPassword
        /// </summary>
        /// <returns></returns>     
        public async void SendTempPassword(string Name, string Email, string Message)
        {
            try
            {


                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("userxcelllc@gmail.com", "BallChamps Group");
                List<EmailAddress> tos = new List<EmailAddress>
          {
              new EmailAddress("erickcastillo404@gmail.com"),




          };
                var subject = "New inquiry via MSG website!!";
                var htmlContent = "<p>Email From : {0}</p><p> Name : {1}   </p><p>Message :{2}</p>";
                

                string bodyFormat = string.Format(htmlContent, Email, Name, Message);
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", bodyFormat, false);
                await client.SendEmailAsync(msg);
                //ViewBag.msg = "Message Has been Sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        // GET: SendMessages/SendTempPassword/
        /// <summary>
        /// SendTempPassword
        /// </summary>
        /// <returns></returns>     
        public async void SendPasswordResetLinkEmail(PasswordReset data)
        {
            try
            {
                
                

                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("userxcelllc@gmail.com", "BallChamps Group");
                List<EmailAddress> tos = new List<EmailAddress>
          {
              new EmailAddress("erickcastillo404@gmail.com"),




          };
                var subject = "Reset Password!!";
                var htmlContent = "<p>Email From : {0}</p><p> Name : {1}   </p><p>Message :{2}</p>";
                

                string bodyFormat = string.Format(htmlContent, data.user.Result.Email, "");
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", bodyFormat, false);
                await client.SendEmailAsync(msg);
                //ViewBag.msg = "Message Has been Sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public async void SignUp(string Name, string Email)
        {
            try
            {
                var Message = "";

                var apiKey = _configuration.GetSection("SENDGRID_API_KEY").Value;

                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("userxcelllc@gmail.com", "BallChamps Group");
                List<EmailAddress> tos = new List<EmailAddress>
          {
              new EmailAddress("erickcastillo404@gmail.com"),




          };
                var subject = "New Ball Champs Hooper!!";
                var htmlContent = "<p>Email From : {0}</p><p> Name : {1}   </p><p>Message :{2}</p>";
                

                string bodyFormat = string.Format(htmlContent, Email, Name, Message);
                var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", bodyFormat, false);
                await client.SendEmailAsync(msg);
                // ViewBag.msg = "Message Has been Sent";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }
}
