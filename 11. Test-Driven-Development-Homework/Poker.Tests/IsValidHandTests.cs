using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class IsValidHandTests
    {
        [TestMethod]
        public void IsValidHandWithFiveSameCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            });

            bool isValid = checker.IsValidHand(hand);
            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        public void IsValidHandWithFiveDifferentCards()
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

            bool isValid = checker.IsValidHand(hand);
            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void IsValidHandWithFourCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {                
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades) 
            });

            bool isValid = checker.IsValidHand(hand);
            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        public void IsValidHandWithNoCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            Hand hand = new Hand(new List<ICard>());

            bool isValid = checker.IsValidHand(hand);
            Assert.AreEqual(false, isValid);
        }
    }
}
