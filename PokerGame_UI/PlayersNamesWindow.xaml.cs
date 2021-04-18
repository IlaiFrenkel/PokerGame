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
using System.Windows.Shapes;

namespace PokerGame_UI
{
    /// <summary>
    /// Interaction logic for PlayersNamesWindow.xaml
    /// </summary>
    public partial class PlayersNamesWindow : Window
    {
        public string m_PlayerName { get; set; }

        public PlayersNamesWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void buttonSubmitPlayerName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBoxPlayerName.Text))
            {
                m_PlayerName = TextBoxPlayerName.Text;
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter the player name");
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
