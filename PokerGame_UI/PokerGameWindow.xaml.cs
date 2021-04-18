using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokerGame_UI
{
    using System.IO;

    using PokerGame_Logic;

    /// <summary>
    /// Interaction logic for PokerGameWindow.xaml
    /// </summary>
    public partial class PokerGameWindow : Window
    {
        public GameRunner m_GameRunner { get; set; }

        private Button[] m_ButtonArray { get; set; }

        private Label[] m_MoneyLabels { get; set; }

        private List<Image> m_ImagesList;

        private Label[] m_BlindsLabels { get; set; }

        public PokerGameWindow(List<Player> i_PlayersList)
        {
            m_GameRunner = new GameRunner(i_PlayersList);
            m_ButtonArray = new Button[i_PlayersList.Count];
            this.m_MoneyLabels = new Label[i_PlayersList.Count];
            m_BlindsLabels = new Label[2];

            initImageList();
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            initButtons();
        }

        private void initImageList()
        {
            var enviroment = System.Environment.CurrentDirectory;
            string imagesDirectory = Directory.GetParent(enviroment).Parent.FullName + "\\cards_png";
            string[] imagesStringsArray = Directory.GetFiles(imagesDirectory);
            List<string> imagesPathsList = imagesStringsArray.ToList();
            m_ImagesList = new List<Image>();

            foreach (string currentImagePath in imagesPathsList)
            {
                ImageSource imageSource = new BitmapImage(new Uri(currentImagePath));
                Image currentImage = new Image();
                currentImage.Source = imageSource;
                this.m_ImagesList.Add(currentImage);
            }
        }

        private void initButtons()
        {
            int index = 0;
            int left = 100;

            foreach (Player currentPlayer in m_GameRunner.m_GameBoard.m_PlayersList)
            {
                Button currentButton = new Button();
                currentButton.Content = currentPlayer.m_Name;
                currentButton.Name = "buttonPlayer" + index;
                currentButton.Width = 50;
                currentButton.Height = 80;
                currentButton.VerticalAlignment = 0;
                currentButton.HorizontalAlignment = 0;
                currentButton.Margin = new Thickness(left, 0, 0 , 0);
                m_ButtonArray[index] = currentButton;
                m_ButtonArray[index].Tag = index;
                m_ButtonArray[index].Click += new RoutedEventHandler(playerButton_Click);
                Grid.SetRow(m_ButtonArray[index], 1);
                this.MainGrid.Children.Add(m_ButtonArray[index]);

                m_MoneyLabels[index] = new Label();
                m_MoneyLabels[index].Content = currentPlayer.m_Money.ToString();
                m_MoneyLabels[index].Name = "labelPlayerMoney" + index;
                m_MoneyLabels[index].Margin = new Thickness(left, 80, 0, 0);
                m_MoneyLabels[index].Tag = index;
                Grid.SetRow(this.m_MoneyLabels[index], 1);
                MainGrid.Children.Add(this.m_MoneyLabels[index]);

                left += 80;
                index++;
            }

            this.m_BlindsLabels[0] = new Label();
            this.m_BlindsLabels[0].Content = "Small Blind";
            this.m_MoneyLabels[0].Name = "labelSmallBlind";
            this.m_BlindsLabels[0].Margin = new Thickness(100, 100, 0, 0);
            this.m_BlindsLabels[0].Foreground = Brushes.Red;
            this.MainGrid.Children.Add(this.m_BlindsLabels[0]);
            Grid.SetRow(this.m_BlindsLabels[0], 2);

            this.m_BlindsLabels[1] = new Label();
            this.m_BlindsLabels[1].Content = "Big Blind";
            this.m_MoneyLabels[1].Name = "labelBigBlind";
            this.m_BlindsLabels[1].Margin = new Thickness(180, 100, 0, 0);
            this.m_BlindsLabels[1].Foreground = Brushes.Blue;
            this.MainGrid.Children.Add(this.m_BlindsLabels[1]);
            Grid.SetRow(this.m_BlindsLabels[1], 2);

            updateLabels();
        }

        private void updateLabels()
        {
            this.labelCurrentPlayerName.Content = currentPlayer().m_Name;
            this.labelMoneyOnBoardValue.Content = m_GameRunner.m_GameBoard.m_MoneyOnBoard.ToString();
            this.m_MoneyLabels[m_GameRunner.m_CurrentPlayerIndex].Content = currentPlayer().m_Money.ToString();
        }

        private void playerButton_Click(object sender, EventArgs e)
        {
            int playerIndex = Convert.ToInt32((sender as Button).Tag);

            eCardValue firstCardValue = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[0].m_CardValue;
            eCardType firstCardType = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[0].m_CardType;
            eCardValue secondCardValue = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[1].m_CardValue;
            eCardType secondCardType = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[1].m_CardType;

            this.buttonPlayerCard1.Background = new ImageBrush(m_ImagesList[4 * ((int)firstCardValue - 1) + (int)firstCardType].Source);
            this.buttonPlayerCard2.Background = new ImageBrush(m_ImagesList[4 * ((int)secondCardValue - 1) + (int)secondCardType].Source);
        }

        private Player currentPlayer()
        {
            return m_GameRunner.m_GameBoard.m_PlayersList[m_GameRunner.m_CurrentPlayerIndex];
        }

        private void buttonMakeEqual_Click(object sender, EventArgs e)
        {
            if (currentPlayer().m_Money >= m_GameRunner.m_RaisedAmount)
            {
                currentPlayer().m_Money -= m_GameRunner.m_RaisedAmount;
                m_GameRunner.m_GameBoard.m_MoneyOnBoard += m_GameRunner.m_RaisedAmount;
                updateLabels();
                m_GameRunner.MoveTurnToNextPlayer();
                updateLabels();
            }
            else
            {
                MessageBox.Show("Not enough money case");
            }
        }
    }
}
