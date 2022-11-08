using NUnit.Framework;
using restful_booker.Models;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace restful_booker.Tests
{
    [Binding]
    public class ReadBookingsTest
    {
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private IRestResponse response;

        [When(@"I send read the bookings request")]
        public void WhenISendReadTheBookingsRequest()
        {
            RestRequest request = new RestRequest("booking", Method.GET);
            response = client.Execute<BookingModel>(request);
        }

        [Then(@"the response code should be OK")]
        public void ThenTheResponseCodeShouldBeOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
