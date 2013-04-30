using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardToStringTest
    {
        [TestMethod]
        public void ToStringOfFiveClubs()
        {
            Card card = new Card(CardFace.Five, CardSuit.Clubs);
            string result = card.ToString();
            Assert.AreEqual("5♣", result);
        }

        [TestMethod]
        public void ToStringOfTenDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string result = card.ToString();
            Assert.AreEqual("10♦", result);
        }

        [TestMethod]
        public void ToStringOfTwoOfHearts()
        {
            Card card = new Card(CardFace.Two, CardSuit.Hearts);
            string result = card.ToString();
            Assert.AreEqual("2♥", result);
        }

        [TestMethod]
        public void ToStringOfKingOfSpades()
        {
            Card card = new Card(CardFace.King, CardSuit.Spades);
            string result = card.ToString();
            Assert.AreEqual("K♠", result);
        }
    }
}
