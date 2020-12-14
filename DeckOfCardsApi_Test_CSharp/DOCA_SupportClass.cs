using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCardsApi_Test_CSharp
{
    class DOCA_SupportClass
    {
        protected string baseUri;

        public DOCA_SupportClass(String baseUri)
        {
            this.baseUri = baseUri;
        }
        public string createNewDeck(string resource)
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(baseUri + resource);
            IRestResponse restResponse = restClient.Get(restRequest);
            return restResponse.Content;
        }
        public string createNewDeck(string resource, Dictionary<string, string> myParams)
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(baseUri + resource);
            foreach (var key in myParams.Keys)
            {
                restRequest.AddParameter(key, myParams[key]);
            }
            IRestResponse restResponse = restClient.Get(restRequest);
            return restResponse.Content;
        }
        public string drawCardsFromDeck(string resource, string deckId, Dictionary<string, string> myParams)
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(baseUri + deckId + resource);
            foreach (var key in myParams.Keys)
            {
                restRequest.AddParameter(key, myParams[key]);
            }
            IRestResponse restResponse = restClient.Get(restRequest);
            return restResponse.Content;
        }
    }
}
