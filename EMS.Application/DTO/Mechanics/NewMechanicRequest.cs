using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Mechanics
{
    public class NewMechanicRequest
    {
        public Users users { get; set; }
        public List<MechanicExpertise> mechanicExpertises { get; set; }
        public List<MechanicSkills> mechanicSkills { get; set; }
        public MechanicAttributes mechanicAttributes { get; set; }
        public List<Training> mechanicTraining { get; set; }
    }
}
