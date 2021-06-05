// Created by Derek Kennard
// Solution: SES
// Project Name: SES
// File Name: SESController.cs
// Created on: 03/14/2021 at 11:44 PM
// Edited on: 06/05/2021 at 1:22 PM
// Developed and Copyrighted by Derek "Doctork" Kennard

#region imports

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace SES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SESController : ControllerBase
    {
        private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;
        private readonly string _body = "<h1>It Worked</h1> <p>So Happy</p>";
        private readonly string _fromAddress = "youre_address@email.com";
        private readonly string _subject = "SES";
        private readonly string _toAddress = "youre_address@email.com";


        public SESController(IAmazonSimpleEmailService amazonSimpleEmailService)
        {
            _amazonSimpleEmailService = amazonSimpleEmailService;
        }

        [HttpGet]
        public async Task<ActionResult> SendEmail()
        {
            var sendEmailRequest = new SendEmailRequest
            {
                Destination = new Destination
                {
                    ToAddresses = new List<string> {_toAddress}
                },
                Message = new Message
                {
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = _body
                        }
                    },
                    Subject = new Content
                    {
                        Charset = "UTF-8",
                        Data = _subject
                    }
                },
                Source = _fromAddress
            };

            var sendResult = await _amazonSimpleEmailService.SendEmailAsync(sendEmailRequest);
            if (sendResult.HttpStatusCode != HttpStatusCode.OK) return BadRequest("Something went wrong");

            return Ok("Email Sent");
        }
    }
}