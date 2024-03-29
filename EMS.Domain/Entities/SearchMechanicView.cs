using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class SearchMechanicView
    {
        public int MechanicID { get; set; }
        public string MechanicName { get; set; }
        public string MobileNumber { get; set; }
        public string GarageName { get; set; }
        public bool? IsFieldSupport { get; set; }
        public bool? Is24Support { get; set; }
        public TimeSpan StartHour { get; set; }
        public TimeSpan EndHour { get; set; }
        public double Experience { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public double Distance { get; set; }
    }
}
