using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BritInsuranceTestAutomation.Base
{
    public class BaseTest
    {
        public IWebDriver Driver;


        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }
    }
}
