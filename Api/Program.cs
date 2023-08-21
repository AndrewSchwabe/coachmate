using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Data.Configure;
using System;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices((context, services) =>
                    {
                        services.ConfigureDataServices(context.Configuration);
                    }
                )
                .ConfigureAppConfiguration((context, builder) =>
                    {
                        builder.AddJsonFile("local.appsettings.json", true, true);
                        builder.AddEnvironmentVariables();
                    }
                )
                .Build();

            host.Run();
        }
    }
}