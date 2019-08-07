using System;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class OpportunityBasketSteps : BaseTest 
    {
        [Given(@"I press Continue with Opportunity on the Opportunity Basket")]
        public void GivenIPressContinueWithOpportunityOnTheOpportunityBasket()
        {
            OpportunitiesBasketPage opportunityBasketPage = new OpportunitiesBasketPage(webDriver);
            opportunityBasketPage.VerifyOpportunityDetailsAreDisplayedforOpportunity1()
                                 .SubmitContinueWithopportunity();
        }
    }
}
