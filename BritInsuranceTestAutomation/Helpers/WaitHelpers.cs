using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BritInsuranceTestAutomation.Helpers
{
    public static class WaitHelpers
    {
        public static void ImplicitWait(this IWebDriver driver, int secondsToWait)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsToWait);
        }

        public static void WaitForElementToBeClickable(this IWebDriver driver, IWebElement element, int secondsToWait)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(secondsToWait));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ObjectDisposedException), typeof(TimeoutException));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void WaitForPageLoad(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, 10);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            LoopingWait(obj, timeOut, execute, stopWatch);

            static void LoopingWait<T>(T obj, int timeOut, Func<T, bool> execute, Stopwatch stopWatch)
            {
                while (stopWatch.ElapsedMilliseconds < timeOut)
                {
                    if (execute(obj))
                    {
                        break;
                    }
                }
            }
        }
    }
}
