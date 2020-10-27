using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using RestSharp;
namespace DeckOfCardsTest
{
    class DeckOfCards
    {
        RestClient client;
        public DeckOfCards()
        {
            client = new RestClient("https://deckofcardsapi.com/");
        }

        public string CreateDeck(bool joker)
        {
            //var url = joker ? "api/deck/new/{}" : "api/deck/new";
            
            var request = new RestRequest($"api/deck/new/jokers_enabled={joker}");

            var response =  client.Post(request);
            JObject jo = JObject.Parse(response.Content);

            return jo["deck_id"].Value<string>();
        }


    }

    //DeckOfCards dc = new DeckOfCards();
    //var deckid = dc.CreateDeck(bool joker)
    //var card = dc.DrawCard(deckid,count)
}
