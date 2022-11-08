using NUnit.Framework;
using restful_booker.Models;
using RestSharp;
using System;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace restful_booker.Tests
{
    [Binding]
    public class DeleteBookingTests
    {

        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private IRestResponse<BookingModel> response;
        private string token;
        private int bookingid;

        private void GetToken()
        {
            RestRequest request = new RestRequest("auth", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/json" }
            });
            request.AddBody(new Dictionary<string, string> {
                { "username", "admin" },
                { "password", "password123" }
            });

            token = JsonSerializer.Deserialize<TokenModel>(client.Execute(request).Content).token;
            bookingid = JsonSerializer.Deserialize<List<BookingIdModel>>(client.Execute(new RestRequest("booking?firstname=Jim", Method.GET)).Content)[0].bookingid;
        }

        [When(@"I call a delete request for the record")]
        public void WhenICallADeleteRequestForTheRecord()
        {
            GetToken();
            RestRequest request = new RestRequest($"booking/{bookingid}", Method.DELETE);
            request.AddHeaders(new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Cookie", $"token={token}"  }
            });
            response = client.Execute<BookingModel>(request);
        }

        [Then(@"I check whether the record is deleted")]
        public void ThenICheckWhetherTheRecordIsDeleted()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
