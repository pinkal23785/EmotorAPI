using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class States
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int Sequence { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified{get;set;}

    }
}
