using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class Services
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int SkillId { get; set; }
        public DateTime ServiceCreated { get; set; }
        public DateTime? ServiceModified { get; set; }
    }
}
