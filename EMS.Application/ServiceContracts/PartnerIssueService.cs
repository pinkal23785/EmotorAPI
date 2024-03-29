using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.ServiceContracts
{
    public interface IPartnerIssueService
    {
        Task AddPartnerServiceIssues(PartnerServiceIssues partnerServiceIssues);
        Task<dynamic> GetPartnerServiceIssues(int PartnerId);
        Task DeletePartnerServiceIssue(int PartnerServiceIssueId);
    }
    public class PartnerIssueService : IPartnerIssueService
    {
        private readonly EMSContext _context;
        public PartnerIssueService(EMSContext context)
        {
            _context = context;
        }
        public async Task AddPartnerServiceIssues(PartnerServiceIssues partnerServiceIssues)
        {
            if (partnerServiceIssues != null)
            {
                await _context.AddAsync(partnerServiceIssues);
                await _context.SaveChangesAsync();
            }
        }

        public Task DeletePartnerServiceIssue(int PartnerServiceIssueId)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetPartnerServiceIssues(int PartnerId)
        {
            dynamic issueList;
            issueList = await (from si in _context.ServiceIssues
                               join ps in _context.PartnerServiceIssues.Where(x => x.UserID == PartnerId)
                               on si.ServiceIssueId equals ps.ServiceIssueId into psi
                               from x in psi.DefaultIfEmpty()
                               join ms in _context.MechanicSkills
                               on si.SkillId equals ms.SkillID
                               join sk in _context.Skills
                               on si.SkillId equals sk.ID
                               //where x.UserID == PartnerId
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
                               }).ToListAsync();
            return issueList;
        }
    }
}
