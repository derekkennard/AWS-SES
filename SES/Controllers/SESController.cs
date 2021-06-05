using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace SES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SESController : ControllerBase
    {
        private readonly IAmazonSimpleEmailService _amazonSimpleEmailService;
        private string _fromAddress = "derek.kennard@gmail.com";
        private string _toAddress = "derek.kennard@gmail.com";
        private string _subject = "SES";
        private string _body = "<h1>It Worked</h1> <p>So Happy</p>";


        public SESController(IAmazonSimpleEmailService amazonSimpleEmailService)
        {
            _amazonSimpleEmailService = amazonSimpleEmailService;
        }

        [HttpGet]
        public async Task<ActionResult> SendEmail()
        {
            SendEmailRequest sendEmailRequest = new SendEmailRequest()
            {
                Destination = new Destination()
                {
                    ToAddresses = new List<string>() {_toAddress}
                }, Message = new Message()
                {
                    Body = new Body
                    {
                        Html = new Content()
                        {
                            Charset = "UTF-8",
                            Data = _body
                        }                        
                    },
                    Subject = new Content()
                    {
                        Charset = "UTF-8",
                        Data = _subject
                    }
                }, 
                Source = _fromAddress
            };

            var sendResult = await _amazonSimpleEmailService.SendEmailAsync(sendEmailRequest);
            if(sendResult.HttpStatusCode != System.Net.HttpStatusCode.OK)
            {
                return BadRequest("Something went wrong");
            }

            return Ok("Email Sent");
        }

    }
}
