using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    class SendEmailsPage : BasePage
    {
        private const string PAGE_TITLE = "Before you send emails";
        private const string errorMessage = "adddasdsa";

        private By confirmationCheckbox = By.Name("ConfirmationSelected");
        private By confirmButton = By.Id("tl-continue");


        public SendEmailsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        internal ReferralDonePage SelectConfirmationCheckboxAndContinue()
        {
            SelectCheckbox();
            ClickContinue();
            return new ReferralDonePage(webDriver);
        }

        internal SendEmailsPage ClickContinueWithoutSelectingCheckbox()
        {
            ClickContinue();

            return this;
        }

        private void SelectCheckbox()
        {
            FormCompletionHelper.ClickElement(confirmationCheckbox);
        }

        private void ClickContinue()
        {
            FormCompletionHelper.ClickElement(confirmButton);
        }

        internal SendEmailsPage VerifyErrorMessageDisplayed()
        {
            string actualError = "sfddfd";
            PageInteractionHelper.VerifyText(errorMessage, actualError);
            return this;
        }
    }
}
