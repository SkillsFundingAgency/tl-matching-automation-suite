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
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver).VerifyWhatHappensNextText();
        
        }

        [Given(@"the Referral Done page is displayed with the correct text")]
        [Then(@"the Referral Done page is displayed with the correct text")]
        public void GivenTheReferralDonePageIsDisplayedwithCorrectText()
        {
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver).VerifyWhatHappensNextText();
        }
        
        [Given(@"the Opportunity record has recorded the user Opted in")]
        public void GivenTheOpportunityRecordHasRecordedTheUserOptedIn()
        {
            ReferralDonePage referralDonePage = new ReferralDonePage(webDriver).VerifyOptInValueRecorded("True");
            
        }
    }
}
