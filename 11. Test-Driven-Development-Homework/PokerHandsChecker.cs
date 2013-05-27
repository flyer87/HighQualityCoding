using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            IList<ICard> cards = hand.Cards;

            if (cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Face == cards[i + 1].Face)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            IList<ICard> cards = hand.Cards;

            if (cards.Count != 5)
            {
                return false;
            }

            Dictionary<string, int> cardFaces = CountOfDifferentFaces(hand);
            if (cardFaces.Count > 2)
            {
                return false;
            }
            else
            {
                int maxValue = cardFaces.Max(x => x.Value);
                if (maxValue != 4)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            IList<ICard> cards = hand.Cards;

            if (cards.Count != 5)
            {
                return false;
            }                       

            for (int i = 0; i < cards.Count - 1; i++)
            {
                if (cards[i].Suit != cards[i + 1].Suit)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, int> CountOfDifferentFaces(IHand hand)
        {
            Dictionary<string, int> cardFaces = new Dictionary<string, int>();

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                CardFace face = hand.Cards[i].Face;
                if (cardFaces.ContainsKey(face.ToString()))
                {
                    cardFaces[face.ToString()]++;
                }
                else
                {
                    cardFaces.Add(face.ToString(), 1);
                }
            }

            return cardFaces;
        }

    }
}
