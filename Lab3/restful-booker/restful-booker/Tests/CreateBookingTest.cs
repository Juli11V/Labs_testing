using System;
using TechTalk.SpecFlow;
using restful_booker.Models;
using RestSharp;
using NUnit.Framework;
using System.Net;

namespace restful_booker.Tests
{
    [Binding]
    public class CreateBookingTest
    {
        BookingModel bookingModel = new BookingModel();
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private IRestResponse response;

        [Given(@"I input firstname ""([^""]*)""")]
        public void GivenIInputFirstname(string firstname)
        {
            bookingModel.firstname = firstname;
        }

        [Given(@"I input lastname ""([^""]*)""")]
        public void GivenIInputLastname(string lastname)
        {
            bookingModel.lastname = lastname;
        }

        [Given(@"I set a total price at ""([^""]*)""")]
        public void GivenISetATotalPriceAt(int totalprice)
        {
            bookingModel.totalprice = totalprice;
        }

        [Given(@"I mark depositpaid as ""([^""]*)""")]
        public void GivenIMarkDepositpaidAsTrue(bool depositispaid)
        {
            bookingModel.depositpaid = depositispaid;
        }

        [Given(@"I select the booking dates as checkin in ""([^""]*)"" and checkout in ""([^""]*)""")]
        public void GivenISelectTheBookingDatesAsCheckinInAndCheckoutIn(string checkin, string checkout)
        {
            bookingModel.bookingdates.checkin = checkin;
            bookingModel.bookingdates.checkout = checkout;
        }

        [Given(@"I input ""([^""]*)"" in additional needs")]
        public void GivenIInputInAdditionalNeeds(string additionalneeds)
        {
            bookingModel.additionalneeds = additionalneeds;
        }

        [When(@"I send create booking request")]
        public void WhenISendCreateBookingRequest()
        {
            RestRequest request = new RestRequest("booking", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(bookingModel);
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }
            });
            response = client.Execute<BookingModel>(request);
        }

        [Then(@"validate booking is created")]
        public void ThenValidateBookingIsCreated()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
