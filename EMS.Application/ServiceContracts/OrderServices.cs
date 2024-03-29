using EMS.Application.DTO.ServiceOrder;
using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IOrderServices
    {
        Task CreateOrder(ServiceOrders serviceOrders);
        Task<ServiceOrders> GetServiceOrder(int ServiceOrderId);
    }
    public class OrderServices : IOrderServices
    {
        private readonly EMSContext _context;
        public OrderServices(EMSContext context)
        {
            _context = context;
        }
        public  async Task CreateOrder( ServiceOrders serviceOrders)
        {
            
            try
            {
                if(serviceOrders != null)
                {
                    var serviceOrder = new ServiceOrders()
                    {

                    };
                    //await _context.ServiceOrders.AddAsync(serviceOrders);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public Task<ServiceOrders> GetServiceOrder(int ServiceOrderId)
        {
            throw new NotImplementedException();
        }
    }
}
