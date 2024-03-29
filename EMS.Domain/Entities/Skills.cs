using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public partial class Skills
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public byte IsMechanicSkill { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Sequence { get; set; }
        public string cs_skill_hi { get; set; }
    }
}
