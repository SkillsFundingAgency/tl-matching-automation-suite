using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class NoPermissionPage : BasePage
    {
        private static String PAGE_TITLE = "Your account does not have permission to access this service";
        private String _expectedPageURL = "https://test.industryplacementmatching.education.gov.uk/no-permission";

        public NoPermissionPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, _expectedPageURL);
        }
    }
}