using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using KlaviyoPrototype.DTO;
using KlaviyoPrototype.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace KlaviyoPrototype.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _apiKey;

        public EmailService(IConfiguration config)
        {
            _config = config;
            _apiKey = _config.GetValue<string>("Klaviyo_API_Key");
            _httpClient = new HttpClient();
        }

        public async Task<bool> SendEventAsync(string eventName, string email, CustomFieldDTO properties)
        {
            var url = $"https://a.klaviyo.com/api/track?data={GetEncodedData(eventName, email, properties)}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                //throw new Exception($"Failed to send event. Status code: {response.StatusCode}");
                return false;
            }
            return true;
        }
        private string GetEncodedData(string eventName, string email, CustomFieldDTO properties)
        {
            var data = new
            {
                token = _apiKey,
                @event = eventName,
                customer_properties = new
                {
                    email = email
                },
                properties = properties,
                time = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };

            var jsonData = JsonConvert.SerializeObject(data);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonData));
        }

    }
}