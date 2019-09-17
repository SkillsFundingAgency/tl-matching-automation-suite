using System;
using System.Threading;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class UserJourneyStartPageSteps : BaseTest
    {
        [Given(@"I navigate to the Matching Service home page")]
        [When(@"I navigate to the Matching Service home page")]
        public void GivenINavigateToTheMatchingServiceHomePage()
        {
            webDriver.Navigate().GoToUrl(Configurator.GetConfiguratorInstance().GetBaseUrl());
        }
        
        [Given(@"I am not logged in")]
        public void GivenIAmNotLoggedIn()
        {
            HowToSignInPage LoginHelpPage = new HowToSignInPage(webDriver);
            LoginHelpPage.VerifyLoginLinkIsPresent();           
        }

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            //Log the user in as an Admin user. 
            HowToSignInPage howToSignInPage = new HowToSignInPage(webDriver);
            howToSignInPage.VerifyLoginLinkIsPresent();
            howToSignInPage.Login();
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            //IDAMSLoginPage.IDAMSLogin(Configurator.GetConfiguratorInstance().GetAdminUserName(), Configurator.GetConfiguratorInstance().GetAdminPassword());
            IDAMSLoginPage.LoginAsAdminUser();
            Thread.Sleep(10000);
        }

        [Then(@"I will be shown the Login Help Page")]
        public void ThenIWillBeShownTheLoginHelpPage()
        {
            String CurrentPageURL = webDriver.Url;
            PageInteractionHelper.VerifyPageURL(CurrentPageURL, Configurator.GetConfiguratorInstance().GetBaseUrl());
        }

        [Then(@"I should be taken to the Start Page")]
        public void ThenIShouldBeTakenToTheStartPage()
        {
            webDriver.Navigate().GoToUrl(Configurator.GetConfiguratorInstance().GetBaseUrl());
            StartPage StartPage = new StartPage(webDriver);
            StartPage.VerifyPageURL();   
        }
    }
}
