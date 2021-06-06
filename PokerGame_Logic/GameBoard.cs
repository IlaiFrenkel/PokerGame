using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class GameBoard
    {
        public List<Card> m_DeckList { get; set; }

        public List<Card> m_OpenCardsList { get; set; }

        public List<Player> m_PlayersList { get; set; }

        public int m_MoneyOnBoard { get; set; }

        public GameBoard(List<Player> i_PlayersList)
        {
            m_DeckList = new List<Card>();
            m_OpenCardsList = new List<Card>();
            m_PlayersList = i_PlayersList;
            initDeck();
            initPlayersMoney();
            m_MoneyOnBoard = 0;
        }

        public void initDeck()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    m_DeckList.Add(new Card((eCardType)i, (eCardValue)j));
                }
            }
        }

        private void initPlayersMoney()
        {
            foreach (Player player in this.m_PlayersList)
            {
                player.m_Money = 400;
            }
        }

        public void RemovePlayersHandsWhenRoundFinished()
        {
            foreach (Player player in m_PlayersList)
            {
                player.m_Hand = new List<Card>();
            }
        }
    }
}
