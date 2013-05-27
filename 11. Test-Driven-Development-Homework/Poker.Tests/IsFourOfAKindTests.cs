using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class IsFourOfAKindTests
    {
        [TestMethod]
        public void IsFourOfAKindWithFourDifferentFaces()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)                
            });

            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(false, isFourOfAKind);
        }

        [TestMethod]
        public void IsFourOfAKindWithFourSameFaces()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)                
            });

            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(true, isFourOfAKind);
        }

        [TestMethod]
        public void IsFourOfAKindWithThreeSameFaces()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts)                
            });

            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(false, isFourOfAKind);
        }

        [TestMethod]
        public void IsFourOfAKindWithFourCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)                
            });

            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(false, isFourOfAKind);
        }

        [TestMethod]
        public void IsFourOfAKindWithNoCards()
        {
            PokerHandsChecker checker = new PokerHandsChecker();

            Hand hand = new Hand(new List<ICard>());

            bool isFourOfAKind = checker.IsFourOfAKind(hand);
            Assert.AreEqual(false, isFourOfAKind);
        }
    }
}
