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
    using System.Security.Cryptography;
    using PokerGame_Logic;

    /// <summary>
    /// Interaction logic for PokerGameWindow.xaml
    /// </summary>
    public partial class PokerGameWindow : Window
    {
        private GameRunner m_GameRunner { get; set; }

        private Button[] m_ButtonArray { get; set; }

        private Label[] m_MoneyLabels { get; set; }

        private List<Image> m_ImagesList;

        private Label[] m_BlindsLabels { get; set; }

        private Brush m_ButtonDefaultBackground;

        public PokerGameWindow(List<Player> i_PlayersList)
        {
            m_GameRunner = new GameRunner(i_PlayersList);
            m_ButtonArray = new Button[i_PlayersList.Count];
            m_MoneyLabels = new Label[i_PlayersList.Count];
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
                currentButton.Margin = new Thickness(left, 0, 0, 0);
                m_ButtonArray[index] = currentButton;
                m_ButtonArray[index].Tag = index;
                m_ButtonArray[index].Click += new RoutedEventHandler(playerButton_Click);
                Grid.SetRow(m_ButtonArray[index], 0);
                this.MainGrid.Children.Add(m_ButtonArray[index]);

                m_MoneyLabels[index] = new Label();
                m_MoneyLabels[index].Content = currentPlayer.m_Money.ToString();
                m_MoneyLabels[index].Name = "labelPlayerMoney" + index;
                m_MoneyLabels[index].Margin = new Thickness(left, 80, 0, 0);
                m_MoneyLabels[index].Tag = index;
                Grid.SetRow(this.m_MoneyLabels[index], 0);
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
            Grid.SetRow(this.m_BlindsLabels[0], 0);

            this.m_BlindsLabels[1] = new Label();
            this.m_BlindsLabels[1].Content = "Big Blind";
            this.m_MoneyLabels[1].Name = "labelBigBlind";
            this.m_BlindsLabels[1].Margin = new Thickness(180, 100, 0, 0);
            this.m_BlindsLabels[1].Foreground = Brushes.Blue;
            this.MainGrid.Children.Add(this.m_BlindsLabels[1]);
            Grid.SetRow(this.m_BlindsLabels[1], 0);

            labelRaisedMoneyAmount.Content = null;
            updateLabels();
            m_ButtonDefaultBackground = m_ButtonArray[0].Background;
        }

        private void updateLabels()
        {
            this.labelCurrentPlayerName.Content = currentPlayer().m_Name;
            this.labelMoneyOnBoardValue.Content = m_GameRunner.m_GameBoard.m_MoneyOnBoard.ToString();

            for (int i = 0; i < m_GameRunner.m_NumOfPlayers; i++)
            {
                this.m_MoneyLabels[i].Content = m_GameRunner.m_GameBoard.m_PlayersList[i].m_Money.ToString();
            }

            this.textBoxMoneyToRaise.Text = null;
            this.labelRaisedMoneyAmount.Content = m_GameRunner.m_RaisedAmount;
        }

        private void playerButton_Click(object sender, EventArgs e)
        {
            int playerIndex = Convert.ToInt32((sender as Button).Tag);

            if (playerIndex < m_GameRunner.m_GameBoard.m_PlayersList.Count)
            {
                eCardValue firstCardValue = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[0].m_CardValue;
                eCardType firstCardType = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[0].m_CardType;
                eCardValue secondCardValue = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[1].m_CardValue;
                eCardType secondCardType = m_GameRunner.m_GameBoard.m_PlayersList[playerIndex].m_Hand[1].m_CardType;
                this.buttonPlayerCard1.Background = new ImageBrush(m_ImagesList[4 * ((int)firstCardValue - 1) + (int)firstCardType].Source);
                this.buttonPlayerCard2.Background = new ImageBrush(m_ImagesList[4 * ((int)secondCardValue - 1) + (int)secondCardType].Source);
            }
            else
            {
                MessageBox.Show("This player loss the game");
            }
        }

        private Player currentPlayer()
        {
            return m_GameRunner.m_GameBoard.m_PlayersList[m_GameRunner.m_CurrentPlayerIndex];
        }

        private void buttonRaise_Click(object sender, RoutedEventArgs e)
        {
            int moneyToRaise = 0;

            if (!int.TryParse(textBoxMoneyToRaise.Text, out moneyToRaise)) 
            {
                MessageBox.Show("Please enter the amount of money to raise!");
            }
            else if (moneyToRaise > currentPlayer().m_Money + m_GameRunner.m_RaisedMoneyOfEveryPlayerList[m_GameRunner.m_CurrentPlayerIndex])
            {
                MessageBox.Show("amount of money can't be bigger then the money you have!");
            }
            else if (moneyToRaise <= m_GameRunner.m_RaisedAmount)
            {
                MessageBox.Show("If you want to equal please choose the Make Equal button!");
            }
            else
            {
                m_GameRunner.m_NumOfPlayersEqualed = 1;
                m_GameRunner.m_RaisedAmount = moneyToRaise;
                updateMoneyOnEqualOrRaise();
                m_GameRunner.m_RaisedPlayerIndex = m_GameRunner.m_CurrentPlayerIndex;
                updateLabels();
                m_GameRunner.MoveTurnToNextPlayer();
                labelCurrentPlayerName.Content = m_GameRunner.m_GameBoard.m_PlayersList[m_GameRunner.m_CurrentPlayerIndex];
                updateLabels();
            }
        }

        private void buttonMakeEqual_Click(object sender, RoutedEventArgs e)
        {
            if (currentPlayer().m_Money + m_GameRunner.m_RaisedMoneyOfEveryPlayerList[m_GameRunner.m_CurrentPlayerIndex] >= m_GameRunner.m_RaisedAmount)
            {
                m_GameRunner.m_NumOfPlayersEqualed += 1;
                updateMoneyOnEqualOrRaise();

                if (((m_GameRunner.m_CurrentPlayerIndex + 1) % m_GameRunner.m_NumOfPlayers != m_GameRunner.m_RaisedPlayerIndex) && m_GameRunner.m_NumOfPlayersEqualed != m_GameRunner.m_NumOfPlayersInCurrentRound)
                {
                    updateLabels();
                    m_GameRunner.MoveTurnToNextPlayer();
                    labelCurrentPlayerName.Content = m_GameRunner.m_GameBoard.m_PlayersList[m_GameRunner.m_CurrentPlayerIndex];
                    updateLabels();
                }
                else
                {
                    updateLabels();
                    subRoundFinished();
                }
            }
            else
            {
                notEnoughMoneyToEqualCase();
            }
        }

        private void updateMoneyOnEqualOrRaise()
        {
            currentPlayer().m_Money -= m_GameRunner.m_RaisedAmount - m_GameRunner.m_RaisedMoneyOfEveryPlayerList[m_GameRunner.m_CurrentPlayerIndex];
            m_GameRunner.m_GameBoard.m_MoneyOnBoard += m_GameRunner.m_RaisedAmount - m_GameRunner.m_RaisedMoneyOfEveryPlayerList[m_GameRunner.m_CurrentPlayerIndex];
            m_GameRunner.m_RaisedMoneyOfEveryPlayerList[m_GameRunner.m_CurrentPlayerIndex] = m_GameRunner.m_RaisedAmount;
        }

        private void subRoundFinished()
        {
            MessageBox.Show("Sub round finished!");
            
            if (m_GameRunner.m_SubRoundNumber == 3)
            {
                roundFinished();

                return;
            }
            else if (m_GameRunner.m_SubRoundNumber == 0)
            {
                m_GameRunner.OpenThreeCards();
                eCardValue firstCardValue = m_GameRunner.m_GameBoard.m_OpenCardsList[0].m_CardValue;
                eCardType firstCardType = m_GameRunner.m_GameBoard.m_OpenCardsList[0].m_CardType;
                eCardValue secondCardValue = m_GameRunner.m_GameBoard.m_OpenCardsList[1].m_CardValue;
                eCardType secondCardType = m_GameRunner.m_GameBoard.m_OpenCardsList[1].m_CardType;
                eCardValue thirdCardValue = m_GameRunner.m_GameBoard.m_OpenCardsList[2].m_CardValue;
                eCardType thirdCardType = m_GameRunner.m_GameBoard.m_OpenCardsList[2].m_CardType;

                this.buttonCard1.Background = new ImageBrush(m_ImagesList[4 * ((int)firstCardValue - 1) + (int)firstCardType].Source);
                this.buttonCard2.Background = new ImageBrush(m_ImagesList[4 * ((int)secondCardValue - 1) + (int)secondCardType].Source);
                this.buttonCard3.Background = new ImageBrush(m_ImagesList[4 * ((int)thirdCardValue - 1) + (int)thirdCardType].Source);
            }
            else if (m_GameRunner.m_SubRoundNumber == 1)
            {
                m_GameRunner.OpenOneCard();
                eCardValue fourthCardValue = m_GameRunner.m_GameBoard.m_OpenCardsList[3].m_CardValue;
                eCardType fourthCardType = m_GameRunner.m_GameBoard.m_OpenCardsList[3].m_CardType;
                this.buttonCard4.Background = new ImageBrush(m_ImagesList[4 * ((int)fourthCardValue - 1) + (int)fourthCardType].Source);
            }
            else
            {
                m_GameRunner.OpenOneCard();
                eCardValue fifthCardValue = m_GameRunner.m_GameBoard.m_OpenCardsList[4].m_CardValue;
                eCardType fifthCardType = m_GameRunner.m_GameBoard.m_OpenCardsList[4].m_CardType;
                this.buttonCard5.Background = new ImageBrush(m_ImagesList[4 * ((int)fifthCardValue - 1) + (int)fifthCardType].Source);
            }

            initValuesWhenSubRoundFinished();
        }

        private void initValuesWhenSubRoundFinished()
        {
            m_GameRunner.m_SubRoundNumber++;
            m_GameRunner.m_RaisedAmount = 0;
            m_GameRunner.m_CurrentPlayerIndex = m_GameRunner.m_SmallBlindIndex;
            m_GameRunner.m_RaisedPlayerIndex = m_GameRunner.m_CurrentPlayerIndex;
            m_GameRunner.m_NumOfPlayersEqualed = 0;

            if (m_GameRunner.m_PlayersInRoundList[m_GameRunner.m_CurrentPlayerIndex] == -1)
            {
                m_GameRunner.MoveTurnToNextPlayer();
            }

            for (int i = 0; i < m_GameRunner.m_NumOfPlayers; i++)
            {
                m_GameRunner.m_RaisedMoneyOfEveryPlayerList[i] = 0;
            }

            updateLabels();
        }

        private void notEnoughMoneyToEqualCase()
        {
            MessageBox.Show("You don't have enough money, Your All-in!");

            m_GameRunner.m_GameBoard.m_MoneyOnBoard += currentPlayer().m_Money;
            currentPlayer().m_Money = 0;
            openNewMoneyBox();
            updateLabels();
            m_GameRunner.MoveTurnToNextPlayer();
            updateLabels();
        }

        private void openNewMoneyBox()
        {
            MessageBox.Show("Open new money-box case");
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            m_GameRunner.m_NumOfPlayersInCurrentRound -= 1;
            m_GameRunner.m_PlayersInRoundList[m_GameRunner.m_CurrentPlayerIndex] = -1;
            m_GameRunner.m_PlayersInRoundScores[m_GameRunner.m_CurrentPlayerIndex] = -1;

            MessageBox.Show(string.Format("{0} Quitted this round!", currentPlayer().m_Name));

            if (m_GameRunner.m_NumOfPlayersInCurrentRound == 1)
            {
                roundFinished();
            }
            else if ((m_GameRunner.m_CurrentPlayerIndex + 1) % m_GameRunner.m_NumOfPlayers != m_GameRunner.m_RaisedPlayerIndex)
            {
                updateLabels();
                m_GameRunner.MoveTurnToNextPlayer();
                labelCurrentPlayerName.Content = m_GameRunner.m_GameBoard.m_PlayersList[m_GameRunner.m_CurrentPlayerIndex];
                updateLabels();
            }
            else
            {
                updateLabels();
                subRoundFinished();
            }
        }

        private void updateMoneyLabelsWhenPlayerLoss(int index)
        {
            Label[] newMoneyLabels = new Label[m_MoneyLabels.Length - 1];
            int j = 0;

            for (int i = 0; i < newMoneyLabels.Length; i++)
            {
                if (i != index)
                {
                    newMoneyLabels[i] = m_MoneyLabels[j];
                    j++;
                }
                else
                {
                    j++;
                    newMoneyLabels[i] = m_MoneyLabels[j];
                    j++;
                }
            }

            m_MoneyLabels = newMoneyLabels;
        }

        private void updateButtonArrayWhenPlayerLoss(int index)
        {
            Button[] newButtonArray = new Button[m_ButtonArray.Length - 1];
            int j = 0;

            for (int i = 0; i < newButtonArray.Length; i++)
            {
                if (i != index)
                {
                    newButtonArray[i] = m_ButtonArray[j];
                    j++;
                }
                else
                {
                    j++;
                    newButtonArray[i] = m_ButtonArray[j];
                    j++;
                }
            }

            m_ButtonArray = newButtonArray;
        }

        private void roundFinished()
        {
            MessageBox.Show("Round finished!");
            divideMoneyWhenRoundFinished();

            int numOfPlayers = m_GameRunner.m_NumOfPlayers;

            for (int i = 0; i < numOfPlayers; i++)
            {
                if (m_GameRunner.m_GameBoard.m_PlayersList[i].m_Money == 0)
                {
                    MessageBox.Show(string.Format("{0} loss the game!", m_GameRunner.m_GameBoard.m_PlayersList[i].m_Name));
                    m_GameRunner.m_NumOfPlayers--;
                    numOfPlayers--;
                    m_GameRunner.m_GameBoard.m_PlayersList.RemoveAt(i);
                    m_GameRunner.MoveTurnToNextPlayer();
                    updateMoneyLabelsWhenPlayerLoss(i);
                    updateButtonArrayWhenPlayerLoss(i);
                }
            }

            updateBlidnsIndicesWhenRoundFinished();
            moveBlindsLabelsWhenRoundFinished();
            initDeckWhenRoundFinished();
            removeCardsFromButtons();

            if (m_GameRunner.m_NumOfPlayers == 1)
            {
                MessageBox.Show(string.Format("{0} won the game!", m_GameRunner.m_GameBoard.m_PlayersList[0].m_Name));
                this.Close();
            }
            else
            {
                m_GameRunner.StartNewRound();
                updateLabels();
            }
        }

        private void divideMoneyWhenRoundFinished()
        {
            m_GameRunner.FindFiveBestCardsForEachPlayerInRound();
            m_GameRunner.DetrminePlayersScoresWhenRoundFinish();
            showPlayersScoresInMessageBox();
            m_GameRunner.changeAllIndicesOfNotWinningPlayersScoresToMinusOne(m_GameRunner.findFiveBestCardsWhenRoundFinished());
            showWinningPlayersNames();
            m_GameRunner.DevideMoneyWhenRoundIsFinished();

            m_GameRunner.m_GameBoard.m_MoneyOnBoard = 0;
        }

        private void showWinningPlayersNames()
        {
            StringBuilder winningPlayers = new StringBuilder();

            for (int i = 0; i < m_GameRunner.m_PlayersInRoundScores.Length; i++)
            {
                if (m_GameRunner.m_PlayersInRoundScores[i] != -1)
                {
                    winningPlayers.Append(string.Format("{0}, ", m_GameRunner.m_GameBoard.m_PlayersList[i].m_Name));
                }
            }

            winningPlayers.Remove(winningPlayers.Length - 2, 2);
            winningPlayers.Append(" Won this Round!");

            MessageBox.Show(winningPlayers.ToString());
        }

        private void showPlayersScoresInMessageBox()
        {
            for (int i = 0; i < m_GameRunner.m_PlayersInRoundScores.Length; i++)
            {
                if (m_GameRunner.m_PlayersInRoundScores[i] != -1)
                {
                    MessageBox.Show(string.Format("{0} has {1}", m_GameRunner.m_GameBoard.m_PlayersList[i].m_Name, (eScore)m_GameRunner.m_PlayersInRoundScores[i]));
                }
            }
        }


        private void updateBlidnsIndicesWhenRoundFinished()
        {
            m_GameRunner.m_SmallBlindIndex = (m_GameRunner.m_SmallBlindIndex + 1) % m_GameRunner.m_NumOfPlayers;
            m_GameRunner.m_BigBlindIndex = (m_GameRunner.m_BigBlindIndex + 1) % m_GameRunner.m_NumOfPlayers;
        }

        private void moveBlindsLabelsWhenRoundFinished()
        {
            m_BlindsLabels[0].Margin = new Thickness(100 + m_GameRunner.m_SmallBlindIndex * 80, 100, 0, 0);
            m_BlindsLabels[1].Margin = new Thickness(100 + m_GameRunner.m_BigBlindIndex * 80, 100, 0, 0);
        }

        private void initDeckWhenRoundFinished()
        {
            m_GameRunner.m_GameBoard.m_OpenCardsList = new List<Card>();
            m_GameRunner.m_GameBoard.m_DeckList = new List<Card>();
            m_GameRunner.m_GameBoard.initDeck();
        }

        private void removeCardsFromButtons()
        {
            this.buttonPlayerCard1.Background = m_ButtonDefaultBackground;
            this.buttonPlayerCard2.Background = m_ButtonDefaultBackground;
            this.buttonCard1.Background = m_ButtonDefaultBackground;
            this.buttonCard2.Background = m_ButtonDefaultBackground;
            this.buttonCard3.Background = m_ButtonDefaultBackground;
            this.buttonCard4.Background = m_ButtonDefaultBackground;
            this.buttonCard5.Background = m_ButtonDefaultBackground;
        }

        private void buttonHideHand_Click(object sender, RoutedEventArgs e)
        {
            this.buttonPlayerCard1.Background = m_ButtonDefaultBackground;
            this.buttonPlayerCard2.Background = m_ButtonDefaultBackground;
        }
    }
}
