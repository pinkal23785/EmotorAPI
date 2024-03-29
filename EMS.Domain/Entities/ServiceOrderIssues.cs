//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EMS.Domain.Entities
{
    public partial class ServiceOrderIssues
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ServiceOrderIssueId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ServiceOrderId { get; set; }
        public float LabourCost { get; set; }
        public float TimeTaken { get; set; }
        public string Notes { get; set; }
        public int PartnerServiceIssueId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime Modified { get; set; }

        [JsonIgnore]
        public virtual PartnerServiceIssues PartnerServiceIssues { get; set; }
        [JsonIgnore]
        public virtual ServiceOrders ServiceOrders { get; set; }
    }
}
