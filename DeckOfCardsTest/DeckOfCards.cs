using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace DeckOfCardsTest
{
    class DeckOfCards
    {
        private RestClient client;
        public DeckOfCards()
        {
            client = new RestClient("https://deckofcardsapi.com/");
        }

        public string CreateDeck(bool joker)
        {
          
            var request = new RestRequest($"/api/deck/new?jokers_enabled={joker}");

            var response =  client.Get(request);
            JObject jo = JObject.Parse(response.Content);

            return jo["deck_id"].Value<string>();
        }
        public JObject DrawCard(string id, int count)
        {
         
            var request = new RestRequest($"/api/deck/{id}/draw?count={count}");

            var response = client.Post(request);
            JObject jo = JObject.Parse(response.Content);

            return jo;
        }

    }


}
