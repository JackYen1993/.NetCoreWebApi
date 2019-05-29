using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.AzureAppServices;
using NLog.Web;

namespace WebStoreWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
                    .UseStartup<Startup>()
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    })
                    .UseNLog();  // NLog: setup NLog for Dependency injection
                
                // Add log in Azure diagnostics logs

                /*WebHost.CreateDefaultBuilder(args)
                    .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
                    .ConfigureServices(serviceCollection => serviceCollection
                            .Configure<AzureFileLoggerOptions>(options =>
                            {
                                options.FileName = "azure-diagnostics-";
                                options.FileSizeLimit = 50 * 1024;
                                options.RetainedFileCountLimit = 5;
                            }).Configure<AzureBlobLoggerOptions>(options =>
                            {
                                options.BlobName = "log.txt";
                            }))
                    .UseStartup<Startup>();*/
    }
}
