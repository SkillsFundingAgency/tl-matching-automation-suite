using System;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SendEmailPageSteps : BaseTest
    {
        [Given(@"I opt in to send emails and press Confirm and Send Opportunity")]
        public void GivenIOptInToSendEmailsAndPressConfirmAndSendOpportunity()
        {
            SendEmailsPage sendEmailsPage = new SendEmailsPage(webDriver);
            sendEmailsPage.SelectConfirmationCheckboxAndContinue();

        }
    }
}
