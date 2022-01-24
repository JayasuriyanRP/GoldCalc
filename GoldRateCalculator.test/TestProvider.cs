using GoldService;
using GoldService.Command;
using GoldService.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace GoldRateCalculator.test
{
    public class TestProvider
    {
        private readonly IConfiguration configuration;

        private readonly IHostEnvironment _hostEnvironment;

        private readonly ServiceProvider serviceProvider;

        public TestProvider()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

            configuration = builder.Build();

            //IHostEnvironment service.
            IHost host = Host.CreateDefaultBuilder().Build();
            _hostEnvironment = (IHostEnvironment)host.Services.GetService(typeof(IHostEnvironment));

            
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(provider => configuration);
            serviceCollection.AddSingleton(_hostEnvironment);
            serviceCollection.AddSingleton<IGoldRateService, GoldRateService>();
            serviceCollection.AddMvc();
            serviceCollection.AddLogging();
            serviceCollection.AddHttpClient();
            serviceCollection.AddMediatR(typeof(GoldServiceStartup).Assembly);
            serviceCollection.AddTransient<IRequestHandler<GoldRateCommand, IActionResult>, GoldRateCommandHandler>();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>();
        }
    }
}