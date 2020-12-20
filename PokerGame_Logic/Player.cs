using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class Player
    {
        public string m_Name { get; }

        public List<Card> m_Hand { get; set; }

        public int m_Money { get; set; }

        public Player(string i_Name)
        {
            m_Name = i_Name;
            m_Money = 0;
            m_Hand = new List<Card>();
        }
    }
}
