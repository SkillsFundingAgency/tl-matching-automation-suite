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
    class IDAMSLoginPage : BasePage
    {
        private static String PAGE_TITLE = "ESFA Sign in";

        public IDAMSLoginPage(IWebDriver webDriver) : base(webDriver)
        {
           // SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }


        private By UserNameLocator = By.Id("username");
        private By PasswordLocator = By.Id("password");
        private By LoginButton = By.XPath("//*[@id='mainContent']/div[2]/div[2]/form/div[5]/div/button");

        public void IDAMSLogin(String userName, String passWord)
        {
        
            FormCompletionHelper.EnterText(UserNameLocator, userName);
            FormCompletionHelper.EnterText(PasswordLocator, passWord);
        }

        public void IDAMSLoginUsernameOnly(String userName)
        {
                    
            FormCompletionHelper.EnterText(UserNameLocator, userName);
        }

        public void IDAMSLoginPasswordOnly(String passWord)
        {
        
            FormCompletionHelper.EnterText(PasswordLocator, passWord);
        }

        public void ClickLoginButton()
        {
            FormCompletionHelper.ClickElement(LoginButton);
            Thread.Sleep(5000);
        }

    }
}
