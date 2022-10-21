using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;

namespace TemplateConsoleApp.Init
{
    public static class Bootstrapper
    {
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            var environmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

            host.ConfigureAppConfiguration((context, configuration) =>
            {
                configuration
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("./Init/appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"./Init/appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
            return host;
        }


        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((hostingContext, services) =>
            {
                services.Configure<AppConfig>(hostingContext.Configuration);
                services.AddHttpClient();
                services.AddHostedService<ConsoleHostedService>();
                services.AddTransient<IHelloWorldWorker, HelloWorldWorker>();
            });

            return host;
        }

        public static IHostBuilder AddLogging(this IHostBuilder host)
        {
            host.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            });
            return host;
        }
    }
}
