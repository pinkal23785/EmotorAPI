using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EMS.Domain.Entities
{
    public partial class PartnerServiceIssues
    {
        public int? PartnerServiceIssueId { get; set; }
        public int UserID { get; set; }
        public int? ServiceIssueId { get; set; }
        public float? LabourCost { get; set; }
        public float? TimeTaken { get; set; }
        public string Notes { get; set; }
        public DateTime PartnerIssueCreated { get; set; }
        public DateTime? PartnerIssueModified { get; set; }

        [JsonIgnore]
        public virtual ICollection<ServiceOrderIssues> ServiceOrderIssues { get; set; }

        public PartnerServiceIssues()
        {
            ServiceOrderIssues = new List<ServiceOrderIssues>();
        }
    }
}
