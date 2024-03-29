using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.ServiceOrder
{
    public class ServiceOrderRequest 
    {
        public string ServiceOrderType { get; set; }
        public int CustomerId { get; set; }
        public int MechanicId { get; set; }
        public int ServiceCenterId { get; set; }
        public int Manufacture { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public byte Status { get; set; }
        public bool IsPartNeeded { get; set; }
        public DateTime? ScheduleTime { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string SLA { get; set; }
        public int QuotationId { get; set; }
        public bool IsPartDelivered { get; set; }

        public List<ServiceOrderIssues> ServiceOrderIssues { get; set; }
    }
}
