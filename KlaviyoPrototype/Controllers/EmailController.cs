using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaviyoPrototype.Interface;
using KlaviyoPrototype.Services;
using Microsoft.AspNetCore.Mvc;

namespace KlaviyoPrototype.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _klaviyoService;

        public EmailController(IEmailService emailService)
        {
            // Use your API key from Klaviyo here
            _klaviyoService = emailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var eventName = "order_placed";
            Random random = new Random();

            // Generate a random integer
            int randomNumber = random.Next();
            var properties = new
            {
                order_id = randomNumber,
                value = Convert.ToInt32(randomNumber),
                customer_name = "James Bond" + randomNumber, // Custom field
                order_items = new[] { "item1-" + randomNumber, "item2-" + randomNumber } // Another custom field
            };

            await _klaviyoService.SendEventAsync(eventName, email, properties);

            return Ok(new { message = "Email event sent!" });
        }
    }
}