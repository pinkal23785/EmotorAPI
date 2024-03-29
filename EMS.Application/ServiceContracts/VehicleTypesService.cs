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
    public interface IVehicleTypesService
    {
        Task AddVehicleTypes(VehicleTypes vehicleTypes);
        Task<List<VehicleTypes>> GetVehicleTypes();
    }
    public class VehicleTypesService : IVehicleTypesService
    {
        private EMSContext _context;
        public VehicleTypesService(EMSContext context)
        {
            _context = context;
        }
        public async Task AddVehicleTypes(VehicleTypes vehicleTypes)
        {
            var vehicleType = await _context.VehicleTypes.Where(x => x.Name == vehicleTypes.Name).FirstOrDefaultAsync();
            if (vehicleType == null)
            {
                await _context.AddAsync(vehicleType);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateWaitObjectException("Vehicle type already exist");
            }

        }

        public async Task<List<VehicleTypes>> GetVehicleTypes()
        {
            try
            {
                return await _context.VehicleTypes.Where(x=>x.IsActive==true).OrderBy(x => x.Name).OrderBy(x => x.Sequence).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
