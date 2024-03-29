using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Mechanics
{
    public class MechanicSearchRequest
    {
        public string selectedSkills { get; set; }
        public int brandId { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public int radiusKM { get; set; }
    }
}
