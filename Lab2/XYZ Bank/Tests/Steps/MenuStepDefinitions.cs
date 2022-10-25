using TechTalk.SpecFlow;
using XYZ_Bank;

namespace Tests.Steps
{
    [Binding]
    public class MenuStepDefinitions : BaseSteps
    {
        private MenuPage menuPage;

        [Given(@"I click on the Customers menu item")]
        public void GivenIClickOnTheCustomersMenuItem()
        {
            menuPage = new MenuPage(driver);
            Thread.Sleep(1000);
            menuPage.ClickCustomers();
        }
    }
}
