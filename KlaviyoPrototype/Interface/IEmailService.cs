using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaviyoPrototype.Interface
{
    public interface IEmailService
    {
        Task<bool> SendEventAsync(string eventName, string email, object properties);
    }
}