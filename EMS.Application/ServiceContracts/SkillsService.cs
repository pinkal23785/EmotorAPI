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
    public interface ISkillsService
    {
        Task<List<Skills>> GetSkills(bool IsMechanic);

        Task<List<Skills>> GetAllSkills();
        Task AddSkills(Skills Skill);

    }
    public class SkillsService : ISkillsService
    {
        private EMSContext _context;
        public SkillsService(EMSContext context)
        {
            _context = context;
        }
        public async Task AddSkills(Skills Skill)
        {
            var skill = await _context.Skills.Where(x => x.Name == Skill.Name).FirstOrDefaultAsync();
            if (skill == null)
            {
                await _context.AddAsync(Skill);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new DuplicateWaitObjectException("Skill name already exist");
            }
        }

        public async Task<List<Skills>> GetSkills(bool IsMechanic)
        {
            if (IsMechanic)
                return await _context.Skills.Where(x => x.IsMechanicSkill == 0 || x.IsMechanicSkill == 2).OrderBy(x => x.Sequence).ToListAsync();
            else
                return await _context.Skills.Where(x => x.IsMechanicSkill == 1 || x.IsMechanicSkill == 2).OrderBy(x => x.Sequence).ToListAsync();
        }

        public async Task<List<Skills>> GetAllSkills()
        {

            return await _context.Skills.OrderBy(x => x.Sequence).ToListAsync();

        }
    }
}
