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
    public interface IConfigIssuesService
    {
        Task AddConfigServiceIssue(ServiceIssues serviceIssues);
        Task<List<ServiceIssues>> GetServiceIssuesBySkillId(int ServiceId, int? ParentId);
        Task DeleteServiceIssue(int ServiceIssueId);
        Task<List<ServiceIssues>> GetActualServiceIssuesBySkillId(int ServiceId);
        Task<List<ServiceIssues>> GetPopularService();
        Task<dynamic> GetServiceByLevel(int? SkillId, int? ServiceId);

        Task<dynamic> GetAllSkills();

    }
    public class ConfigIssuesService : IConfigIssuesService
    {
        private readonly EMSContext _context;
        public ConfigIssuesService(EMSContext context)
        {
            _context = context;
        }
        public Task AddConfigServiceIssue(ServiceIssues serviceIssues)
        {
            throw new NotImplementedException();
        }

        public Task DeleteServiceIssue(int ServiceIssueId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceIssues>> GetServiceIssuesBySkillId(int ServiceId, int? ParentId)
        {
            try
            {
                var IssueList = await _context.ServiceIssues.Where(x => x.SkillId == ServiceId).ToListAsync();
                if (ParentId != null)
                {
                    IssueList = IssueList.Where(x => x.ParentId == ParentId).ToList();
                }
                return IssueList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ServiceIssues>> GetActualServiceIssuesBySkillId(int ServiceId)
        {
            try
            {
                var IssueList = await _context.ServiceIssues.Where(x => x.SkillId == ServiceId && x.IsActualService == true).ToListAsync();
                return IssueList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ServiceIssues>> GetPopularService()
        {
            try
            {
                var IssueList = await _context.ServiceIssues.Where(x => x.IsPopularService == true && x.ParentId == null).ToListAsync();
                return IssueList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetServiceByLevel(int? SkillId, int? ServiceId)
        {
            try
            {
                dynamic IssueList = null;
                if (SkillId != null)
                {
                    IssueList = await (from service in _context.ServiceIssues
                                       where service.ParentId == null && service.SkillId == SkillId.Value
                                       select new
                                       {
                                           service.RecordId,
                                           service.IssueName,
                                           service.SkillId,
                                           HasLevel = (_context.ServiceIssues.Where(x => x.ParentId == service.RecordId).Any()),
                                           parentId=SkillId,
                                           isParentSkill=true
                                       }).ToListAsync();
                }
                else if (ServiceId != null)
                {
                    IssueList = await (from service in _context.ServiceIssues
                                       where service.ParentId == ServiceId
                                       select new
                                       {
                                           service.RecordId,
                                           service.IssueName,
                                           HasLevel = (_context.ServiceIssues.Where(x => x.ParentId == service.RecordId).Any()),
                                           service.SkillId,
                                           parentId= (_context.ServiceIssues.Where(x => x.RecordId == ServiceId).Select(x=>x.ParentId ?? x.SkillId).FirstOrDefault()),
                                           isParentSkill =!(_context.ServiceIssues.Where(x => x.RecordId == ServiceId && x.ParentId != null).Select(x => x.ParentId).Any())

                                       }).ToListAsync();
                }
                return IssueList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<dynamic> GetAllSkills()
        {
            var result = await (from skill in _context.Skills
                                select new
                                {
                                    RecordId = skill.ID,
                                    IssueName = skill.Name,
                                    skill.Picture,
                                    
                                }).ToListAsync();
            return result;


        }
    }
}

