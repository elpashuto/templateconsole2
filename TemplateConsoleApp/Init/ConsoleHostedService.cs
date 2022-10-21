using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;

namespace TemplateConsoleApp.Init
{
    internal class ConsoleHostedService : IHostedService
    {
        private int? _exitCode;

        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IHelloWorldWorker _helloWorldWorker;
        private readonly ILogger<ConsoleHostedService> _logger;

        public ConsoleHostedService(
            IHostApplicationLifetime appLifetime,
            IHelloWorldWorker helloWorldWorker,
            ILogger<ConsoleHostedService> logger
            )
        {
            _appLifetime = appLifetime;
            _helloWorldWorker = helloWorldWorker;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    try
                    {
                        _logger.LogInformation("Starting the process...");

                        bool result = await _helloWorldWorker.DoWork();

                        _logger.LogInformation($"Result is: {result}");

                        _exitCode = 0;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Unhandled exception");
                        _exitCode = 1;
                    }
                    finally
                    {
                        _logger.LogInformation("Sync completed.");
                        _appLifetime.StopApplication();
                    }
                });
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Environment.ExitCode = _exitCode.GetValueOrDefault(-1);
            return Task.CompletedTask;
        }
    }
}
