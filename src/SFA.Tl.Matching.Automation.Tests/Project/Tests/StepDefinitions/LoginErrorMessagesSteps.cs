using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class LoginErrorMessagesSteps : BaseTest
    {
        [Given(@"I have navigated to the IDAMS login page")]
        public void GivenIHaveNavigatedToTheIDAMSLoginPage()
        {
            HowToSignInPage howToSignInPage = new HowToSignInPage(webDriver);
            howToSignInPage.Login();            
        }

        [When(@"I only enter the username and try to login on the IDAMS login page")]
        public void WhenIOnlyEnterTheUsernameAndTryToLoginOnTheIDAMSLoginPage()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.LoginWithOnlyUsername();
        }

        [When(@"I only enter the password and try to login on the IDAMS login page")]
        public void WhenIOnlyEnterThePasswordAndTryToLoginOnTheIDAMSLoginPage()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.LoginWithOnlyPassword();
        }

        [When(@"I enter an invalid username password and try to login on the IDAMS login page")]
        public void WhenIEnterAnInvalidUsernamePasswordAndTryToLoginOnTheIDAMSLoginPage()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.LoginWithInvalidUsernameAndPassword();
        }

        [When(@"I Login without entering Username and Password")]
        public void WhenILoginWithoutEnteringUsernameAndPassword()
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.LoginWithoutUsernameAndPassword();
        }
        
        [Then(@"a warning will be displayed stating ""(.*)""")]
        public void ThenAWarningWillBeDisplayedStating(string WarningMessage)
        {
            IDAMSLoginPage IDAMSLoginPage = new IDAMSLoginPage(webDriver);
            IDAMSLoginPage.VerifyLoginErrorMessage(WarningMessage);
        }       
    }
}
