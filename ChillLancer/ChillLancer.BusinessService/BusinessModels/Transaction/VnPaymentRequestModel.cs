using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.BusinessModels.Transaction
{
    public class VnPaymentRequestModel
    {
        public Guid OrderId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
