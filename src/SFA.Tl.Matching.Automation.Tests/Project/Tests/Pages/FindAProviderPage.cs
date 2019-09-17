using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class FindAProviderPage : BasePage
    {        
        private static String PAGE_TITLE = "Find a provider";
        private By ProviderUkprnSearchField = By.Id("UkPrn");
        private By Search = By.ClassName("button");
        private By ProviderEditLink = By.PartialLinkText("Edit"); //provider-overview/977

        public FindAProviderPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public void SearchForAProviderUkprn(String Ukprn)
        {
            FormCompletionHelper.EnterText(ProviderUkprnSearchField, Ukprn);
            FormCompletionHelper.ClickElement(Search);
        }

        public ProviderAndVenuesDetailsPage ClickProviderEditLink()
        {
            FormCompletionHelper.ClickElement(ProviderEditLink);
            return new ProviderAndVenuesDetailsPage(webDriver);
        }        
    }
}
