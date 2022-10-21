using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TemplateConsoleApp.Init
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            try
            {
                await Host.CreateDefaultBuilder(args)
                    .AddLogging()
                    .AddConfiguration()
                    .AddServices()
                    .RunConsoleAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
            }
        }
    }
}