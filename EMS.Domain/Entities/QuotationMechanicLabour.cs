using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class QuotationMechanicLabour
    {
        public int QuoteMechanicLabourId { get; set; }
        public int QuoteCustomerMechanicId { get; set; }
        public int SkillId { get; set; }
        public double? LabourCost { get; set; }
        public float? TimeTaken { get; set; }
        public string Notes { get; set; }
    }
}
