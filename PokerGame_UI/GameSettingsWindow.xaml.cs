using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerGame_UI
{
    using PokerGame_Logic;

    /// <summary>
    /// Interaction logic for GameSettingsWindow.xaml
    /// </summary>
    public partial class GameSettingsWindow : Window
    {
        public List<Player> m_PlayersList { get; set; }

        public GameSettingsWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void buttonRegisterPlayers_Click(object sender, RoutedEventArgs e)
        {
            int numOfPlayers;

            if (int.TryParse(comboBoxNumOfPlayers.Text, out numOfPlayers))
            {
                if (this.getPlayersNames(numOfPlayers))
                {
                    listViewPlayersNames.Height = numOfPlayers * 25;
                    displayPlayersNames();
                }
            }
            else
            {
                MessageBox.Show("Please choose the number of players");
            }
        }

        private bool getPlayersNames(int i_NumOfPlayers)
        {
            List<Player> tempPlayersList = new List<Player>();

            for (int i = 0; i < i_NumOfPlayers; i++)
            {
                PlayersNamesWindow currentPlayerName = new PlayersNamesWindow();
                currentPlayerName.lableCurrentPlayerName.Content = string.Format("Enter player number {0}'s Name:", i + 1);
                currentPlayerName.buttonSubmitPlayerName.Content = string.Format("Add player number {0}", i + 1);
                currentPlayerName.ShowDialog();

                if (currentPlayerName.DialogResult == true)
                {
                    tempPlayersList.Add(new Player(currentPlayerName.m_PlayerName));
                }
                else if (currentPlayerName.DialogResult == false)
                {
                    return false;
                }
            }

            m_PlayersList = tempPlayersList;

            return true;
        }

        private void displayPlayersNames()
        {
            int i = 1;

            foreach (Player currentPlayer in m_PlayersList)
            {

                listViewPlayersNames.Items.Add(string.Format("Player{0}: {1}", i, currentPlayer.m_Name));
                i++;
            }
        }

        private void buttonStartGame_Click(object sender, RoutedEventArgs e)
        {
            if (listViewPlayersNames.Items.Count == 0)
            {
                MessageBox.Show("Please register the players");
            }
            else
            {
                PokerGameWindow pokerGame = new PokerGameWindow(m_PlayersList);
                this.Close();
                pokerGame.ShowDialog();
            }
        }
    }
}
