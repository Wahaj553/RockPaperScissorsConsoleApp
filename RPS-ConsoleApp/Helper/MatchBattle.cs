using RPS_ConsoleApp.Model;

namespace RPS_ConsoleApp.Helper
{
   public class MatchBattle : IMatchBattle
    {
        /// <summary>
        ///  Return the winner of the game or null in case of draw
        ///  Rock Beats Scissors
        ///  Scissors Beats Paper
        ///  Paper Beats Rock
        /// </summary>
        /// <param name="humanPlayer"></param>
        /// <param name="computerPlayer"></param>
        /// <returns></returns>
        public Player WinningHand(Player humanPlayer, Player computerPlayer)
        {
            return humanPlayer.Action switch
            {
                GameAction.Paper when computerPlayer.Action == GameAction.Rock => humanPlayer,
                GameAction.Paper when computerPlayer.Action == GameAction.Scissors => computerPlayer,
                GameAction.Scissors when computerPlayer.Action == GameAction.Paper => humanPlayer,
                GameAction.Scissors when computerPlayer.Action == GameAction.Rock => computerPlayer,
                GameAction.Rock when computerPlayer.Action == GameAction.Paper => computerPlayer,
                GameAction.Rock when computerPlayer.Action == GameAction.Scissors => humanPlayer,
                _ => null
            };
        }
    }
}
