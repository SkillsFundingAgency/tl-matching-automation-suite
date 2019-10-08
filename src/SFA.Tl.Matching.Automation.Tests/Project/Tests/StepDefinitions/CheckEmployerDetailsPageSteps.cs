using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ErrorMessagesOnTheCheckEmployerDetailsPageSteps : BaseTest
    {
        [Given(@"I navigate to the Check Employer Details page For a Provison Gap Journey")]
        public void GivenINavigateToTheCheckEmployerDetailsPageForAProvisonGapJourney()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartANewOpportunity()
                .EnterOpportunityDetailsAndSearchForProviders(Constants.skillArea, Constants.postCode)
                .SelectNoSuitableProviers()
                .EnterMandatoryPlacementInformationForNoSuitableProvidersAndContinue("No")
                .EnterEmployerBusinessNameAndContinue(Constants.employerName);
        }

        [Given(@"Enter the Employer Details and continue for Referral Journey")]
        [Then(@"Enter the Employer Details and continue for Referral Journey")]
        public void ThenEnterTheEmployerDetailsAndContinueForReferralJourney()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterEmployerContactDetailsAndContinueForAReferralJourney(Constants.testName, Constants.testEmail, Constants.testPhoneNumber);
        }

        [When(@"Enter the Employer Details and continue for Provision Gap Journey")]
        [Then(@"Enter the Employer Details and continue for Provision Gap Journey")]
        public void ThenEnterTheEmployerDetailsAndContinueForProvisionGapJourney()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterEmployerContactDetailsAndContinueForAProvisionGapJourney(Constants.testName, Constants.testEmail, Constants.testPhoneNumber);
        }

        [Then(@"the Check employers details page must pull the correct details from DB")]
        public void ThenTheCheckEmployersDetailsPageMustPullTheCorrectDetailsFromDB()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.VerifyEmployerDetails(Constants.testEmployerNameForVerification);
        }

        [When(@"I clear all text fields on the Employer Contact Details and Continue")]
        public void WhenIClearAllTextFieldsOnTheEmployerContactDetailsAndContinue()
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.ClearEmployerContactDetailsAndContinue();
        }

        [When(@"I enter an Invalid contact name ""(.*)"" of ""(.*)"" on the Check Employer screen and Continue")]
        public void WhenIEnterAnInvalidContactNameOfOnTheCheckEmployerScreenAndContinue(string p0, string p1)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterInvalidEmployerContactNameAndContinue(p0);
        }

        [Then(@"the Check Employer page will show an error for ""(.*)"" contact name as ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForContactNameAs(string typeOfContactName, string errorMessage)
        {       
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);

            switch (typeOfContactName)
            {
                case "oneCharacterLong":
                    checkEmployerDetailsPage.VerifyErrorContactNameTooShort(errorMessage);
                    break;
                case "Morethan99Characters":
                    checkEmployerDetailsPage.VerifyErrorContactNameTooLong(errorMessage);
                    break;
                case "SpecialCharacters":
                    checkEmployerDetailsPage.VerifyErrorContactNameCharactersOnly(errorMessage);
                    break;
                case "Null":
                    checkEmployerDetailsPage.VerifyNoContactNameEnteredError(errorMessage);
                    break;
            }
        }

        [When(@"I enter an Invalid Phone Number ""(.*)"" of ""(.*)"" on the Check Employer screen and Continue")]
        public void WhenIEnterAnInvalidPhoneNumberOfOnTheCheckEmployerScreenAndContinue(string p0, string p1)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            checkEmployerDetailsPage.EnterInvalidEmployerPhoneNumberAndContinue(p0);
        }

        [Then(@"the Check Employer page will show an error for ""(.*)"" phone number must be a number stating ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForPhoneNumberMustBeANumberStating(string typeOfPhoneNumber, string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            switch (typeOfPhoneNumber)
            {
                case "AlphaNumericCharacters":
                    checkEmployerDetailsPage.VerifyErrorPhoneNoMustContainNos(errorMessage);
                    break;
                case "SixNumbersOnly":
                    checkEmployerDetailsPage.VerifyErrorPhoneNoMustBeSevenChars(errorMessage);
                    break;
                case "Null":
                    checkEmployerDetailsPage.VerifyNoPhoneEnteredError(errorMessage);
                    break;
            }
        }

        [Then(@"the Check Employer page will show an error for ""(.*)"" email address stating ""(.*)""")]
        public void ThenTheCheckEmployerPageWillShowAnErrorForEmailAddressStating(string typeOfEmailAddress, string errorMessage)
        {
            CheckEmployersDetailsPage checkEmployerDetailsPage = new CheckEmployersDetailsPage(webDriver);
            switch (typeOfEmailAddress)
            {                
                case "Null":
                    checkEmployerDetailsPage.VerifyNoEmailEnteredError(errorMessage);
                    break;
            }
        }
    }
}
