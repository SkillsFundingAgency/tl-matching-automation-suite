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
        public ReferralDonePage GivenTheReferralDonePageIsDisplayed()
        {
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver).VerifyWhatHappensNextText();
            return referralDonePage;
        }

        [Given(@"the Opportunity record has recorded the user Opted in")]
        public ReferralDonePage GivenTheOpportunityRecordHasRecordedTheUserOptedIn()
        {
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver).VerifyOptInValueRecorded("True");
            return referralDonePage;
        }

        [Given(@"the Referral Done page displays the correct text in the What happens next section")]
        public void GivenTheReferralDonePageDisplaysTheCorrectTextInTheWhatHappensNextSection()
        {
           // ScenarioContext.Current.Pending();
        }
    }
}
