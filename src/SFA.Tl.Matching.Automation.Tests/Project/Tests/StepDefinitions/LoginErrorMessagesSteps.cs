using System;
using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class LoginErrorMessagesSteps : BaseTest
    {
        [Given(@"I have navigated to the IDAMS login page")]
        public void GivenIHaveNavigatedToTheIDAMSLoginPage()
        {
            webDriver.Navigate().GoToUrl(Configurator.GetConfiguratorInstance().GetBaseUrl());
            LoginHelpPage LoginHelpPage = new LoginHelpPage(webDriver);
            LoginHelpPage.ClickLogin();
            
        }
        
        [Given(@"I only enter the username on the IDAMS login page")]
        public void GivenIOnlyEnterTheUsernameOnTheIDAMSLoginPage()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.IDAMSLoginUsernameOnly("UserNameOnly");
        }

        [Given(@"I only enter the password on the IDAMS login page")]
        public void GivenIOnlyEnterThePasswordOnTheIDAMSLoginPage()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.IDAMSLoginPasswordOnly("PasswordOnly");
        }


        [Given(@"I do not enter the user name or password on the IDAMS login page")]
        public void GivenIDoNotEnterTheUserNameOrPasswordOnTheIDAMSLoginPage()
        {
            Console.WriteLine("Enter Nothing");
        }
        
        [Given(@"I enter an invalid username and password on the IDAMS login page")]
        public void GivenIEnterAnInvalidUsernameAndPasswordOnTheIDAMSLoginPage()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.IDAMSLogin("InvalidUser","InvalidPass");
        }
        
        [When(@"I press Login")]
        public void WhenIPressLogin()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.ClickLoginButton();
        }
        
        [Then(@"a warning will be displayed stating ""(.*)""")]
        public void ThenAWarningWillBeDisplayedStating(string WarningMessage)
        {
            String ActualErrorMessage = webDriver.FindElement(By.XPath("//*[@id='mainContent']/div[2]/div[2]/form/div[1]/ul/li/a")).Text;
            PageInteractionHelper.VerifyText(ActualErrorMessage, WarningMessage);
        }
    }
}
