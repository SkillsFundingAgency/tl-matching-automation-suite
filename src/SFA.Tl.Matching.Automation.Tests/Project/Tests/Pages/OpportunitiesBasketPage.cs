using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class OpportunitiesBasketPage : BasePage
    {
        private const string PAGE_TITLE = "All opportunities";

        private By continueButton = By.Id("tl-continue");
        private By AddAnotherOpportunity = By.Id("tl-add-another-opportunity");
        private By selectAllCheckbox = By.Name("selectall");
        private By Opportunity1WorkPlace = By.XPath("//tr[1]/td[1]");
        private By Opportunity1JobRole = By.XPath("//tr[1]/td[2]");
        private By Opportunity1StudentsWanted = By.XPath("//tr[1]/td[3]");
        private By Opportunity1NoOfProviders = By.XPath("//tr[1]/td[4]");

        public OpportunitiesBasketPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        internal SendEmailsPage SubmitContinueWithopportunity()
        {
            FormCompletionHelper.ClickElement(continueButton);
            return new SendEmailsPage(webDriver);
        }

        internal SendEmailsPage SubmitContinueWithopportunityMultipleOpportunities()
        {
            FormCompletionHelper.ClickElement(selectAllCheckbox);
            FormCompletionHelper.ClickElement(continueButton);
            return new SendEmailsPage(webDriver);
        }

        internal FindLocalProvidersPage ClickAddAnotherOpportunity()
        {
            FormCompletionHelper.ClickElement(AddAnotherOpportunity);
            return new FindLocalProvidersPage(webDriver);
        }

        public OpportunitiesBasketPage VerifyOpportunityDetailsAreDisplayedforOpportunity1()
        {
            string StudentsWanted = "at least 1";
            string NoOfProviders = "1";
                       
            PageInteractionHelper.VerifyText(Opportunity1WorkPlace, Constants.postCode);
            PageInteractionHelper.VerifyText(Opportunity1JobRole, "None given");
            PageInteractionHelper.VerifyText(Opportunity1StudentsWanted, StudentsWanted);
            PageInteractionHelper.VerifyText(Opportunity1NoOfProviders, NoOfProviders);
            return this;
        }


    }
}
