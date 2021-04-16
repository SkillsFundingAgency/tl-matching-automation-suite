using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class BeforeYouSendEmailsPage : BasePage
    {
        //Page locators
        private const string PAGE_TITLE = "Before you send emails";        
        private By confirmationCheckbox = By.Name("ConfirmationSelected");
        private By confirmButton = By.Id("tl-continue");

        //Error message locators
        private By actualErrorMessage = By.LinkText("You must confirm that we can share the employer’s details with the selected providers");

        public BeforeYouSendEmailsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private void SelectCheckbox()
        {
            FormCompletionHelper.ClickElement(confirmationCheckbox);
        }

        private void ClickContinue()
        {
            FormCompletionHelper.ClickElement(confirmButton);
        }

        internal EmailsSentPage ConfirmEmployerDetailsAndContinue()
        {
            SelectCheckbox();
            ClickContinue();
            return new EmailsSentPage(webDriver);
        }

        internal BeforeYouSendEmailsPage ContinueWithoutConfirmingEmployerDetails()
        {
            ClickContinue();
            return this;
        }        

        internal void VerifyErrorMessageDisplayed(string expectedError)
        {
            PageInteractionHelper.VerifyText(actualErrorMessage, expectedError);
        }
    }
}
