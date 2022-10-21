using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using TemplateConsoleApp.Init;

namespace Services
{
    public interface IHelloWorldWorker
    {
        Task<bool> DoWork();
    }

    public class HelloWorldWorker : IHelloWorldWorker
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HelloWorldWorker> _logger;
        private readonly AppConfig _appConfig;

        public HelloWorldWorker(
             IHttpClientFactory httpClientFactory,
             IOptions<AppConfig> appConfigOption,
             ILogger<HelloWorldWorker> logger
        )
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _appConfig = appConfigOption.Value;
        }


        public async Task<bool> DoWork()
        {

            var httpClient = _httpClientFactory.CreateClient();
            var res = await httpClient.GetAsync(_appConfig.HelloWorld);


            return true;
        }
    }
}
