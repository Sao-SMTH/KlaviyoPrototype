using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaviyoPrototype.Interface
{
    public interface IKlaviyoEmailService
    {
        Task<bool> SendEmailAsync(KlaviyoEmailData emailData);
    }
}