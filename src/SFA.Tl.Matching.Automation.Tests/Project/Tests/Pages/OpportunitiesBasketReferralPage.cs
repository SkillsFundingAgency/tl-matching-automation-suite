using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class OpportunitiesBasketReferralPage : BasePage
    {
        private const string PAGE_TITLE = "All opportunities";
        private By continueButton = By.Id("tl-continue");
        private By AddAnotherOpportunity = By.Id("tl-add-another-opportunity");
        private By selectAllCheckbox = By.Name("selectall");
        private By Opportunity1WorkPlace = By.XPath("//tr[1]/td[1]");
        private By Opportunity1JobRole = By.XPath("//tr[1]/td[2]");
        private By Opportunity1StudentsWanted = By.XPath("//tr[1]/td[3]");
        private By Opportunity1NoOfProviders = By.XPath("//tr[1]/td[4]");

        public OpportunitiesBasketReferralPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        //Behaviour
        internal BeforeYouSendEmailsPage ContinueWithOpportunity()
        {
            FormCompletionHelper.ClickElement(continueButton);
            return new BeforeYouSendEmailsPage(webDriver);
        }

        internal BeforeYouSendEmailsPage ContinueWithOpportunityMultipleOpportunities()
        {
            FormCompletionHelper.ClickElement(selectAllCheckbox);
            FormCompletionHelper.ClickElement(continueButton);
            return new BeforeYouSendEmailsPage(webDriver);
        }

        internal FindLocalProvidersPage StartAddingAnotherOpportunityFromBasket()
        {
            FormCompletionHelper.ClickElement(AddAnotherOpportunity);
            return new FindLocalProvidersPage(webDriver);
        }

        //Assertions
        public void VerifyOpportunityDetailsAreDisplayedforOpportunity1()
        {
            string StudentsWanted = "At least 1";
            string NoOfProviders = "1";
                       
            PageInteractionHelper.VerifyText(Opportunity1WorkPlace, Constants.postCode);
            PageInteractionHelper.VerifyText(Opportunity1JobRole, "None given");
            PageInteractionHelper.VerifyText(Opportunity1StudentsWanted, StudentsWanted);
            PageInteractionHelper.VerifyText(Opportunity1NoOfProviders, NoOfProviders);
        }
    }
}
