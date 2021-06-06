using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class GameRunner
    {
        //Remove!!!!!!
        public int numOfCombinations;

        public GameBoard m_GameBoard;

        public int m_SmallBlind;

        public int m_BigBlind;

        public int m_SmallBlindIndex;

        public int m_BigBlindIndex;

        public int m_CurrentPlayerIndex;

        public int m_RaisedAmount;

        public int m_RaisedPlayerIndex;

        public int m_NumOfPlayers;

        public int[] m_RaisedMoneyOfEveryPlayerList;

        public int m_NumOfPlayersInCurrentRound;

        public int[] m_PlayersInRoundList;

        public int m_NumOfPlayersEqualed;

        public int m_SubRoundNumber;

        public int[] m_PlayersInRoundScores;

        public int m_NumOfWinningPlayersInRound;

        public GameRunner(List<Player> i_PlayerList)
        {
            //Remove!!!!!!
            this.numOfCombinations = 0;

            m_GameBoard = new GameBoard(i_PlayerList);
            m_SmallBlind = 25;
            m_BigBlind = 50;
            m_SmallBlindIndex = 0;
            m_BigBlindIndex = 1;
            m_RaisedMoneyOfEveryPlayerList = new int[i_PlayerList.Count];
            m_NumOfPlayers = i_PlayerList.Count;
            m_CurrentPlayerIndex = 0;
            m_NumOfPlayersInCurrentRound = i_PlayerList.Count;
            m_PlayersInRoundList = new int[m_NumOfPlayers];
            m_NumOfPlayersEqualed = 0;
            m_SubRoundNumber = 0;
            this.StartNewRound();
        }

        public void StartNewRound()
        {
            m_GameBoard.m_MoneyOnBoard = 0;
            int cardIndex;
            Random randomCardIndex = new Random();
            m_GameBoard.RemovePlayersHandsWhenRoundFinished();

            foreach (Player player in m_GameBoard.m_PlayersList)
            {
                for (int i = 0; i < 2; i++)
                {
                    cardIndex = randomCardIndex.Next(m_GameBoard.m_DeckList.Count);
                    player.m_Hand.Add(m_GameBoard.m_DeckList[cardIndex]);
                    m_GameBoard.m_DeckList.RemoveAt(cardIndex);
                }
            }

            m_GameBoard.m_PlayersList[m_SmallBlindIndex].m_Money -= m_SmallBlind;
            m_GameBoard.m_PlayersList[m_BigBlindIndex].m_Money -= m_BigBlind;
            m_GameBoard.m_MoneyOnBoard += m_SmallBlind + m_BigBlind;
            m_RaisedMoneyOfEveryPlayerList[m_SmallBlindIndex] += m_SmallBlind;
            m_RaisedMoneyOfEveryPlayerList[m_BigBlindIndex] += m_BigBlind;
            this.MoveTurnToNextPlayer();
            this.MoveTurnToNextPlayer();
            m_RaisedAmount = m_BigBlind;
            m_RaisedPlayerIndex = (m_BigBlindIndex + 1) % m_NumOfPlayers;
            initPlayersInRoundScores();
            m_NumOfWinningPlayersInRound = 0;
        }


        public void FindFiveBestCardsForEachPlayerInRound()
        {
            for (int i = 0; i < m_NumOfPlayers; i++)
            {
                if (m_PlayersInRoundList[i] != -1)
                {
                    findFiveBestCardsOfPlayer(i);
                }
            }
        }

        public void RemoveFiveBestCardsForEachPlayerAfterMoneyDivision()
        {
            for (int i = 0; i < m_NumOfPlayers; i++)
            {
                m_GameBoard.m_PlayersList[i].m_FiveBestCardsWhenRoundFinished = new List<Card>();
            }
        }

        public void DevideMoneyWhenRoundIsFinished()
        {
            findNumOfWinningPlayersInRound();

            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                if (m_PlayersInRoundScores[i] != -1)
                {
                    m_GameBoard.m_PlayersList[i].m_Money += m_GameBoard.m_MoneyOnBoard / m_NumOfWinningPlayersInRound;
                }
            }
        }

        private void findNumOfWinningPlayersInRound()
        {
            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                if (m_PlayersInRoundScores[i] != -1)
                {
                    m_NumOfWinningPlayersInRound++;
                }
            }
        }

        public void changeAllIndicesOfNotWinningPlayersScoresToMinusOne(List<Card> i_FiveBestCards)
        {
            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                int equalBetweenTwoListsResult = ChooseBetterListBetweenTwoFiveCardsLists(m_GameBoard.m_PlayersList[i].m_FiveBestCardsWhenRoundFinished, i_FiveBestCards);

                if (equalBetweenTwoListsResult == 2)
                {
                    m_PlayersInRoundScores[i] = -1;
                }
            }
        }

        public List<Card> findFiveBestCardsWhenRoundFinished()
        {
            int maxScore = findMaxScoreOfPlayersWhenRoundFinished();
            List<Card> fiveBestCards = findCardsOfFirstPlayerWithBestScore(maxScore);

            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                    int equalBetweenTwoListsResult = ChooseBetterListBetweenTwoFiveCardsLists(m_GameBoard.m_PlayersList[i].m_FiveBestCardsWhenRoundFinished, fiveBestCards);

                    if (equalBetweenTwoListsResult == 1)
                    {
                        fiveBestCards = m_GameBoard.m_PlayersList[i].m_FiveBestCardsWhenRoundFinished;
                    }
            }

            return fiveBestCards;
        }

        private List<Card> findCardsOfFirstPlayerWithBestScore(int i_MaxScore)
        {
            List<Card> cardsOfBestPlayer = new List<Card>();

            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                if (m_PlayersInRoundScores[i] == i_MaxScore)
                {
                    cardsOfBestPlayer = m_GameBoard.m_PlayersList[i].m_FiveBestCardsWhenRoundFinished;
                    continue;
                }
            }

            return cardsOfBestPlayer;
        } 

        private int findMaxScoreOfPlayersWhenRoundFinished()
        {
            int maxScore = -1;

            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                if (maxScore < m_PlayersInRoundScores[i])
                {
                    maxScore = m_PlayersInRoundScores[i];
                }
            }

            return maxScore;
        }

        public void DetrminePlayersScoresWhenRoundFinish()
        {
            for (int i = 0; i < m_PlayersInRoundScores.Length; i++)
            {
                if (m_PlayersInRoundScores[i] != -1)
                {
                    m_PlayersInRoundScores[i] = (int)DetermineScoreOfSortedFiveCards(SortListOfFiveCards(m_GameBoard.m_PlayersList[i].m_FiveBestCardsWhenRoundFinished));
                }
            }
        }

        private void initPlayersInRoundScores()
        {
            m_PlayersInRoundScores = new int[m_NumOfPlayers];
        }

        private void findFiveBestCardsOfPlayer(int i_playerIndex)
        {
            //Remove!!!!!!
            this.numOfCombinations = 0;

            List<Card> currentFiveBestCards = m_GameBoard.m_OpenCardsList;
            List<Card> nextFiveBestCards = new List<Card>();

            // Check all the options that include the two hand-cards of the player.
            nextFiveBestCards.Add(m_GameBoard.m_PlayersList[i_playerIndex].m_Hand[0]);
            nextFiveBestCards.Add(m_GameBoard.m_PlayersList[i_playerIndex].m_Hand[1]);
            
            for (int i = 0; i < 3; i++)
            {
                nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[i]);

                for (int j = i + 1; j < 4; j++)
                {
                    nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[j]);

                    for (int k = j + 1; k < 5; k++)
                    {
                        //Remove!!!!!!
                        this.numOfCombinations++;

                        nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[k]);

                        // Use copies of the lists in the comparing because in the comparing process
                        // the lists are sorted so there indices are changing. 
                        List<Card> currentFiveBestCardsToSort = copyCardsList(currentFiveBestCards);
                        List<Card> nextFiveBestCardsToSort = copyCardsList(nextFiveBestCards);

                        int betterListVal = ChooseBetterListBetweenTwoFiveCardsLists(currentFiveBestCardsToSort, nextFiveBestCardsToSort);

                        if (betterListVal == 2)
                        {
                            currentFiveBestCards = copyCardsList(nextFiveBestCards);
                        }

                        nextFiveBestCards.RemoveAt(4);
                    }

                    nextFiveBestCards.RemoveAt(3);
                }

                nextFiveBestCards.RemoveAt(2);
            }

            // Check all the options that include one of the hand-cards of the player;
            nextFiveBestCards.RemoveAt(1);
            nextFiveBestCards.RemoveAt(0);

            for (int i = 0; i < 2; i++)
            {
                nextFiveBestCards.Add(m_GameBoard.m_PlayersList[i_playerIndex].m_Hand[i]);

                for (int j = 0; j < 2; j++)
                {
                    nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[j]);

                    for (int k = j + 1; j < 3; j++)
                    {
                        nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[k]);

                        for (int l = k + 1; l < 4; l++)
                        {
                            nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[l]);

                            for (int m = l + 1; l < 5; l++)
                            {
                                //Remove!!!!!!
                                this.numOfCombinations++;

                                nextFiveBestCards.Add(m_GameBoard.m_OpenCardsList[m]);

                                // Use copies of the lists in the comparing because in the comparing process
                                // the lists are sorted so there indices are changing. 
                                List<Card> currentFiveBestCardsToSort = copyCardsList(currentFiveBestCards);
                                List<Card> nextFiveBestCardsToSort = copyCardsList(nextFiveBestCards);

                                int betterListVal = ChooseBetterListBetweenTwoFiveCardsLists(currentFiveBestCardsToSort, nextFiveBestCardsToSort);

                                if (betterListVal == 2)
                                {
                                    currentFiveBestCards = copyCardsList(nextFiveBestCards);
                                }

                                nextFiveBestCards.RemoveAt(4);
                            }

                            nextFiveBestCards.RemoveAt(3);
                        }

                        nextFiveBestCards.RemoveAt(2);
                    }

                    nextFiveBestCards.RemoveAt(1);
                }

                nextFiveBestCards.RemoveAt(0);
            }
            
            m_GameBoard.m_PlayersList[i_playerIndex].m_FiveBestCardsWhenRoundFinished = SortListOfFiveCards(currentFiveBestCards);
        }

        // Returns 1 if the first list is better, 2 if the second list is better and 3 if they are equal.
        public int ChooseBetterListBetweenTwoFiveCardsLists(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            i_FirstList = SortListOfFiveCards(i_FirstList);
            i_SecondList = SortListOfFiveCards(i_SecondList);
            eScore firstListScore = DetermineScoreOfSortedFiveCards(i_FirstList);
            eScore secondListScore = DetermineScoreOfSortedFiveCards(i_SecondList);

            if (firstListScore > secondListScore)
            {
                return 1;
            }
            else if (secondListScore > firstListScore)
            {
                return 2;
            }
            else
            {
                return equalBetweenTwoListsWithSameScore(i_FirstList, i_SecondList, firstListScore);
            }
        }

        // Returns 1 if the first list is better, 2 if the second list is better and 3 if they are equal.
        private int equalBetweenTwoListsWithSameScore(List<Card> i_FirstList, List<Card> i_SecondList, eScore i_ListsScore)
        {
            switch(i_ListsScore)
            {
                case eScore.HighCard:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithHighCard(i_FirstList, i_SecondList);
                case eScore.OnePair:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithOnePair(i_FirstList, i_SecondList);
                case eScore.TwoPairs:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithTwoPairs(i_FirstList, i_SecondList);
                case eScore.ThreeOfAKind:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithThreeOfAKind(i_FirstList, i_SecondList);
                case eScore.Straight:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithStraight(i_FirstList, i_SecondList);
                case eScore.Flush:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithFlush(i_FirstList, i_SecondList);
                case eScore.FullHouse:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithFullHouse(i_FirstList, i_SecondList);
                case eScore.FourOfAKind:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithFourOfAKind(i_FirstList, i_SecondList);
                case eScore.StraightFlush:
                    return GradingCardsList.ChooseBetweenTwoSortedListsWithStraightFlush(i_FirstList, i_SecondList);
            }

            return 3;
        }

        public eScore DetermineScoreOfSortedFiveCards(List<Card> i_CardsList)
        {
            if (GradingCardsList.IsSortedListContainsStraightFlush(i_CardsList))
            {
                return eScore.StraightFlush;
            }

            if (GradingCardsList.IsSortedListContainsFour(i_CardsList)) 
            {
                return eScore.FourOfAKind;
            }

            if (GradingCardsList.IsSortedListContainsFullHouse(i_CardsList))
            {
                return eScore.FullHouse;
            }

            if (GradingCardsList.IsSortedListContainsFlush(i_CardsList))
            {
                return eScore.Flush;
            }

            if (GradingCardsList.IsSortedListContainsStraight(i_CardsList))
            {
                return eScore.Straight;
            }

            if (GradingCardsList.IsSortedListContainsThree(i_CardsList))
            {
                return eScore.ThreeOfAKind;
            }


            if (GradingCardsList.IsSortedListContainsTwoPairs(i_CardsList))
            {
                return eScore.TwoPairs;
            }

            if (GradingCardsList.IsSortedListContainsOnePair(i_CardsList))
            {
                return eScore.OnePair;
            }

            return eScore.HighCard;
        }

        public List<Card> SortListOfFiveCards(List<Card> i_CardsList)
        {
            Card tempCard;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                for (int j = 0; j < i_CardsList.Count - 1; j++)
                {
                    if ((int)i_CardsList[j].m_CardValue > (int)i_CardsList[j + 1].m_CardValue)
                    {
                        tempCard = i_CardsList[j + 1];
                        i_CardsList[j + 1] = i_CardsList[j];
                        i_CardsList[j] = tempCard;
                    }
                }
            }

            return i_CardsList;
        }

        private List<Card> copyCardsList(List<Card> i_CardsList)
        {
            List<Card> newCardsList = new List<Card>();

            for (int i = 0; i < i_CardsList.Count; i++)
            {
                newCardsList.Add(i_CardsList[i]);
            }

            return newCardsList;
        }


        public void OpenThreeCards()
        {
            for (int i = 0; i < 3; i++)
            {
                OpenOneCard();
            }
        }

        public void OpenOneCard()
        {
            int cardIndex;
            Random randomCardIndex = new Random();
            cardIndex = randomCardIndex.Next(m_GameBoard.m_DeckList.Count);
            m_GameBoard.m_OpenCardsList.Add(m_GameBoard.m_DeckList[cardIndex]);
            m_GameBoard.m_DeckList.RemoveAt(cardIndex);
        }

        public void MoveTurnToNextPlayer()
        {
            m_CurrentPlayerIndex = (m_CurrentPlayerIndex + 1) % m_NumOfPlayers;

            if (m_PlayersInRoundList[m_CurrentPlayerIndex] == -1)
            {
                MoveTurnToNextPlayer();
            }
        }
    }
}
