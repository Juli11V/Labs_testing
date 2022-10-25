using TechTalk.SpecFlow;
using XYZ_Bank;

namespace Tests.Steps
{
    [Binding]
    public class LoginStepDefinitions : BaseSteps
    {
        private LoginPage loginPage;

        [Given(@"I launch the application")]
        public void GivenILaunchTheApplication()
        {
            loginPage = new LoginPage(driver);
            Thread.Sleep(1000);
        }

        [Given(@"I click on the Bank Manager Login link")]
        public void GivenIClickOnTheBankManagerLoginLink()
        {
            loginPage.ClickLogin();
        }
    }
}
