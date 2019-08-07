using System;
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
            checkEmployerDetailsPage.ClickConfirmAndContinueButton()
                                    .CheckPlacementInformationFirstPass()
                                    .VerifyProvidersAreDisplayed()
                                    .ClickConfirmAndSendutton();
                              
        }



        [When(@"I press Add another Opportunity on the Opportunity Basket")]
        public void WhenIPressAddAnotherOpportunityOnTheOpportunityBasket()
        {
            OpportunitiesBasketPage opportunitiesBasketPage = new OpportunitiesBasketPage(webDriver);
            opportunitiesBasketPage.VerifyOpportunityDetailsAreDisplayedforOpportunity1()
                                   .ClickAddAnotherOpportunity();
                                  
                                    
                                    
        }
        
        [Then(@"I will not be asked to select the Employer name again")]
        public void ThenIWillNotBeAskedToSelectTheEmployerNameAgain()
        {
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFieldsSecondPass()
                                    .ClickSearchButton()
                                    .SelectProviderAndClickContinue()
                                    .ClickContinueMoreThanOneOpportunityExists()
                                    .VerifyProvidersAreDisplayed()
                                    .ClickConfirmAndSendutton()
                                    .SubmitContinueWithopportunityMultipleOpportunities()
                                    .SelectConfirmationCheckboxAndContinue()
                                    .ClickFinishbutton();
        }
    }
}
