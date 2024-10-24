using BritInsuranceTestAutomation.Base;
using BritInsuranceTestAutomation.Helpers;
using BritInsuranceTestAutomation.Pages;
namespace BritInsuranceTestAutomation.UITests;

public class HomePageTests : BaseTest
{
    [Test]
    public void SearchBoxTest()
    {
        try
        {
            HomePage objHomepage = new HomePage(Driver);
            List<string> expectedValues = new List<string> { "Financials", "Interim results for the six months ended 30 June 2022", "Results for the year ended 31 December 2023", "Interim Report 2023", "Kirstin Simon", "Gavin Wilkinson", "Simon Lee", "John King" };

            Driver.Navigate().GoToUrl("https://www.britinsurance.com/");

            Driver.WaitForPageLoad();
            Driver.ImplicitWait(10);
            Assert.That(objHomepage.GetPageTitle(), Is.EqualTo("Brit Insurance | Writing the Future"), "Validate user is landed on Brit Insurance Home Page");
            objHomepage.SearchText("IFRS 17");

            Assert.Multiple(() =>
            {
                Assert.That(objHomepage.GetResultCount(), Is.EqualTo(8), "Search 'IFRS 17' in Search Box and Validate 8 Records Returned");
                Assert.That(objHomepage.ValidateSerachResult(expectedValues), Is.True, "Validate the actual result headers are matching with expected headers.");
            });
        }
        catch (Exception ex)
        {
            Assert.Fail("Error occured while search specfic text on home page:", ex.Message);
        }
    }
}
