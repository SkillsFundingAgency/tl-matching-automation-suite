using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class LoginRolesSteps : BaseTest
    {
        [Given(@"I have logged in as an ""(.*)""")]
        public void GivenIHaveLoggedInAsAn(string p0)
        {
            IDAMSLoginPage idamsLoginPage = new IDAMSLoginPage(webDriver);

            switch (p0)
            {
                case "Admin User":
                    idamsLoginPage.LoginAsAdminUser();
                    break;
                case "Standard User":
                    idamsLoginPage.LoginAsStandardUser();
                    break;
                case "Dual User":
                    idamsLoginPage.LoginAsDualUser();
                    break;
                case "Non Authorised User":
                    idamsLoginPage.LoginAsDualUser();
                    break;
            }
        }
        
        [Then(@"I should be on the Start Page")]
        public void ThenIShouldBeOnTheStartPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.VerifyPageURL();
        }

        [Then(@"I should see an option stating ""(.*)""")]
        public void ThenIShouldSeeAnOptionStating(string expectedString)
        {
            StartPage StartPage = new StartPage(webDriver);
            StartPage.VerifyLinkPresent(expectedString);
        }

        [Then(@"I should not see a link to upload Employer Data")]
        public void ThenIShouldNotSeeALinkToUploadEmployerData()
        {
            StartPage StartPage = new StartPage(webDriver);
            StartPage.VerifyElementNotPresent();
        }

        [Then(@"I should be on the Invalid Role Page")]
        public void ThenIShouldBeOnTheInvalidRolePage()
        {
            InvalidRolePage InvalidRolePage = new InvalidRolePage(webDriver);
            InvalidRolePage.VerifyPageURL();
        }

        [Given(@"I navigate to Find a Provider Page")]
        public void GivenINavigateToFindAProviderPage()
        {
            StartPage StartPage = new StartPage(webDriver);
            StartPage.StartAddingProviderData();
        }
    }
}
