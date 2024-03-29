using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IConfigServicesService
    {
        Task AddServices(Services services);
        //Task<List<Services>> GetAllServices();
        Task<List<Services>> GetServicesBySkill(int SkillId);

    }
    public class ConfigServicesService : IConfigServicesService
    {
        private readonly EMSContext _context;

        public ConfigServicesService(EMSContext context)
        {
            _context = context;
        }
        public async Task AddServices(Services services)
        {
            try
            {
                if (services != null)
                {
                    await _context.Services.AddAsync(services);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Services>> GetServicesBySkill(int SkillId)
        {
            try
            {
                var ListService = await _context.Services.Where(x => x.SkillId == SkillId).ToListAsync();
                return ListService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
