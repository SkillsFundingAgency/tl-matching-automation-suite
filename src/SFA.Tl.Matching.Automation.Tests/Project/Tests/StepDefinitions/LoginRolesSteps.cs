using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LoginRolesSteps : BaseTest
    {
        [Given(@"I have logged in as an Admin user")]
        public void GivenIHaveLoggedInAsAnAdminUser()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.LoginAsAdminUser();
            Thread.Sleep(3000);           
        }
        
        [Given(@"I have logged in as a dual access user")]
        public void GivenIHaveLoggedInAsADualAccessUser()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.LoginAsDualUser();
        }
        
        [Given(@"I have logged in as an Standard user")]
        public void GivenIHaveLoggedInAsAnStandardUser()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.IDAMSLogin(Configurator.GetConfiguratorInstance().GetStandardUserName(), Configurator.GetConfiguratorInstance().GetStandardPassword());
            IDAMSLoginPage.LoginAsStandardUser();
        }
        
        [Then(@"I should be on the Start Page")]
        public void ThenIShouldBeOnTheStartPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.VerifyPageURL();
        }
        
        [Then(@"I should see an option stating ""(.*)""")]
        public void ThenIShouldSeeAnOptionStating(string expectedString)
        {
            StartPage StartPage = new StartPage(webDriver);
            StartPage.VerifyLinkPresent(expectedString);
        }
        
        [Then(@"I should not see a link to upload Employer Data")]
        public void ThenIShouldNotSeeALinkToUploadEmployerData()
        {
            StartPage StartPage = new StartPage(webDriver);
            StartPage.VerifyElementNotPresent();
            
        }

        [Given(@"I have attempted to log in as an non authorised IDAMS user")]
        public void GivenIHaveAttemptedToLogInAsAnNonAuthorisedIDAMSUser()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            Thread.Sleep(2000);
            IDAMSLoginPage.IDAMSLogin(Configurator.GetConfiguratorInstance().GetNonAuthorisedUserName(), Configurator.GetConfiguratorInstance().GetNonAuthorisedUserPassword())
            .ClickLoginButton();
        }

        [Then(@"I should be on the Invalid Role Page")]
        public void ThenIShouldBeOnTheInvalidRolePage()
        {
            InvalidRolePage InvalidRolePage = new InvalidRolePage(webDriver);
            InvalidRolePage.VerifyPageURL();
        }

    }
}
