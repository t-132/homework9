using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;

namespace HomeWork9
{
   class Program
   {
      public static void Main(string[] args)
      {
         try
         {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            var config = builder.Build();
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(config)
               .Enrich.FromLogContext()               
               .CreateLogger();

            IAppService srv = new AppService();
            srv.Run();
         }

         catch (Exception ex)
         {
            Log.Fatal(ex.Message);
         }
         finally
         {
            Log.Information("Stop");
         }
      }

      public static void BuildConfig(IConfigurationBuilder builder)
      {
         builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables();
      }
   }
}
