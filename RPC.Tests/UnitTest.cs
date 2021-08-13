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
        private readonly IHost _host;
        public UnitTest()
        {
            _host = ConfigureServices.CreateHostBuilder().Build();
        }

        [Theory]
        [InlineData("TestPlayer1", GameAction.Rock, "TestPlayer2", GameAction.Scissors, "TestPlayer1")] //Rock beats scissors
        [InlineData("TestPlayer1", GameAction.Scissors, "TestPlayer2", GameAction.Paper, "TestPlayer1")]// Scissors beats paper
        [InlineData("TestPlayer1", GameAction.Paper, "TestPlayer2", GameAction.Rock, "TestPlayer1")]//Paper beats rock
        public void GetWiningHand(string firstPlayer, GameAction firstPlayerAction, string secondPlayer, GameAction secondPlayerAction, string result)
        {
            try
            {
                //Arrange
                var player1 = new Player()
                {
                    Name = firstPlayer,
                    Action = firstPlayerAction
                };
                var player2 = new Player()
                {
                    Name = secondPlayer,
                    Action = secondPlayerAction
                };

                //Act
                var winner = _host.Services.GetService<IMatchBattle>().WinningHand(player1, player2);

                //Assert 
                Assert.True(winner.Name == result);
            }
            catch
            {
                Assert.True(false);
            }
        }


        [Theory]
        [InlineData("TestPlayer1", GameAction.Rock, "TestPlayer2", GameAction.Rock)]
        [InlineData("TestPlayer1", GameAction.Scissors, "TestPlayer2", GameAction.Scissors)]
        [InlineData("TestPlayer1", GameAction.Paper, "TestPlayer2", GameAction.Paper)]
        public void GetWiningHandWithDrawMatch(string firstPlayer, GameAction firstPlayerAction, string secondPlayer, GameAction secondPlayerAction)
        {
            try
            {
                //Arrange
                var player1 = new Player()
                {
                    Name = firstPlayer,
                    Action = firstPlayerAction
                };
                var player2 = new Player()
                {
                    Name = secondPlayer,
                    Action = secondPlayerAction
                };

                //Act
                var winner = _host.Services.GetService<IMatchBattle>().WinningHand(player1, player2);

                //Assert 
                Assert.True(winner == null);
            }
            catch
            {
                Assert.True(false);
            }
        }


    }
}
