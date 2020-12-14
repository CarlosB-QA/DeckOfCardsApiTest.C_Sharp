using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DeckOfCardsApi_Test_CSharp
{
    [TestFixture]
    class DOCA_NegativeTests
    {
        private DOCA_SupportClass doca;
        private Dictionary<String, String> myParams;
        private string newResource = "new/";
        private string drawResource = "/draw/";
        private string deckId;

        [OneTimeSetUp]
        public void Init()
        {
            doca = new DOCA_SupportClass("https://deckofcardsapi.com/api/deck/");
        }
        [Test]
        public void CreateDeckAndDrawZeroCards()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            deckId = (string)jsonData["deck_id"];
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "0");
            var newJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string remaining = (string)newJsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("52"));

        }
        [Test]
        public void CreateDeckAndDrawAllCards()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            deckId = (string)jsonData["deck_id"];
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "52");
            var newJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string remaining = (string)newJsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("0"));
        }
        [Test]
        public void CreateDeckAndOverDraw()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            deckId = (string)jsonData["deck_id"];
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "53");
            var newJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string error = (string)newJsonData["error"];
            Assert.That(error, Is.EqualTo("Not enough cards remaining to draw 53 additional"));

        }
        [Test]
        public void DrawCardsOnEmptyDeck()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            deckId = (string)jsonData["deck_id"];
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "52");
            var myJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string remaining = (string)myJsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("0"));
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "1");
            var newJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string error = (string)newJsonData["error"];
            Assert.That(error, Is.EqualTo("Not enough cards remaining to draw 1 additional"));
        }
        [Test]
        public void InputInvalidCountValue()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            deckId = (string)jsonData["deck_id"];
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "count");
            var newJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string remaining = (string)newJsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("52"));

        }

    }
}
