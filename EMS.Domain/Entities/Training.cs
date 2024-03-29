using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Training
    {
        public int TrainingID { get; set; }
        public int UserId { get; set; }
        public string VehicleCategory { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Place { get; set; }
        public string Institute { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
