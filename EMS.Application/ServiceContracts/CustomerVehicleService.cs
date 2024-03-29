using EMS.Application.DTO.Customers;
using EMS.Application.helpers;
using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface ICustomerVehicleService
    {
        Task AddCustomerVehicle(CustomerVehicleViewModel customerVehicle, int UserId);
    }
    public class CustomerVehicleService : ICustomerVehicleService
    {
        private readonly EMSContext _context;
        public CustomerVehicleService(EMSContext context)
        {
            _context = context;
        }
        public async Task AddCustomerVehicle(CustomerVehicleViewModel customerVehicle, int UserId)
        {
            try
            {
                if (customerVehicle != null)
                {
                    var isVehicleExist = _context.CustomerVehicles.Where(x => x.UserId == UserId && x.VehicleModelId == customerVehicle.ModelId).Any();
                    if (!isVehicleExist)
                    {
                        var vehicle = new CustomerVehicles()
                        {
                            UserId = UserId,
                            VehicleModelId = customerVehicle.ModelId,
                            Manufacture = customerVehicle.Manufacture,
                            ChasisNumber = customerVehicle.ChasisNumber,
                            FuelType = (int)(GetFuelType(customerVehicle.FuelType)),
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            Lat = customerVehicle.Lat.ToString(),
                            Long = customerVehicle.Long.ToString()
                        };
                        await _context.AddAsync(vehicle);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public FuelType GetFuelType(string fuelType)
        {
            foreach (FuelType mc in Enum.GetValues(typeof(FuelType)))
                if (mc.ToString() == fuelType)
                    return mc;

            return FuelType.Petrol;
        }
    }
}
