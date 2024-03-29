using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class Users
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public byte UserType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate {get;set;}

    }
}
