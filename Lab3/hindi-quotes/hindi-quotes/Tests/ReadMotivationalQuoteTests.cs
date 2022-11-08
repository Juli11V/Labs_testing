using hindi_quotes.Models;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace kanye_rest.Tests
{
    [Binding]
    public class ReadMotivationalQuoteTests
    {
        private RestClient client = new RestClient(" https://hindi-quotes.vercel.app/");
        private IRestResponse<QuoteModel> response;
        private string quoteType;

        [Given(@"I input a motivational type of quote")]
        public void GivenIInputAMotivationalTypeOfQuote()
        {
            quoteType = "motivational";
        }

        [When(@"I send a read quote request")]
        public void WhenISendAReadQuoteRequest()
        {
            RestRequest request = new RestRequest($"random/{quoteType}", Method.GET);
            response = client.Execute<QuoteModel>(request);
        }

        [Then(@"The the type of recieved quote should be motivational")]
        public void ThenTheTheTypeOfRecievedQuoteShouldBeMotivational()
        {
            Assert.That(response.Data.type, Is.EqualTo(quoteType));
        }
    }
}
