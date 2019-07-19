using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public IDAMSLoginPage IDAMSLogin(String userName, String passWord)
        {
            FormCompletionHelper.EnterText(UserNameLocator, userName);
            FormCompletionHelper.EnterText(PasswordLocator, passWord);
            return this;
        }

        public IDAMSLoginPage IDAMSLoginUsernameOnly()
        {
            FormCompletionHelper.EnterText(UserNameLocator, Configurator.GetConfiguratorInstance().GetAdminUserName());
            return this;
        }

        public IDAMSLoginPage IDAMSLoginPasswordOnly()
        {
            FormCompletionHelper.EnterText(PasswordLocator, Configurator.GetConfiguratorInstance().GetAdminPassword());
            return this;
        }

        public StartPage LoginAsAdminUser()
        {
            IDAMSLogin(Configurator.GetConfiguratorInstance().GetAdminUserName(), Configurator.GetConfiguratorInstance().GetAdminPassword());
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
            return new StartPage(webDriver);
        }

        public IDAMSLoginPage ClickLoginButton()
        {
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
            return new IDAMSLoginPage(webDriver);

        }

        public StartPage LoginAsStandardUser()
        {
            IDAMSLogin(Configurator.GetConfiguratorInstance().GetStandardUserName(), Configurator.GetConfiguratorInstance().GetStandardPassword());
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
            return new StartPage(webDriver);
        }

        public StartPage LoginAsDualUser()
        {
            IDAMSLogin(Configurator.GetConfiguratorInstance().GetDualUserName(), Configurator.GetConfiguratorInstance().GetDualPassword());
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
            return new StartPage(webDriver);
        }

        public NoPermissionPage LoginAsNonAuthorisedUser()
        {
            IDAMSLogin(Configurator.GetConfiguratorInstance().GetNonAuthorisedUserName(), Configurator.GetConfiguratorInstance().GetNonAuthorisedUserPassword());
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
            return new NoPermissionPage(webDriver);
        }

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
