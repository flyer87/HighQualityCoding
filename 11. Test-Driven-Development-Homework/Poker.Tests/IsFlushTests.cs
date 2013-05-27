using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class IsFlushTests
    {
        [TestMethod]
        public void IsFlushWithFiveSameSuits()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds) 
            });

            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(true, isFlush);
        }

        [TestMethod]
        public void IsFlushWithFiveDifferentSuits()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades) 
            });

            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(false, isFlush);
        }

        [TestMethod]
        public void IsFlushWithFourCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Diamonds),                
            });

            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(false, isFlush);
        }

        [TestMethod]
        public void IsFlushWithNoCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>());

            bool isFlush = checker.IsFlush(hand);
            Assert.AreEqual(false, isFlush);

        }
    }
}
