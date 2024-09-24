using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KlaviyoPrototype.DTO
{
    public class CustomFieldDTO : KlaviyoEmailDTO
    {
        public string order_id { get; set; }
        public float value { get; set; }
    }
}