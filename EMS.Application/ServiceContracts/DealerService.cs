using EMS.Application.DTO.Dealers;
using EMS.Application.helpers;
using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IDealerService
    {
       Task NewDealer(NewDealerRequest request,int UserId);
    }
    public class DealerService : IDealerService
    {
        private EMSContext _context;
        public DealerService(EMSContext context)
        {
            _context = context;
        }
        public async Task NewDealer(NewDealerRequest request, int UserId)
        {
            if (request.users != null)
            {
                using (var trans = _context.Database.BeginTransaction())
                {
                    var user = request.users;
                    var newMechanic = new Users()
                    {
                        UserId = UserId,
                        UserType = (byte)UserType.Dealer,
                        Address = user.Address,
                        City = user.City,
                        State = user.State,
                        DOB = user.DOB,
                        Name = user.Name,
                        Pincode = user.Pincode,
                        DateCreated = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    await _context.Users.AddAsync(newMechanic);
                    foreach (var expertise in request.dealerExpertises)
                    {
                        await _context.DealerExpertise.AddAsync(
                                    new DealerExpertise()
                                    {
                                        UserId = UserId,
                                        VehicleBrandId = expertise.VehicleBrandId,
                                        DateCreated = DateTime.Now,
                                        DateModified = DateTime.Now
                                    });
                    }

                    foreach (var part in request.dealerPartsCatlog)
                    {
                        await _context.DealerPartsCatlog.AddAsync(
                            new DealerPartsCatlog()
                            {
                                UserId = UserId,
                                SkillID = part.SkillID,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now
                            });
                    }
                    var attribute = request.dealerAttributes;
                    await _context.DealerAttributes.AddAsync(
                        new DealerAttributes()
                        {
                            UserId = UserId,
                            GarageName=attribute.GarageName,
                            CurrentStatus = 1,
                            DateCreated = DateTime.Now,
                            DistanceCovered = attribute.DistanceCovered,
                            EndHours = attribute.EndHours,
                            Experience = attribute.Experience,
                            Is24Support = attribute.Is24Support,
                            IsOnsiteSupport = attribute.IsOnsiteSupport,
                            IsOwnGarage = attribute.IsOwnGarage,
                            Latitute = attribute.Latitute,
                            Longitute = attribute.Longitute,
                            StartHours = attribute.StartHours,
                            ModifiedDate = DateTime.Now,
                            TotalHelpers=attribute.TotalHelpers,
                            TotalMechanics=attribute.TotalMechanics
                        });

                    await _context.SaveChangesAsync();
                    trans.Commit();
                }
            }

        }
    }
}
