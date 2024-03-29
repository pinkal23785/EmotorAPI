using EMS.Application.DTO.Mechanics;
using EMS.Application.helpers;
using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
//using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IMechanicService
    {
        Task NewMechanic(NewMechanicRequest mechanicRequest, int UserId);
        Task<dynamic> GetMechanicSkills(int UserId);
        Task<dynamic> GetMechanicServiceOrderRequests(int UserId);
        Task<dynamic> SearchRequestedServiceMechanic(MechanicSearchRequest searchRequest);
        Task<dynamic> GetLocation(string lat, string lon);
    }
    public class MechanicService : IMechanicService
    {
        private EMSContext _context;
        public MechanicService(EMSContext context)
        {
            _context = context;
        }
        public async Task NewMechanic(NewMechanicRequest mechanicRequest, int UserId)
        {
            
            //Guid UserId = Guid.Parse(User.Claims.Where(x => x.Type == "id").Select(x => x.Value).First());
            if (mechanicRequest.users != null)
            {
                using (var trans = _context.Database.BeginTransaction())
                {
                    var user = mechanicRequest.users;
                    var newMechanic = new Users()
                    {
                        UserId = UserId,
                        UserType = (byte)UserType.Mechanic,
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
                    foreach (var expertise in mechanicRequest.mechanicExpertises)
                    {
                        await _context.MechanicExpertise.AddAsync(
                                    new MechanicExpertise()
                                    {
                                        UserId = UserId,
                                        VehicleBrandId = expertise.VehicleBrandId,
                                        DateCreated = DateTime.Now,
                                        DateModified = DateTime.Now
                                    });
                    }

                    foreach (var skill in mechanicRequest.mechanicSkills)
                    {
                        await _context.MechanicSkills.AddAsync(
                            new MechanicSkills()
                            {
                                UserId = UserId,
                                SkillID = skill.SkillID,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now
                            });
                    }
                    var attribute = mechanicRequest.mechanicAttributes;
                    await _context.MechanicAttributes.AddAsync(
                        new MechanicAttributes()
                        {
                            UserId = UserId,
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
                            GarageName = attribute.GarageName,
                            ModifiedDate = DateTime.Now,
                            TotalHelpers = attribute.TotalHelpers,
                            TotalMechanics = attribute.TotalMechanics,
                            Location = new Point(double.Parse(attribute.Longitute), double.Parse(attribute.Latitute)) { SRID = 4326 }
                        });

                    if (mechanicRequest.mechanicTraining != null)
                    {
                        foreach (var training in mechanicRequest.mechanicTraining)
                        {
                            await _context.Training.AddAsync(new Training()
                            {
                                UserId = UserId,
                                Name = training.Name,
                                Duration = training.Duration,
                                Place = training.Place,
                                Year = training.Year,
                                Institute = training.Institute,
                                DateCreated = DateTime.Now,
                                DateModified = DateTime.Now
                            });
                        }
                    }
                    await _context.SaveChangesAsync();
                    trans.Commit();
                }
            }
        }


        public async Task<dynamic> GetMechanicSkills(int UserId)
        {
            var skills = await (from sk in _context.Skills
                                join mk in _context.MechanicSkills
                                on sk.ID equals mk.SkillID
                                where mk.UserId == UserId
                                select new
                                {
                                    mk.SkillID,
                                    sk.Name,
                                    services = (from si in _context.ServiceIssues
                                                join ps in _context.PartnerServiceIssues.Where(x => x.UserID == UserId)
                                                on si.ServiceIssueId equals ps.ServiceIssueId into psi
                                                from x in psi.DefaultIfEmpty()
                                                join ms in _context.MechanicSkills
                                                on si.SkillId equals ms.SkillID
                                                join sk in _context.Skills
                                                on si.SkillId equals sk.ID
                                                where si.SkillId == mk.SkillID && si.IsActualService == true
                                                select new
                                                {
                                                    si.ServiceIssueId,
                                                    si.IssueName,
                                                    x.LabourCost,
                                                    x.TimeTaken,
                                                    x.Notes,
                                                    si.SkillId,
                                                    sk.Name,
                                                    si.ParentId
                                                }).ToList(),
                                    IsItemVisible = false
                                }).ToListAsync();

            return skills;
        }

        public async Task<dynamic> GetMechanicServiceOrderRequests(int UserId)
        {

            var serviceOrders = await _context.ServiceOrders.Where(x => x.MechanicId == UserId).ToListAsync();
            return serviceOrders;
        }

        public async Task<dynamic> SearchRequestedServiceMechanic(MechanicSearchRequest searchRequest)
        {

            //Point currentUserLocation = new Point(double.Parse(searchRequest.lon), double.Parse(searchRequest.lat),4326);
            //currentUserLocation.Distance
            
            //double radiusMeters = searchRequest.radiusKM * 1000;
            //var mechanics = await (from user in _context.Users
            //                       join expertise in _context.MechanicExpertise
            //                       on user.UserId equals expertise.UserId
            //                       join skills in _context.MechanicSkills
            //                       on expertise.UserId equals skills.UserId
            //                       join attribute in _context.MechanicAttributes
            //                       on user.UserId equals attribute.UserId
            //                       where user.UserType == (int)UserType.Mechanic && expertise.VehicleBrandId == searchRequest.brandId
            //                       && searchRequest.selectedServiceList.Contains(skills.SkillID.Value)
            //                       && attribute.Location.Distance(currentUserLocation) <= radiusMeters
            //                       select new
            //                       {
            //                           user.Name,
            //                           user.Address,
            //                       }).ToListAsync();

            try
            {

                List<SqlParameter> parameters = new List<SqlParameter>()
                {
                    new SqlParameter(){ParameterName= "@ListOfServices",Value =searchRequest.selectedSkills },
                    new SqlParameter(){ParameterName="@BrandId", Value = searchRequest.brandId },
                    new SqlParameter(){ParameterName="@UserLat", Value = searchRequest.lat },
                    new SqlParameter(){ParameterName="@UserLog", Value = searchRequest.lon },
                    new SqlParameter(){ParameterName="@RadiusKM",Value = searchRequest.radiusKM  },

                };


                var requestResult = _context.Query<SearchMechanicView>().FromSqlRaw("uspSearchMechanicByUserLocation @ListOfServices,@BrandId,@UserLat,@UserLog," +
                    "@RadiusKM", parameters.ToArray());


                return requestResult.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<dynamic> GetLocation(string lat, string lon)
        {
            return new Point(double.Parse(lon), double.Parse(lat)) { SRID = 4326 };
        }
    }
}
