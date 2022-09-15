using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class ProviderAndVenuesDetailsPage : BasePage
    {
        private static String PAGE_TITLE = "Abingdon And Witney College";
        private By PostCodeTextField = By.XPath("//*[@id='main-content']/div/div/form/table/tbody/tr[1]/th");
        private By VenueEditLink = By.PartialLinkText("Edit");
        private By ProviderUkprnSearchField = By.Id("UkPrn");

        public ProviderAndVenuesDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }
        
        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }        

        public void EnterProvidersUkprn(String Ukprn)
        {
            FormCompletionHelper.EnterText(ProviderUkprnSearchField, Ukprn);
        }

        public string GetPostCodeFromVenues()
        {
            return FormCompletionHelper.GetText(PostCodeTextField);
        }

        public VenueAndQualificationsDetailsPage ClickVenueEditLink()
        {
            FormCompletionHelper.ClickElement(VenueEditLink);
            return new VenueAndQualificationsDetailsPage(webDriver);
        }
    }
}