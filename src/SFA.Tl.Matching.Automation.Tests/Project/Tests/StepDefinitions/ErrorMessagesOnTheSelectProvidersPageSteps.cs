using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{

    [Binding]
    public class ErrorMessagesOnTheSelectProvidersPageSteps : BaseTest
    {
        [Given(@"I navigate to the Select Providers page")]
        public static void GivenINavigateToTheSelectProvidersPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartANewOpportunity()
                     .EnterOpportunityDetailsAndSearchForProviders(Constants.skillArea, Constants.postCode);            
        }
        
        [Then(@"the Select Providers page will show an error stating ""(.*)""")]
        public void ThenTheSelectProvidersPageWillShowAnErrorStating(string errorMessage)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeError(errorMessage);
        }

        [Given(@"I press the report provision gap link")]
        public PlacementInformationPage GivenIPressTheReportProvisionGapLink()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            PlacementInformationPage placementInformationPage = selectProvidersPage.SelectNoSuitableProviers();
            return placementInformationPage;
        }
    }
}
