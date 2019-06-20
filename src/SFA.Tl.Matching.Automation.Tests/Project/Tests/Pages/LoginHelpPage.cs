using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class LoginHelpPage : BasePage
    {
        private static String PAGE_TITLE = "How to sign in";
        private By LoginButton = By.Id("tl-login");
        By LoginText = By.LinkText("Login");
        By Logout = By.LinkText("Logout");

        public LoginHelpPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

       public LoginHelpPage VerifyLoginLinkIsPresent()
        {
            PageInteractionHelper.VerifyLinkIsPresent(LoginText, "Login");
            return this;
        }  
               
        public IDAMSLoginPage ClickLogin()
        {
            FormCompletionHelper.ClickElement(LoginButton);
            return new IDAMSLoginPage(webDriver);
        }

    }
}
