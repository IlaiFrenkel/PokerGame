using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class GameRunner
    {
        public GameBoard m_GameBoard { get; set; }

        public int m_SmallBlind { get; set; }

        public int m_BigBlind { get; set; }

        public int m_SmallBlindIndex { get; set; }

        public int m_BigBlindIndex { get; set; }

        public int m_CurrentPlayerIndex { get; set; }

        public int m_RaisedAmount { get; set; }

        public GameRunner(List<Player> i_PlayerList)
        {
            this.m_GameBoard = new GameBoard(i_PlayerList);
            m_SmallBlind = 5;
            m_BigBlind = 10;
            m_SmallBlindIndex = 0;
            m_BigBlindIndex = 1;
            this.StartNewRound();
        }

        public void StartNewRound()
        {
            int cardIndex;
            Random randomCardIndex = new Random();

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
            this.MoveTurnToNextPlayer();

            m_RaisedAmount = m_BigBlind;
        }

        public void MoveTurnToNextPlayer()
        {
            m_CurrentPlayerIndex = (m_BigBlindIndex + 1) % m_GameBoard.m_PlayersList.Count;
        }
    }
}
