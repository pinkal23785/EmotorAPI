using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IOrderIssueService
    {
        Task AddOrderIssues(List<ServiceOrderIssues> serviceOrderIssues);
        Task<List<ServiceOrderIssues>> GetServiceOrderIssues();
    }
    public class OrderIssueService : IOrderIssueService
    {
        public Task AddOrderIssues(List<ServiceOrderIssues> serviceOrderIssues)
        {
            throw new NotImplementedException();
        }

        public Task<List<ServiceOrderIssues>> GetServiceOrderIssues()
        {
            throw new NotImplementedException();
        }
    }
}
