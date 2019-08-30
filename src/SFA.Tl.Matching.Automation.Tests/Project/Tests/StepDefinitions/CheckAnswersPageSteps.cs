using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class CreateAProvisionGapRecordSteps : BaseTest
    {
        [Then(@"the providers selected will be displayed on the Referral Check Answers screen")]
        public void ThenTheProvidersSelectedWillBeDisplayedOnTheReferralCheckAnswersScreen()
        {
            ReferralCheckAnswersPage referralCheckAnswersPage = new ReferralCheckAnswersPage(webDriver);
            referralCheckAnswersPage.VerifyProvidersAreDisplayed();
        }

        [Then(@"the referral Check answers screen will display the referral details entered")]
        public void ThenTheReferralCheckAnswersScreenWillDisplayTheReferralDetailsEntered()
        {
            ReferralCheckAnswersPage referralCheckAnswersPage = new ReferralCheckAnswersPage(webDriver);
            referralCheckAnswersPage.VerifyEmployersAnswers();
            referralCheckAnswersPage.VerifyProvidersAreDisplayed();
        }

        [Given(@"I Confirm details on the Check answers page")]
        public void GivenIConfirmDetailsOnTheCheckAnswersPage()
        {
            ReferralCheckAnswersPage referralCheckAnswersPage = new ReferralCheckAnswersPage(webDriver);
            referralCheckAnswersPage.ConfirmAndSendOpportunity();
        }
    }
}
