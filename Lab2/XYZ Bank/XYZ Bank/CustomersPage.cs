using OpenQA.Selenium;

namespace XYZ_Bank
{
    public class CustomersPage : BasePage
    {
        public CustomersPage(IWebDriver webDriver) : base(webDriver){}

        private IWebElement btnFirstName => driver.FindElement(By.XPath("//tr/td[1]"));
        private List<IWebElement> firstNameElements => driver.FindElements(By.XPath("//tr/td[1][@class='ng-binding']")).ToList<IWebElement>();

        public void ClickFirstName() => btnFirstName.Click();
        public List<string> GetFirstNames() => firstNameElements.Select(el => el.Text).ToList<string>();
    }
}
