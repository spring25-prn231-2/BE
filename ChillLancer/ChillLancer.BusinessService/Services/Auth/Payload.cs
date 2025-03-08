using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.Services.Auth
{
    public class Payload
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}
