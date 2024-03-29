using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class QuoteCustomerToMechanic
    {
        public int QuoteCustomerMechanicId { get; set; }
        public int QuotationId { get; set; }
        public int MechanicId { get; set; }
        public byte Status { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
