using NUnit.Framework;
using TechTalk.SpecFlow;
using XYZ_Bank;

namespace Tests.Steps
{
    [Binding]
    public class CustomersStepDefinitions : BaseSteps
    {
        private CustomersPage customersPage;
        List<string> actualFirstNames = new List<string>();
        List<string> expectedFirstNames = new List<string>();

        [When(@"I click on the First Name header")]
        public void WhenIClickOnTheFirstNameHeader()
        {
            customersPage = new CustomersPage(driver);
            Thread.Sleep(1000);
            expectedFirstNames = customersPage.GetFirstNames();
            expectedFirstNames.Sort((a, b) => b.CompareTo(a));
            customersPage.ClickFirstName();
            Thread.Sleep(1000);
            actualFirstNames = customersPage.GetFirstNames();
            Thread.Sleep(1000);
        }

        [Then(@"I should see customer records sorted in descending order")]
        public void ThenIShouldSeeCustomerRecordsSortedInDescendingOrder()
        {
            Assert.AreEqual(actualFirstNames, expectedFirstNames);
        }
    }
}
