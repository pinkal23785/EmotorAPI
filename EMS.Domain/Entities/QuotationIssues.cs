using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Domain.Entities
{
    public class QuotationIssues
    {
        public int QuoteIssueId { get; set; }
        public int QuotationId { get; set; }
        public int IssueId { get; set; }
        public string IssueNotes { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}
