//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EMS.Domain.Entities
{
    public partial class ServiceOrders
    {
        [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingNull)]
        public int? ServiceOrderId { get; set; }
        public string ServiceOrderType { get; set; }
        public int? CustomerId { get; set; }
        public int? MechanicId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? Manufacture { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public byte? Status { get; set; }
        public bool? IsPartNeeded { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string SLA { get; set; }
        public int? QuotationId { get; set; }
        public bool? IsPartDelivered { get; set; }

        public string VehicleType { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleFuelType { get; set; }

        public virtual ICollection<ServiceOrderIssues> ServiceOrderIssues { get; set; }

        public ServiceOrders()
        {
            ServiceOrderIssues = new List<ServiceOrderIssues>();
        }

    }
}
