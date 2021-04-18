using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_UI
{
    public class WindowsManager
    {
        public static void Run()
        {
            GameSettingsWindow gameSettings = new GameSettingsWindow();

            if (gameSettings.ShowDialog() == true)
            {
                PokerGameWindow pokerGame = new PokerGameWindow(gameSettings.m_PlayersList);
                pokerGame.ShowDialog();
            }
        }
    }
}
