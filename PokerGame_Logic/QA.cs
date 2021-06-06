using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class QA
    {
        public static void Run()
        {
            //Creating the two Players and the GameRunner.

            Player player1 = new Player("player1");
            Player player2 = new Player("player2");
            List<Player> playersList = new List<Player>();
            playersList.Add(player1);
            playersList.Add(player2);
            GameRunner gameRunner = new GameRunner(playersList);

            ////Equal between two lists with high card, player2 list is better.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Six));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Five));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ace));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Five));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Four));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}

            ////Equal between two lists with pair in each, where player1 pair is better.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ace));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ace));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Five));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Five));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Four));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 has equal lists");
            //}


            ////Equal between two lists with same pair in each, where player1 list is better.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Nine));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Five));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Five));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Four));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 has equal lists");
            //}


            ////Equal between two lists with same pair in each, where both lists are equal.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Five));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Five));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Four));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}


            ////Equal between two lists with two pairs, where player2 list is better because of a higher fifth card.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Six));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}

            ////Equal between two lists with three of a kind, where player1 list is better because it has higher three.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Six));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}

            //Equal between two lists with straight, where player2 list is better because it has higher straight.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Three));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Four));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Five));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Six));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Seven));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Five));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Six));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Seven));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Eight));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}



            ////Equal between two lists with flush, where player1 list is better because it has higher straight.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Jack));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Eight));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Four));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Two));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Seven));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Nine));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Jack));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Three));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}


            ////Equal between two lists with full house, where player1 list is better because it has higher three.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.Two));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Two));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Two));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}


            ////Equal between two lists with full house, where player1 list is better because it has higher two.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Jack));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Jack));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}



            ////Equal between two lists with four of a kind, where player2 list is better because it has higher four.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ace));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ace));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ace));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ace));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Jack));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}



            ////Equal between two lists with four of a kind, where player1 list is better because it has higher Card.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Jack));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}


            ////Equal between two lists with straight flush, where player1 list is better because it has higher straight.
            //List<Card> firstPlayerList = new List<Card>();
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ten));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Jack));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.King));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Queen));
            //firstPlayerList.Add(new Card(eCardType.Clover, eCardValue.Ace));

            //List<Card> secondPlayerList = new List<Card>();
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.King));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Ten));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Nine));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Jack));
            //secondPlayerList.Add(new Card(eCardType.Diamond, eCardValue.Queen));

            //player1.m_FiveBestCardsWhenRoundFinished = firstPlayerList;
            //player2.m_FiveBestCardsWhenRoundFinished = secondPlayerList;
            //player1.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //player2.m_FiveBestCardsWhenRoundFinished = gameRunner.SortListOfFiveCards(player2.m_FiveBestCardsWhenRoundFinished);
            //eScore firstPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player1.m_FiveBestCardsWhenRoundFinished);
            //eScore secondPlayerScore = gameRunner.DetermineScoreOfSortedFiveCards(player2.m_FiveBestCardsWhenRoundFinished);

            //Console.Write("Player1 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player1.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player1.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(firstPlayerScore);
            //Console.WriteLine();

            //Console.Write("Player2 sorted cards: ");

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(string.Format("{0} {1}, ", player2.m_FiveBestCardsWhenRoundFinished[i].m_CardValue, player2.m_FiveBestCardsWhenRoundFinished[i].m_CardType));
            //}

            //Console.WriteLine();
            //Console.WriteLine(secondPlayerScore);
            //Console.WriteLine();

            //int equalBetweenLists = gameRunner.ChooseBetterListBetweenTwoFiveCardsLists(player1.m_FiveBestCardsWhenRoundFinished, player2.m_FiveBestCardsWhenRoundFinished);
            //if (equalBetweenLists == 1)
            //{
            //    Console.WriteLine("player1 has better list");
            //}
            //else if (equalBetweenLists == 2)
            //{
            //    Console.WriteLine("player2 has better list");
            //}
            //else
            //{
            //    Console.WriteLine("player1 and player2 have equal lists");
            //}

            Console.ReadLine();
        }
    }
}
