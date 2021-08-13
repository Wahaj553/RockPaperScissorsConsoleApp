using System;
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
            try
            {
                //Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location)
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
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
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}

//Add IOptions appsettings
//try moacking
//parametrized unit tests
