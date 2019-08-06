using System;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ErrorMessagesOnTheCheckEmployerDetailsPageSteps : BaseTest
    {
        [Given(@"I navigate to the Check Employer Details page")]
        public void GivenINavigateToTheCheckEmployerDetailsPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.ClickStartButton();
            FindLocalProvidersPage findLocalProvidersPage = new FindLocalProvidersPage(webDriver);
            findLocalProvidersPage.AutoPopulateFields();
            findLocalProvidersPage.ClickSearchButton();
            SelectProvidersPage selectProvidersPage = new SelectProvidersPage(webDriver);
            selectProvidersPage.ClickReportProvisionGapLink();
            PlacementInformationPage placementInformationPage = new PlacementInformationPage(webDriver);
            placementInformationPage.EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue("No");
            WhoIsTheEmployerPage whoIsTheEmployerPage = new WhoIsTheEmployerPage(webDriver);
            whoIsTheEmployerPage.AutoPopulateEmployer();
            whoIsTheEmployerPage.ClickContinue();
        }
        
        [Given(@"I have cleared all of the text fields")]
        public void GivenIHaveClearedAllOfTheTextFields()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.ClearFields();
            checkEmployerDetailsPage.ClickConfirmAndContinueButton();
        }
        
        [Given(@"I press Continue on the Check Employer Details page")]
        public void GivenIPressContinueOnTheCheckEmployerDetailsPage()
        {
            CheckEmployersDetailsPage checkEmplyerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmplyerDetailsPage.ClickConfirmAndContinueButton();
            
        }
        
        [Then(@"the Check Employer Details page will show an error for Null contact name stating ""(.*)""")]
        public void ThenTheCheckEmployerDetailsPageWillShowAnErrorForNullContactNameStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyNoContactNameEnteredError(errorMessage);
        }
        
        [Then(@"the Check Employer Details page will show an error for Null email address stating ""(.*)""")]
        public void ThenTheCheckEmployerDetailsPageWillShowAnErrorForNullEmailAddressStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyNoEmailEnteredError(errorMessage);
        }
        
        [Then(@"the Check Employer Details page will show an error for Null contact number stating ""(.*)""")]
        public void ThenTheCheckEmployerDetailsPageWillShowAnErrorForNullContactNumberStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyNoPhoneEnteredError(errorMessage);
        }

        [Given(@"I enter a contact name (.*) character long on the Check Employer screen")]
        public void GivenIEnterAContactNameCharacterLongOnTheCheckEmployerScreen(int p0)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterContactName("A");
        }

        [Given(@"I press Continue on the Check Employer page")]
        public void GivenIPressContinueOnTheCheckEmployerPage()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.ClickConfirmAndContinueButton();
        }

        [Then(@"the Check Employer page will show an error for contact name not long enough stating ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForContactNameNotLongEnoughStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyErrorContactNameTooShort(errorMessage);
        }

        [Given(@"I enter a contact name longer than (.*) characters")]
        public void GivenIEnterAContactNameLongerThanCharacters(int p0)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterContactName("ABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJABCDEFGHIJ");
        }

        [Then(@"the Check Employer page will show an error for contact name being too long stating ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForContactNameBeingTooLongStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyErrorContactNameTooLong(errorMessage);
        }

        [Given(@"I enter a phone number consisting of alphanumeric characters only")]
        public void GivenIEnterAPhoneNumberConsistingOfAlphanumericCharactersOnly()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterPhoneNumber("ABCDEFG");
        }

        [Then(@"the Check Employer page will show an error for phone number must be a number stating ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForPhoneNumberMustBeANumberStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyErrorPhoneNoMustContainNos(errorMessage);
        }

        [Given(@"I enter a phone number consisting of alphanumeric characters and six numbers only")]
        public void GivenIEnterAPhoneNumberConsistingOfAlphanumericCharactersAndSixNumbersOnly()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterPhoneNumber("ABCDEFG123456");
        }

        [Then(@"the Check Employer page will show an error for phone number not long enough ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForPhoneNumberNotLongEnough(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyErrorPhoneNoMustBeSevenChars(errorMessage);
        }

        [Given(@"I enter special characters in contact name")]
        public void GivenIEnterSpecialCharactersInContactName()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterContactName("Name!£$%^&*()");
        }

        [Then(@"the Check Employer page will show an error for special characters in contact name stating ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForSpecialCharactersInContactNameStating(string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyErrorContactNameCharactersOnly(errorMessage);
        }

        [Then(@"the Check employers details page will show the details entered")]
        [Given(@"the Check employers details page will show the details entered")]
        public void ThenTheCheckEmployersDetailsPageWillShowTheDetailsEntered()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            CheckAnswersPage checkAnswersPage = checkEmployerDetailsPage.VerifyEmployerDetails().ClickConfirmAndContinueButton();          
        }

        [Then(@"the Referral Check employers details page will show the details entered")]
        public void ThenTheReferralCheckEmployersDetailsPageWillShowTheDetailsEntered()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyEmployerDetails();
        }
                          
        [Then(@"I am taken to the Check Employer Details page")]
        public void ThenIAmTakenToTheCheckEmployerDetailsPage()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
