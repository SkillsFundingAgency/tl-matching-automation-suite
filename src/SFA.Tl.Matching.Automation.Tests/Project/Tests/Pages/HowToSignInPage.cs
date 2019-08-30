using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class HowToSignInPage : BasePage
    {
        private static String PAGE_TITLE = "How to sign in";
        private By LoginButton = By.Id("tl-login");
        By LoginText = By.LinkText("Login");

        public HowToSignInPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        //Behaviour
        public IDAMSLoginPage Login()
        {
           FormCompletionHelper.ClickElement(LoginButton);
           return new IDAMSLoginPage(webDriver);
        }

        //Assertions
        public HowToSignInPage VerifyLoginLinkIsPresent()
        {
            PageInteractionHelper.VerifyLinkIsPresent(LoginText, "Login");
            return this;
        }
    }
}
