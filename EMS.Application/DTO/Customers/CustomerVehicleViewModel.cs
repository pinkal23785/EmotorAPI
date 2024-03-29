using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Customers
{
    public class CustomerVehicleViewModel
    {
        public int ModelId { get; set; }
        public string FuelType { get; set; }
        public int? Manufacture { get; set; }
        public string ChasisNumber { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
    }
}
