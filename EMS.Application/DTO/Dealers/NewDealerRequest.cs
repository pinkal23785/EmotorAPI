using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Dealers
{
    public class NewDealerRequest
    {
        public Users users { get; set; }
        public List<DealerExpertise> dealerExpertises { get; set; }
        public List<DealerPartsCatlog> dealerPartsCatlog { get; set; }
        public DealerAttributes dealerAttributes { get; set; }
    }
}
