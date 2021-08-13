using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPS_ConsoleApp.Helper;
using RPS_ConsoleApp.Model;

namespace RPS_ConsoleApp.DI
{
   public static class ConfigureServices
    {
        /// <summary>
        /// Service Registration Method
        /// </summary>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location))
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IMatchExecution, MatchExecution>();
                    services.AddTransient<IMatchBattle, MatchBattle>();
                    services.Configure<GameSettings>(configuration.GetSection("GameSettings"));
                });
        }
    }
}

//Add IOptions appsettings
//try moacking
//parametrized unit tests
