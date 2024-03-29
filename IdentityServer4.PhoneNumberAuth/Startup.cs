using EMS.Application.Configurations;
using EMS.Application.ServiceContracts;
using EMS.Infrastructure.IOC;
using EMS.Infrastructure.Shared.Services;
using IdentityServer4.AspNetIdentity;
using IdentityServer4.PhoneNumberAuth.Configuration;
using IdentityServer4.PhoneNumberAuth.Data;
using IdentityServer4.PhoneNumberAuth.Models;
using IdentityServer4.PhoneNumberAuth.Services;
using IdentityServer4.PhoneNumberAuth.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer4.PhoneNumberAuth
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(connectionString); });
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();
            services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseFailureEvents = true;
                })
                .AddExtensionGrantValidator<PhoneNumberTokenGrantValidator>()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>();
            services.Configure<SMSConfigurations>(_configuration.GetSection("SMSConfigurations"));
            services.AddSingleton<ISMSService, SMSService>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
        }));
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors("MyPolicy");
            app.UseRouting();
            app.UseIdentityServer();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute("default","{controller=Home}/{action=Index}");
            });
            //app.UseMvcWithDefaultRoute();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
           NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}