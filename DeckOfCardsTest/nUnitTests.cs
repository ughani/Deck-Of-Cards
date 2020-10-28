using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCardsTest
{
    public class Tests
    {
        private DeckOfCards dc;
        [SetUp]
        public void Setup()
        {

            dc = new DeckOfCards();
        }

        [Test]
        public void TestCardsRemaining()
        {
            var deckid = dc.CreateDeck(false);

            var cards = dc.DrawCard(deckid, 1);

            Assert.AreEqual("51", cards["remaining"].Value<string>(), "Remaining cards don't match actual");
         
        }

        [Test]
        public void TestCreateDeckWithoutJoker()
        {
            var deckid = dc.CreateDeck(false);

            var cards = dc.DrawCard(deckid, 0);

            Assert.AreEqual("52", cards["remaining"].Value<string>(), "If Joker are not included then total cards should be 52");
   
        }
        [Test]
        public void TestCreateDeckWithJoker()
        {
            var deckid = dc.CreateDeck(true);

            var cards = dc.DrawCard(deckid, 0);

            Assert.AreEqual("54", cards["remaining"].Value<string>(), "If Joker is included then total cards should be 54");

        }

        [Test]
        public void TestCardsSuit()
        {
            var deckid = dc.CreateDeck(false);
            var expectedSuits = new List<string> { "SPADES", "DIAMONDS", "CLUBS", "HEARTS"};
            var cards = dc.DrawCard(deckid, 20);     
            JArray arrCards = (JArray)cards["cards"];
            IList<string> lisCards  = arrCards.Select(c => c["suit"].Value<string>()).ToList();
            Assert.IsTrue(lisCards.All(x=>expectedSuits.Contains(x)));
           

        }
    }
}