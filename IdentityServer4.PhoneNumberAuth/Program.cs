using System.Net;
using IdentityServer4.PhoneNumberAuth.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IdentityServer4.PhoneNumberAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                //webBuilder.UseContentRoot(Directory.GetCurrentDirectory());//Ad
                //webBuilder.UseIISIntegration(); //Ad

                webBuilder.UseStartup<Startup>();
            });

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //  WebHost.CreateDefaultBuilder(args)
        //      .UseStartup<Startup>();


    }
}