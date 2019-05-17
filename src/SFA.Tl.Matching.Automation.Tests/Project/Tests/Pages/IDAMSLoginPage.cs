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

        public void IDAMSLogin(String userName, String passWord)
        {        
            FormCompletionHelper.EnterText(UserNameLocator, userName);
            FormCompletionHelper.EnterText(PasswordLocator, passWord);
        }

        public void IDAMSLoginUsernameOnly()
        {                    
            FormCompletionHelper.EnterText(UserNameLocator, Configurator.GetConfiguratorInstance().GetAdminUserName());
        }

        public void IDAMSLoginPasswordOnly()
        {        
            FormCompletionHelper.EnterText(PasswordLocator, Configurator.GetConfiguratorInstance().GetAdminPassword());
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


        public void VerifyLoginErrorMessage(String errorMessage)
        {
            PageInteractionHelper.VerifyText(ActualLoginErrorMessage, errorMessage);
        }

        public void VerifyInvalidLoginDetailsErrorMessage(String errorMessage)
        {
            PageInteractionHelper.VerifyText(ActualLoginErrorMessage, errorMessage);
        }

        public void VerifyMissingUSerIDErrorMessage(String errorMessage)
        {
            PageInteractionHelper.VerifyText(ActualLoginErrorMessage, errorMessage);
        }
    }
}
