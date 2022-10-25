using OpenQA.Selenium;

namespace XYZ_Bank
{
    public class BasePage
    {
        protected static IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
        }
    }
}