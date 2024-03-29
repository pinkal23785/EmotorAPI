using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class VehicleTypes
    {
        public int VehicleTypeId { get; set; }
        public string Name { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Picture { get; set; }
        public int? Sequence { get; set; }
        public string cvt_type_hi { get; set; }
        public bool? IsActive { get; set; }
    }
}
