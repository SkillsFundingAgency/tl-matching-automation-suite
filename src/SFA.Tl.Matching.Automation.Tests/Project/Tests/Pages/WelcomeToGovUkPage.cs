using System;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using OpenQA.Selenium;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class WelcomeToGovUkPage : BasePage
    {
        private static String PAGE_TITLE = "Welcome to GOV.UK";

        public WelcomeToGovUkPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By searchField = By.Name("q");
        private By searchButton = By.CssSelector(".search-submit");

        internal SearchResultsPage EnterSearchTextAndSubmit(String searchText)
        {
            //FormCompletionHelper.EnterText(searchField, Configurator.GetConfiguratorInstance.);
            FormCompletionHelper.ClickElement(searchButton);
            return new SearchResultsPage(webDriver);
        }
    }
}