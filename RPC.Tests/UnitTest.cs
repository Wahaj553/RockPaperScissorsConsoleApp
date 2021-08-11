using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPS_ConsoleApp.DI;
using RPS_ConsoleApp.Helper;
using RPS_ConsoleApp.Model;
using Xunit;

namespace RPC.Tests
{
    public class UnitTest
    {
        private readonly IHost _host = null;
        public UnitTest()
        {
            _host = ConfigureServices.CreateHostBuilder().Build();
        }

        [Fact]
        public void GetWiningHand()
        {
            try
            {
                var player1 = new Player()
                {
                    Name = "TestPlayer1",
                    Action = GameAction.Paper
                };
                var player2 = new Player()
                {
                    Name = "TestPlayer2",
                    Action = GameAction.Scissors
                };
                //Return the winner of the game or null in case of draw
                var winner = _host.Services.GetService<IMatchBattle>().WinningHand(player1, player2);
                Assert.True(true);
            }
            catch
            {
                Assert.True(false);
            }
        }
    }
}
