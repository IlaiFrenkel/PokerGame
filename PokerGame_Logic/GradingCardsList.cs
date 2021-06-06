using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerGame_Logic
{
    public static class GradingCardsList
    {
        public static bool IsSortedListContainsStraightFlush(List<Card> i_CardsList)
        {
            if (IsSortedListContainsStraight(i_CardsList) && IsSortedListContainsFlush(i_CardsList))
            {
                return true;
            }

            return false;
        }

        public static bool IsSortedListContainsFour(List<Card> i_CardsList)
        {
            int counter = 1;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue)
                {
                    counter++;

                    if (counter == 4)
                    {
                        return true;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            return counter == 4;
        }

        public static bool IsSortedListContainsFullHouse(List<Card> i_CardsList)
        {
            if ((i_CardsList[0].m_CardValue == i_CardsList[1].m_CardValue) && (i_CardsList[1].m_CardValue == i_CardsList[2].m_CardValue) && (i_CardsList[3].m_CardValue == i_CardsList[4].m_CardValue))
            {
                return true;
            }

            if ((i_CardsList[0].m_CardValue == i_CardsList[1].m_CardValue) && (i_CardsList[2].m_CardValue == i_CardsList[3].m_CardValue) && (i_CardsList[3].m_CardValue == i_CardsList[4].m_CardValue))
            {
                return true;
            }

            return false;
        }

        public static bool IsSortedListContainsFlush(List<Card> i_CardsList)
        {
            eCardType firstCardType = i_CardsList[0].m_CardType;

            for (int i = 1; i < i_CardsList.Count; i++)
            {
                if (i_CardsList[i].m_CardType != firstCardType)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsSortedListContainsStraight(List<Card> i_CardsList)
        {
            bool isStraight = true;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (((int)i_CardsList[i].m_CardValue + 1) != ((int)i_CardsList[i + 1].m_CardValue))
                {
                    isStraight = false;

                    if ((i == 0) && ((i_CardsList[i_CardsList.Count - 1].m_CardValue == eCardValue.King) && i_CardsList[0].m_CardValue == eCardValue.Ace))
                    {
                        isStraight = true;
                    }
                }
            }

            return isStraight;
        }

        public static bool IsSortedListContainsThree(List<Card> i_CardsList)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue && i_CardsList[i + 1].m_CardValue == i_CardsList[i + 2].m_CardValue)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsSortedListContainsTwoPairs(List<Card> i_CardsList)
        {
            int pairsCounter = 0;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue)
                {
                    pairsCounter++;
                    i++;
                }
            }

            return pairsCounter == 2;
        }

        public static bool IsSortedListContainsOnePair(List<Card> i_CardsList)
        {
            int pairsCounter = 0;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue)
                {
                    pairsCounter++;
                    i++;
                }
            }

            return pairsCounter == 1;
        }

        // Looks on Ace value as 13.
        // Returns 1 if the first Card Value is Bigger, 2 if the second is and 3 if they are equal.
        private static int equalBetweenTwoCardsValues(eCardValue i_FirstCardValue, eCardValue i_SecondCardValue)
        {
            if (i_FirstCardValue == eCardValue.Ace && i_SecondCardValue != eCardValue.Ace)
            {
                return 1;
            }

            if (i_SecondCardValue == eCardValue.Ace && i_FirstCardValue != eCardValue.Ace)
            {
                return 2;
            }

            if (i_FirstCardValue > i_SecondCardValue)
            {
                return 1;
            }

            if (i_SecondCardValue > i_FirstCardValue)
            {
                return 2;
            }

            return 3;
        }

        public static int ChooseBetweenTwoSortedListsWithHighCard(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            if (i_FirstList[0].m_CardValue == eCardValue.Ace && i_SecondList[0].m_CardValue != eCardValue.Ace)
            {
                return 1;
            }

            if (i_SecondList[0].m_CardValue == eCardValue.Ace && i_FirstList[0].m_CardValue != eCardValue.Ace)
            {
                return 2;
            }

            for (int i = i_FirstList.Count - 1; i >= 0; i--)
            {
                if (i_FirstList[i].m_CardValue > i_SecondList[i].m_CardValue)
                {
                    return 1;
                }
                else if (i_SecondList[i].m_CardValue > i_FirstList[i].m_CardValue)
                {
                    return 2;
                }
            }

            return 3;
        }

        public static int ChooseBetweenTwoSortedListsWithOnePair(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            eCardValue firstListPairValue = findPairValue(i_FirstList);
            eCardValue secondListPairValue = findPairValue(i_SecondList);

            if (equalBetweenTwoCardsValues(firstListPairValue, secondListPairValue) == 1)
            {
                return 1;
            }

            if (equalBetweenTwoCardsValues(firstListPairValue, secondListPairValue) == 2)
            {
                return 2;
            }

            List<Card> firstListWithoutPair = removePairFromCardsListWithOnePair(i_FirstList);
            List<Card> secondListWithoutPair = removePairFromCardsListWithOnePair(i_SecondList);

            return ChooseBetweenTwoSortedListsWithHighCard(firstListWithoutPair, secondListWithoutPair);
        }

        private static List<Card> removePairFromCardsListWithOnePair(List<Card> i_CardsList)
        {
            List<Card> newCardsList = new List<Card>();

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue != i_CardsList[i + 1].m_CardValue)
                {
                    newCardsList.Add(i_CardsList[i]);
                }
                else
                {
                    i++;
                }
            }

            if (i_CardsList[i_CardsList.Count - 2].m_CardValue != i_CardsList[i_CardsList.Count - 1].m_CardValue)
            {
                newCardsList.Add(i_CardsList[i_CardsList.Count - 1]);
            }

            return newCardsList;
        }

        private static eCardValue findPairValue(List<Card> i_CardsList)
        {
            eCardValue pairValue = eCardValue.Ace;

            for (int i = 0; i  < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue)
                {
                    pairValue = i_CardsList[i].m_CardValue;
                }
            }

            return pairValue;
        }

        public static int ChooseBetweenTwoSortedListsWithTwoPairs(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            eCardValue[] firstListPairsValues = findTwoPairsValues(i_FirstList);
            eCardValue[] secondListPairsValues = findTwoPairsValues(i_SecondList);

            if (firstListPairsValues[0] == eCardValue.Ace && secondListPairsValues[0] != eCardValue.Ace)
            {
                return 1;
            }

            if (secondListPairsValues[0] == eCardValue.Ace && firstListPairsValues[0] != eCardValue.Ace)
            {
                return 2;
            }

            for (int i = 1; i >= 0; i--)
            {
                if (firstListPairsValues[i] > secondListPairsValues[i])
                {
                    return 1;
                }
                else if (secondListPairsValues[i] > firstListPairsValues[i])
                {
                    return 2;
                }
            }

            eCardValue firstListFifthCardValue = findValOfOnlyNonPairCardInListWithTwoPairs(i_FirstList, firstListPairsValues);
            eCardValue secondListFifthCardValue = findValOfOnlyNonPairCardInListWithTwoPairs(i_SecondList, secondListPairsValues);

            return equalBetweenTwoCardsValues(firstListFifthCardValue, secondListFifthCardValue);
        }

        private static eCardValue findValOfOnlyNonPairCardInListWithTwoPairs(List<Card> i_CardsList, eCardValue[] i_ListPairsValues)
        {
            eCardValue fifthCardValue = eCardValue.Ace;

            for (int i = 0; i < i_CardsList.Count; i++)
            {
                if (i_CardsList[i].m_CardValue != i_ListPairsValues[0] && i_CardsList[i].m_CardValue != i_ListPairsValues[1])
                {
                    fifthCardValue = i_CardsList[i].m_CardValue;
                }
            }

            return fifthCardValue;
        }

        // Returns arr of size 2 in which the first element is the eCardValue of the lower value pair,
        // and the second element is the eCardValue of the higher value pair.
        private static eCardValue[] findTwoPairsValues(List<Card> i_CardsList)
        {
            eCardValue[] values = new eCardValue[2];
            int valuesIndex = 0;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue)
                {
                    values[valuesIndex] = i_CardsList[i].m_CardValue;
                    valuesIndex++;
                }
            }

            return values;
        }

        public static int ChooseBetweenTwoSortedListsWithThreeOfAKind(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            eCardValue firstListThreeCardsValue = determineValueOfThreeInList(i_FirstList);
            eCardValue secondListThreeCardsValue = determineValueOfThreeInList(i_SecondList);

            if (equalBetweenTwoCardsValues(firstListThreeCardsValue, secondListThreeCardsValue) == 1)
            {
                return 1;
            }

            if (equalBetweenTwoCardsValues(firstListThreeCardsValue, secondListThreeCardsValue) == 2)
            {
                return 2;
            }

            eCardValue[] firstListTwoFreeCards = findValuesOfTwoFreeCards(i_FirstList, firstListThreeCardsValue);
            eCardValue[] secondListTwoFreeCards = findValuesOfTwoFreeCards(i_SecondList, secondListThreeCardsValue);

            if (firstListTwoFreeCards[0] == eCardValue.Ace && secondListTwoFreeCards[0] != eCardValue.Ace)
            {
                return 1;
            }

            if (secondListTwoFreeCards[0] == eCardValue.Ace && firstListTwoFreeCards[0] != eCardValue.Ace)
            {
                return 2;
            }

            for (int i = 1; i >= 0; i--)
            {
                if (firstListTwoFreeCards[i] > secondListTwoFreeCards[i])
                {
                    return 1;
                }
                else if (secondListTwoFreeCards[0] > firstListTwoFreeCards[1])
                {
                    return 2;
                }
            }

            return 3;
        }

        // Returns an arr of size 2 with the two values of the cards which are free - not in the Three.
        private static eCardValue[] findValuesOfTwoFreeCards(List<Card> i_CardsList, eCardValue i_ThreeCardsValue)
        {
            eCardValue[] freeCardsValuesList = new eCardValue[2];
            int freeCardIndex = 0;

            for (int i = 0; i < i_CardsList.Count; i++)
            {
                if (i_CardsList[i].m_CardValue != i_ThreeCardsValue)
                {
                    freeCardsValuesList[freeCardIndex] = i_CardsList[i].m_CardValue;
                    freeCardIndex++;
                }
            }

            return freeCardsValuesList;
        }

        private static eCardValue determineValueOfThreeInList(List<Card> i_CardsList)
        {
            eCardValue value = eCardValue.Ace;

            for (int i = 0; i < i_CardsList.Count - 1; i++)
            {
                if (i_CardsList[i].m_CardValue == i_CardsList[i + 1].m_CardValue)
                {
                    value = i_CardsList[i].m_CardValue;
                }
            }

            return value;
        }

        public static int ChooseBetweenTwoSortedListsWithStraight(List<Card> i_FirstList, List<Card> i_SecondList)
        {
           return equalBetweenTwoCardsValues(i_FirstList[0].m_CardValue, i_SecondList[0].m_CardValue);
        }

        public static int ChooseBetweenTwoSortedListsWithFlush(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            if (i_FirstList[0].m_CardValue == eCardValue.Ace && i_SecondList[0].m_CardValue != eCardValue.Ace)
            {
                return 1;
            }

            if (i_SecondList[0].m_CardValue == eCardValue.Ace && i_FirstList[0].m_CardValue != eCardValue.Ace)
            {
                return 2;
            }

            return equalBetweenTwoCardsValues(i_FirstList[i_FirstList.Count - 1].m_CardValue, i_SecondList[i_SecondList.Count - 1].m_CardValue);
        }

        public static int ChooseBetweenTwoSortedListsWithFullHouse(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            eCardValue[] firstListValues = findValuesOfPairAndThreeInFullHouseList(i_FirstList);
            eCardValue[] secondListValues = findValuesOfPairAndThreeInFullHouseList(i_SecondList);

            int equalValue = equalBetweenTwoCardsValues(firstListValues[0], secondListValues[0]);

            if (equalValue == 1)
            {
                return 1;
            }

            if (equalValue == 2)
            {
                return 2;
            }

            return equalBetweenTwoCardsValues(firstListValues[1], secondListValues[1]);
        }

        // Returns an arr of size 2 in which the first element is the value of the Three cards and the second is the value of the pair.
        private static eCardValue[] findValuesOfPairAndThreeInFullHouseList(List<Card> i_CardsList)
        {
            eCardValue[] valuesOfTheThreeCardsAndThePair = new eCardValue[2];

            if (i_CardsList[0].m_CardValue == i_CardsList[1].m_CardValue && i_CardsList[1].m_CardValue == i_CardsList[2].m_CardValue)
            {
                valuesOfTheThreeCardsAndThePair[0] = i_CardsList[0].m_CardValue;
                valuesOfTheThreeCardsAndThePair[1] = i_CardsList[3].m_CardValue;
            }
            else
            {
                valuesOfTheThreeCardsAndThePair[0] = i_CardsList[3].m_CardValue;
                valuesOfTheThreeCardsAndThePair[1] = i_CardsList[0].m_CardValue;
            }

            return valuesOfTheThreeCardsAndThePair;
        }

        public static int ChooseBetweenTwoSortedListsWithFourOfAKind(List<Card> i_FirstList, List<Card> i_SecondList)
        {
            eCardValue firstListFourCardsValue = findValueOfTheFourCardsInListWithFourOfAKind(i_FirstList);
            eCardValue secondListFourCardsValue = findValueOfTheFourCardsInListWithFourOfAKind(i_SecondList);

            int equalValue = equalBetweenTwoCardsValues(firstListFourCardsValue, secondListFourCardsValue);

            if (equalValue == 1)
            {
                return 1;
            }

            if (equalValue == 2)
            {
                return 2;
            }

            return equalBetweenTwoCardsValues(findValueOfTheFreeCardInListWithFourOfAKind(i_FirstList), findValueOfTheFreeCardInListWithFourOfAKind(i_SecondList));
        }

        private static eCardValue findValueOfTheFourCardsInListWithFourOfAKind(List<Card> i_CardsList)
        {
            if (i_CardsList[0].m_CardValue == i_CardsList[1].m_CardValue)
            {
                return i_CardsList[0].m_CardValue;
            }
            else
            {
                return i_CardsList[i_CardsList.Count - 1].m_CardValue;
            }
        }

        private static eCardValue findValueOfTheFreeCardInListWithFourOfAKind(List<Card> i_CardsList)
        {
            if (i_CardsList[0].m_CardValue == i_CardsList[1].m_CardValue)
            {
                return i_CardsList[i_CardsList.Count - 1].m_CardValue;
            }
            else
            {
                return i_CardsList[0].m_CardValue;
            }
        }

        public static int ChooseBetweenTwoSortedListsWithStraightFlush(List<Card> i_FirstList, List<Card> i_SecondList)
        {
           return ChooseBetweenTwoSortedListsWithStraight(i_FirstList, i_SecondList);
        }
    }
}
