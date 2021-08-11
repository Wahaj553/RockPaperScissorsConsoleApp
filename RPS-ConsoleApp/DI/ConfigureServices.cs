using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPS_ConsoleApp.Helper;

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
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddTransient<IMatchExecution, MatchExecution>();
                    services.AddTransient<IMatchBattle, MatchBattle>();

                });
        }
    }
}
