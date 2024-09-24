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
        public async Task<IActionResult> SendEmail(KlaviyoEmailDTO data)
        {
            var eventName = "order_placed";
            var properties = new
            {
                order_id = data.OrderNumber,
                value = data.ItemList.Sum(x => x.Price),
                #region CustomFields
                data.Email,
                data.FirstName,
                data.LastName,
                data.AnimatedLogo,
                data.OrderNumber,
                data.DeliveryAddress,
                data.PaymentType,
                data.DateOfOrder,
                data.DeliveryMethod,
                data.Coins,
                data.ItemList,
                #endregion
            };

            await _klaviyoService.SendEventAsync(eventName, data.Email, properties);

            return Ok(new { message = "Email event sent!" });
        }
    }
}