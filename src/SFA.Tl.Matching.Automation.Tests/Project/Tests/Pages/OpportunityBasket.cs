using System;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class GDPRScreen : BasePage
    {
        private static String PAGE_TITLE = "Before you send emails";
        private By ConfirmAndSendOpportunity = By.Id("tl-continue");
        private By ConfirmationTickbox = By.Id("ConfirmationSelected");
        private By SaveAndComeBackLater = By.LinkText("Save and come back later");

        public GDPRScreen(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }        

        internal DepartmentForEducationHomePage ClickDfeLink()
        {
           // FormCompletionHelper.ClickElement(dfeLink);
            return new DepartmentForEducationHomePage(webDriver);
        }
    }
}