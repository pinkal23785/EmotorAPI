using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class MechanicSkills
    {
        public int ID { get; set; }
        public int? UserId { get; set; }
        public int? SkillID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
