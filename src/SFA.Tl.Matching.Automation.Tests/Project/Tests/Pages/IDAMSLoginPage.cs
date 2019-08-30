using System;
using System.Threading;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class IDAMSLoginPage : BasePage
    {
        private static String PAGE_TITLE = "ESFA Sign in";
        private By UserNameLocator = By.Id("username");
        private By PasswordLocator = By.Id("password");
        private By LoginButton = By.XPath("//*[@id='mainContent']/div[2]/div[2]/form/div[5]/div/button");
        private By ActualLoginErrorMessage = By.XPath("//*[@class='animate-css-fadeIn-on-enter animate-css-fadeOut-on-leave ng-scope']/a");

        public IDAMSLoginPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }        

        private void EnterUsername(String userName)
        {
            FormCompletionHelper.EnterText(UserNameLocator, userName);
        }

        private void EnterPassword(String passWord)
        {
            FormCompletionHelper.EnterText(PasswordLocator, passWord);
        }

        private void ClickLoginButton()
        {
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
        }

        //Behaviour
        public StartPage LoginAsAdminUser()
        {
            EnterUsername(Configurator.GetConfiguratorInstance().GetAdminUserName());
            EnterPassword(Configurator.GetConfiguratorInstance().GetAdminPassword());
            ClickLoginButton();
            Thread.Sleep(5000);
            return new StartPage(webDriver);
        }        

        public StartPage LoginAsStandardUser()
        {
            EnterUsername(Configurator.GetConfiguratorInstance().GetStandardUserName());
            EnterPassword(Configurator.GetConfiguratorInstance().GetStandardPassword());
            ClickLoginButton();
            Thread.Sleep(5000);
            return new StartPage(webDriver);
        }

        public StartPage LoginAsDualUser()
        {
            EnterUsername(Configurator.GetConfiguratorInstance().GetDualUserName());
            EnterPassword(Configurator.GetConfiguratorInstance().GetDualPassword());
            ClickLoginButton();
            Thread.Sleep(5000);
            return new StartPage(webDriver);
        }

        public InvalidRolePage LoginAsNonAuthorisedUser()
        {
            EnterUsername(Configurator.GetConfiguratorInstance().GetNonAuthorisedUserName());
            EnterPassword(Configurator.GetConfiguratorInstance().GetNonAuthorisedUserPassword());
            ClickLoginButton();
            Thread.Sleep(5000);
            return new InvalidRolePage(webDriver);
        }

        public IDAMSLoginPage LoginWithOnlyUsername()
        {
            EnterUsername(Configurator.GetConfiguratorInstance().GetAdminUserName());
            ClickLoginButton();
            Thread.Sleep(5000);
            return new IDAMSLoginPage(webDriver);
        }

        public IDAMSLoginPage LoginWithOnlyPassword()
        {
            EnterPassword(Configurator.GetConfiguratorInstance().GetAdminPassword());
            ClickLoginButton();
            Thread.Sleep(5000);
            return new IDAMSLoginPage(webDriver);
        }

        public IDAMSLoginPage LoginWithInvalidUsernameAndPassword()
        {
            EnterUsername(Constants.InvalidUser);
            EnterPassword(Constants.InvalidPass);
            ClickLoginButton();
            Thread.Sleep(5000);
            return new IDAMSLoginPage(webDriver);
        }

        public IDAMSLoginPage LoginWithoutUsernameAndPassword()
        {
            ClickLoginButton();
            Thread.Sleep(5000);
            return new IDAMSLoginPage(webDriver);
        }        

        //Assertions
        public IDAMSLoginPage VerifyLoginErrorMessage(String errorMessage)
        {
            PageInteractionHelper.VerifyText(ActualLoginErrorMessage, errorMessage);
            return this;
        }
        public IDAMSLoginPage VerifyInvalidLoginDetailsErrorMessage(String errorMessage)
        {
            PageInteractionHelper.VerifyText(ActualLoginErrorMessage, errorMessage);
            return this;
        }

        public IDAMSLoginPage VerifyMissingUSerIDErrorMessage(String errorMessage)
        {
            PageInteractionHelper.VerifyText(ActualLoginErrorMessage, errorMessage);
            return this;
        }
    }
}
