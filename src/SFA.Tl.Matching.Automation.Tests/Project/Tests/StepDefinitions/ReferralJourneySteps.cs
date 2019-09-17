using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CreateAReferralSteps :BaseTest
    {
        [Given(@"I have added a single opportunity")]
        public void GivenIHaveAddedASingleOpportunity()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterEmployerContactDetailsAndContinueForAReferralJourney(Constants.testName, Constants.testEmail, Constants.testPhoneNumber)
                                    .CheckPlacementInformationFirstPass();
            ReferralCheckAnswersPage referralCheckAnswersPage = new ReferralCheckAnswersPage(webDriver);
            referralCheckAnswersPage.VerifyChosenProvidersAreDisplayedOnCheckAnswersScreen();
            referralCheckAnswersPage.ConfirmAndSendOpportunity();
        }

        [When(@"I start Adding another Opportunity from Opportunity Basket")]
        public void WhenIStartAddingAnotherOpportunityFromOpportunityBasket()
        {
            OpportunitiesBasketReferralPage opportunitiesBasketPage = new OpportunitiesBasketReferralPage(webDriver);
            opportunitiesBasketPage.VerifyOpportunityDetailsAreDisplayedforOpportunity1();
            opportunitiesBasketPage.VerifyLatestReferralRecordValues();
            opportunitiesBasketPage.StartAddingAnotherOpportunityFromBasket();
        }
        
        [Then(@"I will not be asked to select the Employer name again")]
        public void ThenIWillNotBeAskedToSelectTheEmployerNameAgain()
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.EnterOpportunityDetailsAndSearchForProvidersSecondPass(Constants.skillArea, Constants.postCode)
                                  .SelectProvidersAndContinue()
                                  .ClickContinueMoreThanOneOpportunityExists()
                                  .VerifyChosenProvidersAreDisplayedOnCheckAnswersScreen();
            ReferralCheckAnswersPage referralCheckAnswersPage = new ReferralCheckAnswersPage(webDriver);
            referralCheckAnswersPage.ConfirmAndSendOpportunity()
                                  .VerifyLatestReferralRecordValues()
                                  .ContinueWithOpportunityMultipleOpportunities()
                                  .ConfirmEmployerDetailsAndContinue()
                                  .FinishReferralJourney();
        }
    }
}
