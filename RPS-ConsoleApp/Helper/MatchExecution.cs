using System;
using RPS_ConsoleApp.Model;

namespace RPS_ConsoleApp.Helper
{
    public class MatchExecution : IMatchExecution
    {
        private readonly IMatchBattle _matchBattle;

        public MatchExecution(IMatchBattle matchBattle)
        {
            _matchBattle = matchBattle;
        }
        /// <summary>
        /// Start the flow execution for ROCK,PAPER,SCISSORS
        /// </summary>
        /// <param name="playerName">Any Human Player</param>
        public void StartMatchExecution(string playerName)
        {
            try
            {
                #region Best of three with two players 
                var playAgain = true;
                var player1 = new Player()
                {
                    Name = playerName,
                };
                var player2 = new Player()
                {
                    Name = "ComputerPlayer",//Default Computer Player Name
                };


                while (playAgain)
                {
                    var scorePlayer = 0;
                    var scoreCpu = 0;
                    var maxRetry = 0;
                    while (maxRetry < 3)
                    {
                        Console.Write("Choose between ROCK, PAPER and SCISSORS: ");
                        var inputPlayer = Console.ReadLine()?.ToUpper();
                        if (inputPlayer == GameAction.Rock.ToString().ToUpper() || inputPlayer == GameAction.Paper.ToString().ToUpper() || inputPlayer == GameAction.Scissors.ToString().ToUpper())
                        {
                            var rnd = new Random();
                            var randomInt = rnd.Next(1, 3);
                            player1.Action = (GameAction)Enum.Parse(typeof(GameAction),inputPlayer,true);
                            player2.Action = ((GameAction)randomInt);
                            Console.WriteLine($"ComputerPlayer chose { player2.Action}");

                            //Call the Match Battle method 
                            var winner = _matchBattle.WinningHand(player1, player2);
                            if (winner == null)
                            {
                                Console.WriteLine("The Game was a draw.");
                            }
                            else
                            {
                                Console.WriteLine("The Winner of this battle : {0}", winner.Name);
                                if (winner.Name == "ComputerPlayer")
                                    scoreCpu++;
                                else
                                    scorePlayer++;

                                maxRetry++;
                            }

                            Console.WriteLine("\n\nSCORES:\tHumanPLAYER:\t{0}\tComputerPlayer:\t{1}", scorePlayer,
                                scoreCpu);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input, Choose between ROCK, PAPER and SCISSORS: ");
                        }
                    }
                    #endregion
                    #region Winners and play again logic
                    if (scorePlayer >= 2)
                    {
                        Console.WriteLine("HumanPlayer WON!");
                    }
                    else if (scoreCpu >= 2)
                    {
                        Console.WriteLine("ComputerPlayer WON!");
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
