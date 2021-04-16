using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System;
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

        [Then(@"I check that the emails are sent successfully")]
        public void ThenICheckThatTheEmailsAreSentSuccessfully()
        {
            String query = ("Select * from opportunityitem");
            EmailsSentPage EmailsSentPage = new EmailsSentPage(webDriver);
            int IsCompleted = EmailsSentPage.GetIsCompleted(query);
            EmailsSentPage.VerifyIsCompletedIsTrue(IsCompleted);
        }       
    }
}
