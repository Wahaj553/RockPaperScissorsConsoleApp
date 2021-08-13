using System;
using Microsoft.Extensions.Options;
using RPS_ConsoleApp.Model;

namespace RPS_ConsoleApp.Helper
{
    public class MatchExecution : IMatchExecution
    {
        private readonly IMatchBattle _matchBattle;
        private readonly GameSettings _gameSettingsConfiguration;

        public MatchExecution(IOptions<GameSettings> gameSettingsConfiguration, IMatchBattle matchBattle)
        {
            _gameSettingsConfiguration = gameSettingsConfiguration.Value;
            _matchBattle = matchBattle;
        }
        /// <summary>
        /// Start the flow execution for ROCK,PAPER,SCISSORS
        /// </summary>
        /// <param name="firstPlayerName">Any Human Player</param>
        public void StartMatchExecution(string firstPlayerName)
        {
            try
            {
                var noOfGames = _gameSettingsConfiguration.NoOfGames;
                var secondPlayerName = _gameSettingsConfiguration.SecondPlayerName;

                #region Best of three with two players 
                Console.Write($"Hi {firstPlayerName},");
                
                var player1 = new Player()
                {
                    Name = firstPlayerName,
                };
                var player2 = new Player()
                {
                    Name = secondPlayerName,
                };
                var playAgain = true;
                while (playAgain)
                {
                    var scorePlayer = 0;
                    var scoreCpu = 0;
                    var maxRetry = 0;
                    while (maxRetry < noOfGames)
                    {
                        Console.Write("Choose between ROCK, PAPER and SCISSORS: ");
                        var inputPlayer = Console.ReadLine()?.ToUpper();
                        if (inputPlayer == GameAction.Rock.ToString().ToUpper() || inputPlayer == GameAction.Paper.ToString().ToUpper() || inputPlayer == GameAction.Scissors.ToString().ToUpper())
                        {
                            var rnd = new Random();
                            var randomInt = rnd.Next(1, 3);
                            player1.Action = (GameAction)Enum.Parse(typeof(GameAction),inputPlayer,true);
                            player2.Action = ((GameAction)randomInt);
                            Console.WriteLine($"{secondPlayerName} chose { player2.Action}");

                            //Call the Match Battle method 
                            var winner = _matchBattle.WinningHand(player1, player2);
                            if (winner == null)
                            {
                                Console.WriteLine("The Game was a draw.");
                            }
                            else
                            {
                                Console.WriteLine($"The Winner of this battle : {winner.Name}");
                                if (winner.Name == secondPlayerName)
                                    scoreCpu++;
                                else
                                    scorePlayer++;

                                maxRetry++;
                            }

                            Console.WriteLine($"\n\nSCORES:\t{firstPlayerName}:\t{scorePlayer}\t{secondPlayerName}:\t{scoreCpu}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input...");
                        }
                    }
                    #endregion
                    #region Winners and play again logic
                    if (scorePlayer >= 2)
                    {
                        Console.WriteLine($"{firstPlayerName} WON!");
                    }
                    else if (scoreCpu >= 2)
                    {
                        Console.WriteLine($"{secondPlayerName} WON!");
                    }

                    Console.WriteLine("Do you want to play again?(y/n)");
                    var loop = Console.ReadLine();
                    switch (loop)
                    {
                        case "y":
                            Console.Clear();
                            break;
                        case "n":
                            playAgain = false;
                            break;
                    }
                    #endregion
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
