using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions;
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
            startPage.StartANewOpportunity()
                .EnterOpportunityDetailsAndSearchForProviders(Constants.skillArea, Constants.postCode)
                .SelectProvidersAndContinue()
                .EnterMandatoryPlacementInformationForChosenProvidersAndContinue("No");
        }

        [Given(@"I navigate to Who is the employer page Referral Journey by entering placement information")]
        public void GivenINavigateToWhoIsTheEmployerPageReferralJourneyByEnteringPlacementInformation()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartANewOpportunity()
                .EnterOpportunityDetailsAndSearchForProviders(Constants.skillArea, Constants.postCode)
                .SelectProvidersAndContinue()
                .EnterValidJobRole(Constants.jobTitle)
                .EnterMandatoryPlacementInformationForChosenProvidersAndContinue("Yes");
                
        }


        [Given(@"I navigate to Who is the employer page Provision Gap with unknown Number of students")]
        public void GivenINavigateToWhoIsTheEmployerPageProvisionGapWithUnknownNumberOfStudents()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartANewOpportunity()
                .EnterOpportunityDetailsAndSearchForProviders(Constants.skillArea, Constants.postCode)
                .SelectNoSuitableProviers()
                .EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue("No");
        }

        [Given(@"I navigate to Who is the employer page Provision Gap with known Number of students")]
        public void GivenINavigateToWhoIsTheEmployerPageProvisionGapWithKnownNumberOfStudents()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartANewOpportunity()
                .EnterOpportunityDetailsAndSearchForProviders(Constants.skillArea, Constants.postCode)
                .SelectNoSuitableProviers()
                .EnterValidJobRole(Constants.jobTitle)
                .EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue("Yes");
        }

        [When(@"I enter an Employer business name ""(.*)"" and Continue")]
        [Given(@"I enter an Employer business name ""(.*)"" and Continue")]
        public void GivenIEnterAnEmployerBusinessNameAndContinue(string typeOfEmployer)
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            switch (typeOfEmployer)
            {
                case "testNameForGeneralFlow":
                    whoIstheEmployerPage.EnterEmployerBusinessNameAndContinue(Constants.employerName);
                    break;
                case "testNameForPageCheck":
                    whoIstheEmployerPage.EnterEmployerBusinessNameAndContinue(Constants.testEmployerNameForVerification);
                    break;
            }            
        }      

        [When(@"I enter no Employer business name and Continue")]
        public void WhenIEnterNoEmployerBusinessNameAndContinue()
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.EnterNoEmployerBusinessNameAndContinue();
        }

        [Then(@"the Who is the employer page will show an error stating ""(.*)""")]
        public void ThenTheWhoIsTheEmployerPageWillShowAnErrorStating(string errorMessage)
        {
            WhoIsTheEmployerPage whoIstheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIstheEmployerPage.VerifyNullEmployerError(errorMessage);
        }
    }
}
