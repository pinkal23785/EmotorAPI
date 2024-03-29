using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class ServiceIssues
    {
        public int ServiceIssueId { get; set; }
        public int RecordId { get; set; }
        public string IssueName { get; set; }
        public int SkillId { get; set; }
        public int? ParentId { get; set; }
        public bool? IsCar { get; set; }
        public bool? IsBike { get; set; }
        public bool? IsTruck { get; set; }
        public bool? IsTractor { get; set; }
        public bool? Is3Wheeler { get; set; }
        public bool? IsMiniTruck { get; set; }
        public bool? IsConstruction { get; set; }
        public bool? IsBus { get; set; }
        public bool? IsPetrol { get; set; }
        public bool? IsDiesel { get; set; }
        public bool? IsCNG { get; set; }
        public bool? IsLPG { get; set; }
        public bool? IsElectric { get; set; }
        public bool? IsHybrid { get; set; }
        public bool? IsActualService { get; set; }
        public bool? IsPopularService { get; set; }
        public string Icon { get; set; }
        public DateTime? ServiceIssueCreated { get; set; }
        public DateTime? ServiceIssueModified { get; set; }

    }
}
