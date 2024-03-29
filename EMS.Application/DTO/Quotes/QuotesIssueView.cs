using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Quotes
{
    public class QuotesIssueView
    {
        public int QuoteId { get; set; }
        public dynamic Skill { get; set; }
        public dynamic ServiceIssues { get; set; }
        public double LabourCost { get; set; }
        public string mechanicNotes { get; set; }
        public  double timeTaken { get; set; }
    }
}
