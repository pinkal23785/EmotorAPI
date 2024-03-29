using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class DealerAttributes
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string GarageName { get; set; }
        public TimeSpan StartHours { get; set; }
        public TimeSpan EndHours { get; set; }
        public float Experience { get; set; }
        public bool IsOnsiteSupport { get; set; }
        public bool Is24Support { get; set; }
        public string Longitute { get; set; }
        public string Latitute { get; set; }
        public int DistanceCovered { get; set; }
        public bool IsOwnGarage { get; set; }
        public int TotalHelpers { get; set; }
        public int TotalMechanics { get; set; }
        public byte CurrentStatus { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
