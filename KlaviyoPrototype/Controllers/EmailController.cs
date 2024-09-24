using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaviyoPrototype.DTO;
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
            var properties = new CustomFieldDTO
            {
                order_id = data.OrderNumber,
                value = data.ItemList.Sum(x => x.Price),
                #region CustomFields
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName,
                AnimatedLogo = data.AnimatedLogo,
                OrderNumber = data.OrderNumber,
                DeliveryAddress = data.DeliveryAddress,
                PaymentType = data.PaymentType,
                DateOfOrder = data.DateOfOrder,
                DeliveryMethod = data.DeliveryMethod,
                Coins = data.Coins,
                ItemList = data.ItemList,
                #endregion
            };

            await _klaviyoService.SendEventAsync(eventName, data.Email, properties);

            return Ok(new { message = "Email event sent!" });
        }
    }
}