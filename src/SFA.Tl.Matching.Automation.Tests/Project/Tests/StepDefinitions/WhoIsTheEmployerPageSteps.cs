using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class WhoIsTheEmployerPageErrorMessagesSteps : BaseTest
    {
        [Given(@"I navigate to the Who is the employer page")]
        public void GivenINavigateToTheWhoIsTheEmployerPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields();
            findLocalProvidersPage.ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickReportProvisionGapLink();
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.AutoPopulateFields();
            placementInformationPage.ClickContinueButton();
        }
        
        [Given(@"I clear the job field on the Who is the employer page")]
        public void GivenIClearTheJobFieldOnTheWhoIsTheEmployerPage()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            Thread.Sleep(3000);
        }
        
        [Given(@"I press Continue on the Who is the employer page")]
        public void GivenIPressContinueOnTheWhoIsTheEmployerPage()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.ClickContinue();
        }
        
        [Then(@"the Who is the employer page will show an error stating ""(.*)""")]
        public void ThenTheWhoIsTheEmployerPageWillShowAnErrorStating(string errorMessage)
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.VerifyNullEmployerError(errorMessage);                       
        }

        [Then(@"I am on Who is the employer page")]
        public void ThenIAmOnWhoIsTheEmployerPage()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.VerifyPageURL();
        }

        [Given(@"I enter an employer name on the Who is the employer page")]
        public void GivenIEnterAnEmployerNameOnTheWhoIsTheEmployerPage()
        {
            // not used at the moment
        }

        [Given(@"I enter an employer name of ""(.*)"" on the Who is the employer page")]
        public void GivenIEnterAnEmployerNameOfOnTheWhoIsTheEmployerPage(string employerName)
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.EnterEmployer(employerName);
            Thread.Sleep(4000);            
        }
    }
}
