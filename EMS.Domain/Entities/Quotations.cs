using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class Quotations
    {
        public int QuotationId { get; set; }
        public int CustomerId { get; set; }
        //public int VehicleType { get; set; }
        //public int VehicleBrand { get; set; }
        public int VehicleModel { get; set; }
        public int Manufacture { get; set; }
        public string Notes { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public DateTime QuoteExpireTime { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        public virtual ICollection<QuotationIssues> QuotationIssues {get; set;}
        
        public Quotations()
        {
            QuotationIssues = new List<QuotationIssues>();
        }
    }
}
