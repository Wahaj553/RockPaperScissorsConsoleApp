using RPS_ConsoleApp.Model;

namespace RPS_ConsoleApp.Helper
{
   public interface IMatchBattle
   {
       Player WinningHand(Player humanPlayer, Player computerPlayer);
   }
}
