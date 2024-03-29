using EMS.Application.DTO.Customers;
using EMS.Application.DTO.Quotes;
using EMS.Domain.Entities;
using EMS.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IQuotationService
    {
        Task CreateQuotation(CustomerQuotationViewModel quotations);
        Task<dynamic> GetMechanicQuote(int MechanicId);
        Task<dynamic> GetQuoteDetails(int QuoteId, int MechanicId);
    }
    public class QuotationService : IQuotationService
    {
        private readonly EMSContext _context;
        public QuotationService(EMSContext context)
        {
            _context = context;
        }
        public async Task CreateQuotation(CustomerQuotationViewModel quotations)
        {
            if (quotations != null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {

                    var paramQuotation = quotations.quotationInfo;
                    var paramQuotationIssue = quotations.quotationIssues;

                    List<QuotationIssues> quotationIssues = new List<QuotationIssues>();
                    List<QuoteCustomerToMechanic> quoteCustomerToMechanics = new List<QuoteCustomerToMechanic>();
                    List<QuotationMechanicUpdates> quotationMechanicLabours = new List<QuotationMechanicUpdates>();

                    try
                    {
                        var quotation = new Quotations()
                        {
                            CustomerId = paramQuotation.CustomerId,
                            VehicleModel = paramQuotation.VehicleModelId,
                            Lat = paramQuotation.Lat,
                            Long = paramQuotation.Long,
                            Manufacture = paramQuotation.Manufacture,
                            Notes = paramQuotation.Notes,
                            Created = DateTime.Now,
                            Modified = DateTime.Now,
                            //QuotationIssues = quotationIssues,
                            QuoteExpireTime = DateTime.Now.AddDays(7)

                        };
                        _context.Quotations.Add(quotation);
                        await _context.SaveChangesAsync();
                        quotations.quotationIssues.ForEach(x =>
                        {
                            _context.QuotationIssues.Add(new QuotationIssues()
                            {
                                QuotationId = quotation.QuotationId,
                                IssueId = x,
                                Created = DateTime.Now,
                                Modified = DateTime.Now
                            });

                        });

                        await _context.SaveChangesAsync();
                        foreach (var m in quotations.quotationMechanics)
                        {
                            var quoteCustomer2Mechanic = new QuoteCustomerToMechanic()
                            {
                                QuotationId = quotation.QuotationId,
                                MechanicId = m,
                                Status = 0,
                                Created = DateTime.Now,
                                Modified = DateTime.Now
                            };
                            await _context.QuoteCustomerToMechanics.AddAsync(quoteCustomer2Mechanic);
                            await _context.SaveChangesAsync();

                            quotations.quotationIssues.ForEach(async x =>
                            {
                                var quotationLabour = new QuotationMechanicUpdates()
                                {
                                    QuotationCMId = quoteCustomer2Mechanic.QuoteCustomerMechanicId,
                                    MechanicId = m,
                                    IssueId = x,
                                    Created = DateTime.Now,
                                    Modified = DateTime.Now,
                                    SkillId = _context.ServiceIssues.Where(s => s.RecordId == x).Select(s => s.SkillId).FirstOrDefault(),
                                    LabourCost = null,
                                    Notes = null,
                                    TimeTaken = null
                                };
                                await _context.QuotationMechanicUpdates.AddAsync(quotationLabour);

                            });

                            await _context.SaveChangesAsync();
                        }

                        // await _context.QuotationIssues.AddRangeAsync(quotationIssues);
                        ////await _context.QuotationMechanicLabour.AddRangeAsync(quotationMechanicLabours);
                        await _context.SaveChangesAsync();
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }

                }

            }
        }

        public async Task<dynamic> GetMechanicQuote(int MechanicId)
        {
            var quotationList = await (from quote in _context.Quotations
                                       join custVehicle in _context.CustomerVehicles
                                       on new { quote.CustomerId, quote.VehicleModel } equals new { CustomerId = custVehicle.UserId, VehicleModel = custVehicle.VehicleModelId }
                                       join model in _context.VehicleModels
                                       on quote.VehicleModel equals model.ModelId
                                       join brand in _context.VehicleBrands
                                       on model.BrandId equals brand.VehicleBrandId
                                       join quoteMec in _context.QuoteCustomerToMechanics
                                       on quote.QuotationId equals quoteMec.QuotationId
                                       join attr in _context.MechanicAttributes
                                       on quoteMec.MechanicId equals attr.UserId
                                       where quoteMec.MechanicId == MechanicId && quote.QuoteExpireTime > DateTime.Now
                                       select new
                                       {
                                           quote.QuotationId,
                                           brand.Name,
                                           model.ModelName,
                                           model.SImage,
                                           quote.Manufacture,
                                           Created = (quote.Created.Date == DateTime.Now.Date ? quote.Created.ToString("HH:mm") : quote.Created.ToString("dd/MM/yyyy HH:mm")),
                                           QuoteExpireTime = quote.QuoteExpireTime.ToString("dd/MM/yyyy"),
                                           quote.Lat,
                                           quote.Long,
                                           quote.Notes,
                                           distance = (new Point(double.Parse(quote.Long), double.Parse(quote.Lat), 4326)).Distance(new Point(double.Parse(attr.Longitute), double.Parse(attr.Latitute), 4326)),
                                           fuelType = (custVehicle.FuelType == 0 ? "Petrol" : "Diesel")
                                       }).Distinct().ToListAsync();

            return quotationList;

        }
        public async Task<dynamic> GetQuoteDetails(int QuoteId, int MechanicId)
        {
            List<QuotesIssueView> quotesIssueViews = new List<QuotesIssueView>();
            var quoteDetail = await (from quote in _context.Quotations
                                     join mecQuote in _context.QuoteCustomerToMechanics
                                     on quote.QuotationId equals mecQuote.QuotationId
                                     join mechIssue in _context.QuotationMechanicUpdates
                                     on mecQuote.QuoteCustomerMechanicId equals mechIssue.QuotationCMId
                                     where quote.QuotationId == QuoteId && mechIssue.MechanicId == MechanicId
                                     select new
                                     {
                                         mechIssue.SkillId,
                                         mecQuote.QuoteCustomerMechanicId
                                     }).Distinct().ToListAsync();

            foreach (var q in quoteDetail)
            {
                var quotesIssueView = new QuotesIssueView()
                {
                    QuoteId = QuoteId,
                    Skill = (from sk in _context.Skills
                             where (sk.ID == q.SkillId)
                             select new
                             {
                                 sk.ID,
                                 sk.Name
                             }).FirstOrDefault(),
                    ServiceIssues = await (from mUpdate in _context.QuotationMechanicUpdates
                                           join mIssue in _context.ServiceIssues
                                           on mUpdate.IssueId equals mIssue.RecordId
                                           where mUpdate.SkillId == q.SkillId &&
                                           mUpdate.QuotationCMId == q.QuoteCustomerMechanicId
                                           select new
                                           {
                                               mIssue.RecordId,
                                               mIssue.IssueName,
                                           }).ToListAsync()
                };
                quotesIssueViews.Add(quotesIssueView);
            }


            return quotesIssueViews;
        }


    }
}
