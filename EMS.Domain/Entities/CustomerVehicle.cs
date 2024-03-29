using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EMS.Domain.Entities
{
    public class CustomerVehicles
    {

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int CustomerVehicleId { get; set; }
        public int UserId { get; set; }
        public int VehicleModelId { get; set; }
        public int? Manufacture { get; set; }
        public int FuelType { get; set; }
        public string ChasisNumber { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime DateCreated { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime DateModified { get; set; }
    }
}
