using System.Threading;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ErrorMessagesOnThePlacementInformationPageSteps : BaseTest
    {
        [Given(@"I navigate to the Referral Journey Placement Information page")]
        public void GivenINavigateToTheReferralJourneyPlacementInformationPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields();
            findLocalProvidersPage.ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.SelectProviders();
            selectProvidersPage.ClickContinue();
        }

        [Given(@"I navigate to the Provision Gap Placement Information page")]
        public void GivenINavigateToTheProvisionGapPlacementInformationPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields();
            findLocalProvidersPage.ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickReportProvisionGapLink();
        }

        [When(@"I enter no placement information and Continue")]
        public void WhenIEnterNoPlacementInformationAndContinue()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterNoPlacementInformationAndContinue();
        }        

        [When(@"I select (.*) for how many students needed")]
        public void WhenISelectForHowManyStudentsNeeded(string p0)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            switch (p0)
            {
                case "Yes":
                    placementInformationPage.SelectRadioButtonToVerifyNumberOfStudentsFieldDisplay(p0);
                    break;
                case "No":
                    placementInformationPage.SelectRadioButtonToVerifyNumberOfStudentsFieldDisplay(p0);
                    break;
            }
        }
        
        [Then(@"Number of Students field is (.*)")]
        public void ThenNumberOfStudentsFieldIs(string result)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            switch (result)
            {
                case "Displayed":
                    placementInformationPage.VerifyNumberOfPLacementsIsVisibile();
                    break;
                case "Not Displayed":
                    placementInformationPage.VerifyNumberOfPLacementsIsNotVisibile();
                    break;
            }            
        }        

        [When(@"I enter an invalid job title (.*) and Continue")]
        public void WhenIEnterAnInvalidJobTitleAndContinue(string p0)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterInvalidJobRoleAndContinue(p0);  
        }

        [When(@"I enter Invalid number of Students (.*) and Continue")]
        public void WhenIEnterInvalidNumberOfStudentsAndContinue(string p0)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterInvalidNumberOfStudentsAndContinue(p0);
            Thread.Sleep(3000);
        }

        [Then(@"the Placement Information page will show an error stating (.*) for (.*)")]
        public void ThenThePlacementInformationPageWillShowAnErrorStatingFor(string errorMessage, string inputType)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            switch (inputType)
            {
                case "NoProvidersChosen":
                    placementInformationPage.VerifyErrorForNoProvidersChosen(errorMessage);
                    break;
                case "StudentsOptionNotSelected":
                    placementInformationPage.VerifyError_PlacementRadioButtonNotSelected(errorMessage);
                    break;
            }
        }

        [Then(@"the (.*) for Invalid Job Role for (.*) characters is displayed")]
        public void ThenTheYouMustEnterAJobRoleUsingOrMoreCharactersForInvalidJobRoleForCharactersIsDisplayed(string errorMessage, string invalidCharacters)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            switch (invalidCharacters)
            {
                case "1":
                    placementInformationPage.VerifyErrorJobRoleTooShort(errorMessage);
                    break;
                case "100":
                    placementInformationPage.VerifyErrorJobRoleTooLong(errorMessage);
                    break;
            }
        }

        [Then(@"the (.*) for Invalid Number of Students is displayed for (.*)")]
        public void ThenTheTheNumberOfStudentsMustBeOrMoreForInvalidNumberOfStudentsIsDisplayedFor(string errorMessage, string invalidNumbers)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            switch (invalidNumbers)
            {
                case "0":
                    placementInformationPage.VerifyErrorPlacementNumberTooSmall(errorMessage);
                    break;
                case "1000":
                    placementInformationPage.VerifyErrorPlacementNumberTooBig(errorMessage);
                    break;
                case " ":
                    placementInformationPage.VerifyErrorPlacementNumberIsNull(errorMessage);
                    break;
            }
        }
    }
}
