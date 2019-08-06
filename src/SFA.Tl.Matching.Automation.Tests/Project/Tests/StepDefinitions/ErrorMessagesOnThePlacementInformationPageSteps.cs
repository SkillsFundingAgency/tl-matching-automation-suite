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

        [Given(@"I fill in the values on the Placement Information Page")]
        public void GivenIFillInTheValuesOnThePlacementInformationPage()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
         //   placementInformationPage.AutoPopulateFields();
        }

        //[Given(@"I clear the job field on the Placement Information page")]
        //public void GivenIClearTheJobFieldOnThePlacementInformationPage()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        // //   placementInformationPage.ClearJobField();
        //}

        [When(@"I enter no placement information and Continue")]
        public void WhenIEnterNoPlacementInformationAndContinue()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterNoPlacementInformationAndContinue();
        }

        [Given(@"I press Continue on the Placement Information page")]
        public void GivenIPressContinueOnThePlacementInformationPage()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
          //  placementInformationPage.ClickContinueExpectingErrors();
            
        }
        
        //[Then(@"the Placement Information page will show an error stating ""(.*)""")]
        //public void ThenThePlacementInformationPageWillShowAnErrorStating(string errorMessage)
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //    placementInformationPage.VerifyErrorNoJobPlacementEntered(errorMessage);         
        //}

        //[Then(@"the Placement Information page will display a no placement selected error stating ""(.*)""")]
        //public void ThenThePlacementInformationPageWillDisplayANoPlacementSelectedErrorStating(string errorMessage)
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //    placementInformationPage.VerifyError_PlacementRadioButtonNotSelected(errorMessage);            
        //}

        //[Given(@"I have selected the No radio button")]
        //public void GivenIHaveSelectedTheNoRadioButton()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //   // placementInformationPage.SelectNoRadioButton();
        //}

        //[Given(@"I have selected the Yes radio button")]
        //public void GivenIHaveSelectedTheYesRadioButton()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //   // placementInformationPage.SelectYesRadioButton();
        //}

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

        //[Given(@"I select the No radio button")]
        //public void GivenISelectTheNoRadioButton()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //   // placementInformationPage.SelectNoRadioButton();
        //}

        //[Then(@"Number of Placements field is not displayed")]
        //public void ThenNumberOfPlacementsFieldIsNotDisplayed()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //    placementInformationPage.VerifyNumberOfPLacementsIsNotVisibile();
        //}

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


        //[Given(@"I select the Yes radio button")]
        //public void GivenISelectTheYesRadioButton()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //    //placementInformationPage.SelectYesRadioButton();
        //}

        //[Then(@"Number of Placements field is displayed")]
        //public void ThenNumberOfPlacementsFieldIsDisplayed()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
        //    placementInformationPage.VerifyNumberOfPLacementsIsVisibile();
        //}
       
        //[Then(@"the Place Information page will show an error for job type not long enough stating ""(.*)""")]
        //public void ThenThePlaceInformationPageWillShowAnErrorForJobTypeNotLongEnoughStating(string errorMessage)
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            
        //}

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

        [Given(@"I enter a job description of ""(.*)"" on the Placement information page")]
        public void GivenIEnterAJobDescriptionOfOnThePlacementInformationPage(string jobTitle)
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            Thread.Sleep(2000);
         //   placementInformationPage.EnterJobRole(jobTitle);

        }

        [Given(@"I entered the placement information and select yes and enter number of placements then click continue button")]
        public void GivenIEnterPlaceInfoSelectYes()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            Thread.Sleep(2000);
          //  placementInformationPage.SelectYesContinue();

        }        

        [Given(@"I select No for the number of placements known")]
        public void GivenISelectNoForTheNumberOfPlacementsKnown()
        {
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
          //  placementInformationPage.SelectNoRadioButton();            
        }

        //[Then(@"I am on the Placement information page")]
        //public void ThenIAmOnThePlacementInformationPage()
        //{
        //    PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver).VerifyPageURL();
        //}
    }
}
