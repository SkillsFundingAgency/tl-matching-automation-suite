using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    public class BeforeYouSendEmailsPageSteps : BaseTest
    {
        [Given(@"I opt in to send emails and press Confirm and Send Opportunity")]
        public void GivenIOptInToSendEmailsAndPressConfirmAndSendOpportunity()
        {
            BeforeYouSendEmailsPage sendEmailsPage = new BeforeYouSendEmailsPage(webDriver);
            sendEmailsPage.ConfirmEmployerDetailsAndContinue();
        }
    }
}
