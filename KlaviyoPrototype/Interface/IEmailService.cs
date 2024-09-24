using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KlaviyoPrototype.DTO;

namespace KlaviyoPrototype.Interface
{
    public interface IEmailService
    {
        Task<bool> SendEventAsync(string eventName, string email, CustomFieldDTO properties);
    }
}