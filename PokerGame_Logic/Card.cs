using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public class Card
    {
        public eCardType m_CardType { get; }

        public eCardValue m_CardValue { get; }

        public Card(eCardType i_CardType, eCardValue i_CardValue)
        {
            m_CardType = i_CardType;
            m_CardValue = i_CardValue;
        }
    }

    public enum eCardType
    {
        Heart,
        Leaf,
        Clover,
        Diamond
    }

    public enum eCardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }
}
