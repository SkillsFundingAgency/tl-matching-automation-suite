using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class InvalidRolePage : BasePage
    {
        private static String PAGE_TITLE = "You aren't assigned the 'Find an industry placement User' and/or 'Find an industry placement Administrator' role in the Information Management Services system";
        private String _expectedPageURL = "https://tl-test-mtchui-as.azurewebsites.net/Home/InvalidRole";

        public InvalidRolePage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }
               
        public InvalidRolePage VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, _expectedPageURL);
            return this;
        }
    }
}
