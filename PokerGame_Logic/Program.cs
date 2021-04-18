using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class Program
    {
        public static void Main()
        {
            List<Player> gamePlayers = new List<Player>();
            GameBoard gameBoard = new GameBoard(gamePlayers);
        }
    }
}
