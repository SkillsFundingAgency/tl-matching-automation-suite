using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    public class EmailsSentPageSteps : BaseTest
    {
        [Then(@"the Emails Sent Page is displayed with the correct text")]
        public void ThenTheEmailsSentPageIsDisplayedWithTheCorrectText()
        {
            EmailsSentPage emailsSentPage = new EmailsSentPage(webDriver);
            emailsSentPage.VerifyWhatHappensNextText();
        }
    }
}
