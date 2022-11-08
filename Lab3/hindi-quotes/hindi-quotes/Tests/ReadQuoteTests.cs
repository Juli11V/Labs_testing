using RestSharp;
using System;
using TechTalk.SpecFlow;
using hindi_quotes.Models;
using NUnit.Framework;
using System.Net;

namespace hindi_quotes.Tests
{
    [Binding]
    public class ReadQuoteTests
    {
        private RestClient client = new RestClient(" https://hindi-quotes.vercel.app/");
        private IRestResponse<QuoteModel> response;

        [When(@"I send a read random quote request")]
        public void WhenISendAReadQuoteRequest()
        {
            RestRequest request = new RestRequest("/random", Method.GET);
            response = client.Execute<QuoteModel>(request);
        }
        
        [Then(@"The response status code should be OK")]
        public void ThenTheResponseStatusCodeShouldBeOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
