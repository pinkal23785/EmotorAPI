using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EMS.Infrastructure.Persistence.Context
{
    public class EMSContext : DbContext
    {
        public EMSContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<VehicleTypes> VehicleTypes { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<VehicleBrands> VehicleBrands { get; set; }
        public DbSet<VehicleModels> VehicleModels { get; set; }

        public DbSet<MechanicExpertise> MechanicExpertise { get; set; }
        public DbSet<MechanicSkills> MechanicSkills { get; set; }
        public DbSet<MechanicAttributes> MechanicAttributes { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<DealerExpertise> DealerExpertise { get; set; }
        public DbSet<DealerPartsCatlog> DealerPartsCatlog { get; set; }
        public DbSet<DealerAttributes> DealerAttributes { get; set; }
        public DbSet<LocalizeLang>LocalizeLang { get; set; }
        public DbSet<States> States { get; set; }

        //Customer Vehicle

        public DbSet<CustomerVehicles> CustomerVehicles { get; set; }

        //Quotations
        public DbSet<Quotations> Quotations { get; set; }
        public DbSet<QuoteCustomerToMechanic> QuoteCustomerToMechanics { get; set; }
        public DbSet<QuotationIssues> QuotationIssues { get; set; }
        public DbSet<QuotationMechanicUpdates> QuotationMechanicUpdates { get; set; }
        public DbSet<QuotationParts> QuotationParts { get; set; }


        //public DbSet<Services> Services { get; set; }
        public DbSet<ServiceIssues> ServiceIssues { get; set; }
        public DbSet<PartnerServiceIssues> PartnerServiceIssues { get; set; }
        public DbSet<ServiceOrders> ServiceOrders { get; set; }
        public DbSet<ServiceOrderIssues> ServiceOrderIssues { get; set; }


        //Procedure Call

        public virtual DbQuery<SearchMechanicView> SearchRequest { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}

