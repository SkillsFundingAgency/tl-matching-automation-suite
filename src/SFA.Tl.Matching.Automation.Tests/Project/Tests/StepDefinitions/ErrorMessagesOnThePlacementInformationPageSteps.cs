using System;
using System.Threading;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ErrorMessagesOnThePlacementInformationPageSteps : BaseTest
    {
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

        [Given(@"I fill in the values on the Placement Information Page")]
        public void GivenIFillInTheValuesOnThePlacementInformationPage()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.AutoPopulateFields();
        }

        [Given(@"I clear the job field on the Placement Information page")]
        public void GivenIClearTheJobFieldOnThePlacementInformationPage()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.ClearJobField();
        }
        
        [Given(@"I press Continue on the Placement Information page")]
        public void GivenIPressContinueOnThePlacementInformationPage()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.ClickContinueButton();
            
        }
        
        [Then(@"the Placement Information page will show an error stating ""(.*)""")]
        public void ThenThePlacementInformationPageWillShowAnErrorStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyErrorNoJobPlacementEntered(errorMessage);         
        }

        [Then(@"the Placement Information page will display a no placement selected error stating ""(.*)""")]
        public void ThenThePlacementInformationPageWillDisplayANoPlacementSelectedErrorStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyError_PlacementRadioButtonNotSelected(errorMessage);            
        }

        [Given(@"I have selected the No radio button")]
        public void GivenIHaveSelectedTheNoRadioButton()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.SelectNoRadioButton();
        }

        [Given(@"I have selected the Yes radio button")]
        public void GivenIHaveSelectedTheYesRadioButton()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.SelectYesRadioButton();
        }

        [Then(@"the Number of Placements field is not displayed")]
        public void ThenTheNumberOfPlacementsFieldIsNotDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the Number of Placements field is displayed")]
        public void ThenTheNumberOfPlacementsFieldIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select the No radio button")]
        public void GivenISelectTheNoRadioButton()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.SelectNoRadioButton();
        }

        [Then(@"Number of Placements field is not displayed")]
        public void ThenNumberOfPlacementsFieldIsNotDisplayed()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyNumberOfPLacementsIsNotVisibile();
        }

        [Given(@"I select the Yes radio button")]
        public void GivenISelectTheYesRadioButton()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.SelectYesRadioButton();
        }

        [Then(@"Number of Placements field is displayed")]
        public void ThenNumberOfPlacementsFieldIsDisplayed()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyNumberOfPLacementsIsVisibile();
        }

        [Given(@"I enter a job title (.*) character long")]
        public void GivenIEnterAJobTitleCharacterLong(int p0)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterJobRole("A");
        }

        [Then(@"the Place Information page will show an error for job type not long enough stating ""(.*)""")]
        public void ThenThePlaceInformationPageWillShowAnErrorForJobTypeNotLongEnoughStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyErrorJobRoleTooShort(errorMessage);
        }

        [Given(@"I enter a job title longer than (.*) characters")]
        public void GivenIEnterAJobTitleLongerThanCharacters(int p0)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterJobRole("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ");
        }

        [Then(@"the Place Information page will show an error for job type too long stating ""(.*)""")]
        public void ThenThePlaceInformationPageWillShowAnErrorForJobTypeTooLongStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyErrorJobRoleTooLong(errorMessage);
        }

        [Given(@"I enter (.*) for the number of placements")]
        public void GivenIEnterForTheNumberOfPlacements(int num)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterNumberOfPlacements(num);
        }

        [Then(@"the Place Information page will show an error for number of placements being too small stating ""(.*)""")]
        public void ThenThePlaceInformationPageWillShowAnErrorForNumberOfPlacementsBeingTooSmallStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyErrorPlacementNumberTooSmall(errorMessage);
        }

        [Then(@"the Place Information page will show an error for number of placements being too big stating ""(.*)""")]
        public void ThenThePlaceInformationPageWillShowAnErrorForNumberOfPlacementsBeingTooBigStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyErrorPlacementNumberTooBig(errorMessage);
        }

        [Then(@"the Place Information page will show an error for Placement number cannot be null stating ""(.*)""")]
        public void ThenThePlaceInformationPageWillShowAnErrorForPlacementNumberCannotBeNullStating(string errorMessage)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.VerifyErrorPlacementNumberIsNull(errorMessage);
        }

        [Then(@"I am on the Placement information page")]
        public void ThenIAmOnThePlacementInformationPage()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver).VerifyPageURL();
           
        }

        [Given(@"I entered the placement information and press No then click continue button")]
        public void IenteredplaceinformationandPressNo()
        {
            WhoIsTheEmployerPage whoIsTheEmployerPage = new PlacementInformationPage(webDriver).ClickContinue(); 

        }
        

        [Given(@"I enter a job description of ""(.*)"" on the Placement information page")]
        public void GivenIEnterAJobDescriptionOfOnThePlacementInformationPage(string jobTitle)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            Thread.Sleep(2000);
            placementInformationPage.EnterJobRole(jobTitle);

        }

        [Given(@"I entered the placement information and select yes and enter number of placements then click continue button")]
        public void GivenIEnterPlaceInfoSelectYes()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            Thread.Sleep(2000);
            placementInformationPage.SelectYesContinue();

        }        

        [Given(@"I select No for the number of placements known")]
        public void GivenISelectNoForTheNumberOfPlacementsKnown()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.SelectNoRadioButton();            
        }
    }
}
