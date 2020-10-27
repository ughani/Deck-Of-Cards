using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace DeckOfCardsTest
{
    public class Tests
    {
        RestClient client;
        [SetUp]
        public void Setup()
        {
          

            client = new RestClient("https://deckofcardsapi.com/");
            //client.Authenticator = new HttpBasicAuthenticator("username", "password");
        
        }

        [Test]
        public void Test1()
        {
            var request = new RestRequest("api/deck/new/shuffle/?deck_count=1");

            var response = client.Get(request);
            JObject jo = JObject.Parse(response.Content);
            
            Assert.AreEqual(jo["success"].Value<bool>(),true);
         
        }
    }
}