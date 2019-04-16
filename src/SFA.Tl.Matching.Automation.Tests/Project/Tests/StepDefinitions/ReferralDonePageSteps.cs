using System;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class ReferralDonePageSteps : BaseTest
    {
        [Given(@"the Referral Done page is displayed")]
        public void GivenTheReferralDonePageIsDisplayed()
        {
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver);
            referralDonePage.VerifyWhatHappensNextText();
        }

        [Given(@"the Opportunity record has recorded the user Opted in")]
        public void GivenTheOpportunityRecordHasRecordedTheUserOptedIn()
        {
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver);
            referralDonePage.VerifyOptInValueRecorded("True");
        }

        [Given(@"the Referral Done page displays the correct text in the What happens next section")]
        public void GivenTheReferralDonePageDisplaysTheCorrectTextInTheWhatHappensNextSection()
        {
           // ScenarioContext.Current.Pending();
        }
    }
}
