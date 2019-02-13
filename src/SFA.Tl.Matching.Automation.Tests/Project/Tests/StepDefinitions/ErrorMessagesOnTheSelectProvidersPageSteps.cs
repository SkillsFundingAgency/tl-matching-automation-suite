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
        public void GivenINavigateToTheSelectProvidersPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.EnterPostcode("B43 6JN");
            ScenarioContext.Current.Add("Postcode", "B43 6JN");

            findLocalProvidersPage.SelectFromDropdown("Construction");
            ScenarioContext.Current.Add("SkillArea", "Construction");
            
            findLocalProvidersPage.ClickSearchButton();
        }
        
        [Given(@"I clear the Employer postcode field")]
        public void GivenIClearTheEmployerPostcodeField()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClearPostcode();
        }
        
        [Given(@"I press the Search again button on the Select Providers page")]
        public void GivenIPressTheSearchAgainButtonOnTheSelectProvidersPage()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickSearchAgain();
        }
        
        [Then(@"the Select Providers page will show an error stating ""(.*)""")]
        public void ThenTheSelectProvidersPageWillShowAnErrorStating(string errorMessage)
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.VerifyPostcodeError(errorMessage);
        }

        [Given(@"I press the report provision gap link")]
        public void GivenIPressTheReportProvisionGapLink()
        {
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickReportProvisionGapLink();
        }


    }
}
