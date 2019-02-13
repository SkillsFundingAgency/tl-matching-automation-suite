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
            LoginHelpPage LoginHelpPage = new LoginHelpPage(webDriver);
            LoginHelpPage.VerifyLoginLinkIsPresent();
           
        }
        
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            //Log the user in as an Admin user. 
            LoginHelpPage LoginHelpPage = new LoginHelpPage(webDriver);
            LoginHelpPage.VerifyLoginLinkIsPresent();
            LoginHelpPage.ClickLogin();
           
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.IDAMSLogin(Configurator.GetConfiguratorInstance().GetAdminUserName(), Configurator.GetConfiguratorInstance().GetAdminPassword());
            IDAMSLoginPage.ClickLoginButton();

            Thread.Sleep(10000);

        }
        
        [Then(@"I will be shown the Login Help Page")]
        public void ThenIWillBeShownTheLoginHelpPage()
        {
            String CurrentPageURL = webDriver.Url;
            PageInteractionHelper.VerifyPageURL(CurrentPageURL, Configurator.GetConfiguratorInstance().GetBaseUrl());
        }

        [Then(@"when I navigate to the homepage I will be taken to the Start Page")]
        public void ThenWhenINavigateToTheHomepageIWillBeTakenToTheStartPage()
        {
            webDriver.Navigate().GoToUrl(Configurator.GetConfiguratorInstance().GetBaseUrl());
            StartPage StartPage = new StartPage(webDriver);
            StartPage.VerifyPageURL();        

        }
    }
}
