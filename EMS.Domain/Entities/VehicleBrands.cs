using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class VehicleBrands
    {
        public int VehicleBrandId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int? Rank { get; set; }
    }
}
