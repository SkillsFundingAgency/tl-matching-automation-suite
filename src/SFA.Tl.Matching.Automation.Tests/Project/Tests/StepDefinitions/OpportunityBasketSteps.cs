using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class OpportunityBasketSteps : BaseTest 
    {
        [Given(@"I Continue with Single Opportunity on the Opportunity Basket")]
        public void GivenIContinueWithSingleOpportunityOnTheOpportunityBasket()
        {
            OpportunitiesBasketReferralPage opportunityBasketPage = new OpportunitiesBasketReferralPage(webDriver);
            opportunityBasketPage.VerifyOpportunityDetailsAreDisplayedforOpportunity1();
            opportunityBasketPage.ContinueWithOpportunity();
        }

        [Then(@"referral records are created")]
        public void ThenReferralRecordsAreCreated()
        {
            EmailsSentPage emailsSentPage = new EmailsSentPage(webDriver);
            emailsSentPage.VerifyCountofReferralRecords();
            emailsSentPage.VerifyReferralRecordsCreated();
        }

        [When(@"I Finish the Provision Gap Journey")]
        public void WhenIFinishTheProvisionGapJourney()
        {
            OpportunityBasketProvisionGapPage oppBasketPage = new OpportunityBasketProvisionGapPage(webDriver);
            oppBasketPage.FinishProvisionGapJourney();
        }

        [Then(@"a Provision gap record will be created")]
        public void ThenAProvisionGapRecordWillBeCreated()
        {
            OpportunityBasketProvisionGapPage opportunityBasketPage = new OpportunityBasketProvisionGapPage(webDriver);
            opportunityBasketPage.VerifyProvisionGapRecordCreated();
        }

        //Find out from Mayur what is this step actually doing
        [Then(@"the Opportunity record will record OPT IN has been selected")]
        public void ThenTheOpportunityRecordWillRecordOPTINHasBeenSelected()
        {
            EmailsSentPage emailsSentPage = new EmailsSentPage(webDriver);
            emailsSentPage.VerifyOptInValueRecorded("True");
        }

        //Find out from Mayur what is this step actually doing
        [Then(@"the Opportunity record will record OPT IN has not been selected")]
        public void ThenTheOpportunityRecordWillRecordOPTINHasNotBeenSelected()
        {
            EmailsSentPage emailsSentPage = new EmailsSentPage(webDriver);
            emailsSentPage.VerifyOptInValueRecorded(Constants.ProvisionGapOptInFalse);
        }
    }
}
