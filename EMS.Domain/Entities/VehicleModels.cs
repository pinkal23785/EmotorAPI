using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class VehicleModels
    {
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public string ModelName { get; set; }
        public int? ModelStart { get; set; }
        public int? ModelEnd { get; set; }
        public bool? IsPertol { get; set; }
        public bool? IsDiesel { get; set; }
        public bool? IsCNG { get; set; }
        public bool? IsLPG { get; set; }
        public bool? IsElectric { get; set; }
        public bool? IsHybrid { get; set; }
        public int? Rank { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsLuxery { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string BImage { get; set; }
        public string SImage { get; set; }
    }
}

