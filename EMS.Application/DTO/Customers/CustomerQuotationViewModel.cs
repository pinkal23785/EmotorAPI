using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Customers
{
    public class CustomerQuotationViewModel
    {
        public QuotationModel quotationInfo { get; set; }
        public List<int> quotationIssues { get; set; }
        public List<int> quotationMechanics { get; set; }
    }

    public class QuotationIssueModel
    {
        public int IssueId { get; set; }
    }
    public class QuotationModel
    {
        public int CustomerId { get; set; }
        public int VehicleModelId { get; set; }
        public int Manufacture { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public string Notes { get; set; }
        //public DateTime ExpireTime { get; set; }
        
    }


}
