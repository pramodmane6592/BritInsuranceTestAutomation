using BritInsuranceTestAutomation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BritInsuranceTestAutomation.Pages
{
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
        }

        private IWebElement BtnSearch => _driver.FindElement(By.CssSelector("button[aria-label='Search button']"));

        private IWebElement TxtSearch => _driver.FindElement(By.CssSelector("input[type='search']"));

        private IReadOnlyCollection<IWebElement> Headers => _driver.FindElements(By.XPath("//div[@class='s-results']/a"));

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public void SearchText(string value)
        {
            _driver.WaitForElementToBeClickable(BtnSearch,30);
            BtnSearch.Click();
            
            TxtSearch.SendKeys(value);

            _driver.WaitForElementToBeClickable(BtnSearch, 30);
            BtnSearch.Click();
        }

        public int GetResultCount()
        {
            return Headers.Count();
        }

        public bool ValidateSerachResult(IList<string> expectedHeaders)
        {
            IList<string> actualHeaders = new List<string>();

            foreach (var element in Headers)
            {
                actualHeaders.Add(element.Text.Trim());
            }

            return actualHeaders.SequenceEqual(expectedHeaders);                        
        }
    }
}
