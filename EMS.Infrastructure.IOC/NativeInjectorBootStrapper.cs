using EMS.Application.ServiceContracts;
using EMS.Infrastructure.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EMS.Infrastructure.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ISMSService, SMSService>();
            services.AddScoped<IVehicleTypesService, VehicleTypesService>();
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IVehicleBrandService, VehicleBrandService>();
            services.AddScoped<IMechanicService, MechanicService>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILocaliseLangService, LocalizeLangService>();
            services.AddScoped<IConfigIssuesService, ConfigIssuesService>();
           // services.AddScoped<IConfigServicesService, ConfigServicesService>();
            services.AddScoped<IPartnerIssueService, PartnerIssueService>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderIssueService, OrderIssueService>();
            services.AddScoped<IQuotationService, QuotationService>();
            services.AddScoped<ICustomerVehicleService, CustomerVehicleService>();
            services.AddScoped<IEmailService, EmailService>();
        }

    }
}
