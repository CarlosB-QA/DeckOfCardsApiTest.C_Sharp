using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DeckOfCardsApi_Test_CSharp
{
    [TestFixture]
    class DOCA_PositiveTests
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
        public void CreateNewDeck()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            string remaining = (string)jsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("52"));
        }
        [Test]
        public void CreateNewDeckWithJoker()
        {
            myParams = new Dictionary<string, string>();
            myParams.Add("jokers_enabled", "true");
            var jsonData = JObject.Parse(doca.createNewDeck(newResource, myParams));
            string remaining = (string)jsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("54"));
        }
        [Test]
        public void DrawCardsFromDeck()
        {
            var jsonData = JObject.Parse(doca.createNewDeck(newResource));
            deckId = (string)jsonData["deck_id"];
            myParams = new Dictionary<string, string>();
            myParams.Add("count", "2");
            var newJsonData = JObject.Parse(doca.drawCardsFromDeck(drawResource, deckId, myParams));
            string remaining = (string)newJsonData["remaining"];
            Assert.That(remaining, Is.EqualTo("50"));
        }
    }
}
