using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    class HandToStringTest
    {
        [TestMethod]
        public void ToStringOfNoCards()
        {
            Hand hand = new Hand(new List<ICard>());
            string result = hand.ToString();
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void ToStringWithOneCardOfSevenDiamonds()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds) 
            });

            string result = hand.ToString();
            Assert.AreEqual("7♦", result);
        }

        [TestMethod]
        public void ToStringFiveCard()
        {
            Hand hand = new Hand(new List<ICard>()
            {
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades) 
            });

            string result = hand.ToString();
            Assert.AreEqual("7♦ 10♣ 2♥ A♠ 3♠", result);
        }
    }
}


