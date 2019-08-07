using System.Threading;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests
{
    [Binding]
    public class WhoIsTheEmployerPageErrorMessagesSteps : BaseTest
    {
        [Given(@"I navigate to Who is the employer page Referral Journey")]
        public void GivenINavigateToWhoIsTheEmployerPageReferralJourney()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields()
            .ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.SelectProviders()
                .ClickContinue();
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterMandatoryPlacementInformationForChosenProvidersAndContinue("No");
        }

        [Given(@"I navigate to Who is the employer page Provision Gap with unknown Number of students")]
        public void GivenINavigateToWhoIsTheEmployerPageProvisionGapWithUnknownNumberOfStudents()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields()
            .ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickReportProvisionGapLink();
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue("No");
        }

        [Given(@"I navigate to Who is the employer page Provision Gap with known Number of students")]
        public void GivenINavigateToWhoIsTheEmployerPageProvisionGapWithKnownNumberOfStudents()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields()
            .ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickReportProvisionGapLink();
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue("Yes");
        }        

        [Given(@"I clear the job field on the Who is the employer page")]
        public void GivenIClearTheJobFieldOnTheWhoIsTheEmployerPage()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            Thread.Sleep(3000);
        }
        
        [Given(@"I press Continue on the Who is the employer page")]
        public void GivenIPressContinueOnTheWhoIsTheEmployerPage()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.ClickContinue();
            
        }
        
        [Then(@"the Who is the employer page will show an error stating ""(.*)""")]
        [Given(@"the Who is the employer page will show an error stating ""(.*)""")]
        public void ThenTheWhoIsTheEmployerPageWillShowAnErrorStating(string errorMessage)
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.VerifyNullEmployerError(errorMessage);                       
        }

        [Then(@"I am on Who is the employer page")]
        [Given(@"I am on Who is the employer page")]
        public void ThenIAmOnWhoIsTheEmployerPage()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.VerifyPageURL();
           
        }

        [Then(@"I entered employer name and press continue")]
        [Given(@"I entered employer name and press continue")]
        public void IenteredEmployerandPressContinue()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver).EnterEmployerNameAndClickContinue();
        }
        
         [Given(@"I enter an employer name of ""(.*)"" on the Who is the employer page")]
        public void GivenIEnterAnEmployerNameOfOnTheWhoIsTheEmployerPage(string employerName)
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.EnterEmployer(employerName);
            Thread.Sleep(4000);            
        }
    }
}
