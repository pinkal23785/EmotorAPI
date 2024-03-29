using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
  public  class QuotationParts
    {
        public int QuatationPartId { get; set; }
        public int QuotationId { get; set; }
        public int MechanicId { get; set; }
        public string PartType { get; set; }
        public string PartName { get; set; }
        public int Qty { get; set; }
        public double Cost { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
