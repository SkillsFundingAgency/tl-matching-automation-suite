using System;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class SearchResultsPage : BasePage
    {
        private static String PAGE_TITLE = "Search results for";
        private By dfeLink = By.LinkText("Department for Education");

        public SearchResultsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }        

        internal DepartmentForEducationHomePage ClickDfeLink()
        {
            FormCompletionHelper.ClickElement(dfeLink);
            return new DepartmentForEducationHomePage(webDriver);
        }
    }
}