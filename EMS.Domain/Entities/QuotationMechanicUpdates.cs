using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class QuotationMechanicUpdates
    {
        public int QuotationIssueId { get; set; }
        public int QuotationCMId { get; set; }
        public int IssueId { get; set; }
        public int SkillId { get; set; }
        public int MechanicId { get; set; }
        public double? LabourCost { get; set; }
        public float? TimeTaken { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

    }
}
