using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class ErrorMessagesOnTheFindAProviderPageSteps : BaseTest
    {             

        [Given(@"I navigate to the FindProviders page")]
        public void GivenINavigateToTheFindProvidersPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartANewOpportunity();
        }

        [When(@"I clear the Postcode and Search")]
        public void WhenIClearThePostcodeAndSearch()
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.ClearPostcodeAndSearch();
        }

        [Then(@"the Find Providers page will show an error stating ""(.*)""")]
        public void ThenTheFindProvidersPageWillShowAnErrorStating(string postcodeError)
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.VerifyPostcodeError(postcodeError);
        }
    }
}
