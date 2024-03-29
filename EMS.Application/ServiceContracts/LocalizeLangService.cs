using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace EMS.Application.ServiceContracts
{
    public interface ILocaliseLangService
    {
        Task<List<LocalizeLang>> getLocalizeLang();
        Task<List<States>> getAllStates();
    }
    public class LocalizeLangService : ILocaliseLangService
    {
        private readonly EMSContext _context;
        public LocalizeLangService(EMSContext context)
        {
            _context = context;
        }

        public async Task<List<LocalizeLang>> getLocalizeLang()
        {
            return await _context.LocalizeLang.ToListAsync();
        }

        public async Task<List<States>> getAllStates()
        {
            return await _context.States.Where(x=>x.IsActive==true).OrderBy(x=>x.Sequence).ToListAsync();
        }
    }
}
