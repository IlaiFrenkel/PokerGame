using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class Player
    {
        public string m_Name;

        public List<Card> m_Hand;

        public List<Card> m_FiveBestCardsWhenRoundFinished;

        public int m_Money;

        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Money = 0;
            m_Hand = new List<Card>();
            m_FiveBestCardsWhenRoundFinished = new List<Card>();
        }
    }
}
