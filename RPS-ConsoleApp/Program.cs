using System;
using Microsoft.Extensions.DependencyInjection;
using RPS_ConsoleApp.DI;
using RPS_ConsoleApp.Helper;

namespace RPS_ConsoleApp
{
    public class Program
    {
        private static void Main()
        {
            var host = ConfigureServices.CreateHostBuilder().Build();
            Console.Write("Please enter your name: ");
            var playerName = Console.ReadLine();
            if (!string.IsNullOrEmpty(playerName))
            {
                host.Services.GetService<IMatchExecution>()
                    .StartMatchExecution(playerName);
            }
        }
    }
}
