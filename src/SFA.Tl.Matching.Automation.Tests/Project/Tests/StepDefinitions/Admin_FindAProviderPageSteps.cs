using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class Admin_FindAProviderPageSteps : BaseTest
    {
        [When(@"I clear the UKPRN search field and press Search")]
        public void WhenIClearTheUKPRNSearchFieldAndPressSearch()
        {
            FindAProviderPage findAProviderPage = new FindAProviderPage(webDriver);
            findAProviderPage.SearchForAProviderUkprnWithNoTextEntered();
        }

        [Then(@"the user will be shown he following message ""(.*)""")]
        public void ThenTheUserWillBeShownHeFollowingMessage(string errorMessage)
        {
            FindAProviderPage findAProviderPage = new FindAProviderPage(webDriver);
            findAProviderPage.VerifyNullSearchErrorMessage(errorMessage);
        }

        [Then(@"the user will be shown the following message for invalid Ukprn ""(.*)""")]
        public void ThenTheUserWillBeShownTheFollowingMessageForInvalidUkprn(string errorMessage)
        {
            FindAProviderPage findAProviderPage = new FindAProviderPage(webDriver);
            findAProviderPage.VerifyInvalidUkprnErrorMessage(errorMessage);
        }

        [When(@"I enter an invalid UKPRN and press Search")]
        public void WhenIEnterAnInvalidUKPRNAndPressSearch()
        {
            FindAProviderPage findAProviderPage = new FindAProviderPage(webDriver);
            findAProviderPage.SearchForAnInvalidUkprn();
        }
    }
}
