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
            host.Services.GetService<IMatchExecution>().StartMatchExecution("HumanPlayer");//Name of any human player
        }
    }
}
