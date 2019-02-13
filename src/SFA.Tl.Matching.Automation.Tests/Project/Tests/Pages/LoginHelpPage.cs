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
        private static String PAGE_TITLE = "Match employers with providers for industry placements";

        public LoginHelpPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By LoginButton = By.XPath("//*[@id='main-content']/div/div/div/a");
        By LoginText = By.LinkText("Login");
        By Logout = By.LinkText("Logout");

       public void VerifyLoginLinkIsPresent()
        {
        PageInteractionHelper.VerifyLinkIsPresent(LoginText, "Login");
        }
        
        
       
        public void ClickLogin()
        {
            FormCompletionHelper.ClickElement(LoginButton);
          //  return new IDAMSLoginPage(webDriver);
        }

    }
}
