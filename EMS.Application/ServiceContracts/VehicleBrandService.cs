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
    public interface IVehicleBrandService
    {
        Task AddVehicleBrand(VehicleBrands brands);
        Task<List<VehicleBrands>> GetVehicleBrands(int VehicleTypeId);
        Task<List<VehicleModels>> GetVehicleModels(int BrandId);
        Task<List<VehicleBrands>> GetVehicleBrandsByType(string Type);
    }

    public class VehicleBrandService : IVehicleBrandService
    {
        private EMSContext _context;
        public VehicleBrandService(EMSContext context)
        {
            _context = context;
        }
        public async Task AddVehicleBrand(VehicleBrands vbrand)
        {
            var brand = _context.VehicleBrands.Where(x => x.Name == vbrand.Name && x.VehicleTypeId == vbrand.VehicleTypeId).FirstOrDefault();
            if (brand == null)
            {
                await _context.AddAsync(vbrand);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Vehicle Brand Already Exists");
            }
        }

        public async Task<List<VehicleBrands>> GetVehicleBrands(int VehicleTypeId)
        {
            return await _context.VehicleBrands.Where(x => x.VehicleTypeId == VehicleTypeId).OrderBy(x=>x.Rank).ToListAsync();
        }
        public async Task<List<VehicleModels>> GetVehicleModels(int BrandId)
        {
            return await _context.VehicleModels.Where(x => x.BrandId == BrandId && x.IsActive == true).OrderBy(x=>x.Rank).ToListAsync();
        }

        public async Task<List<VehicleBrands>> GetVehicleBrandsByType(string Type)
        {
            var vehicleType = _context.VehicleTypes.Where(x => x.Name == Type).FirstOrDefault();
            return await _context.VehicleBrands.Where(x => x.VehicleTypeId == vehicleType.VehicleTypeId).OrderBy(x => x.Rank).ToListAsync();
        }
    }
}
