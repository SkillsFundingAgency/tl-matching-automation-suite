using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class CheckEmployersDetailsPage : BasePage
    {
        //Page Locators
        private static String PAGE_TITLE = "Confirm that the employer’s contact details for industry placements are accurate and up-to-date";
        private By ConfirmAndContinueButton = By.ClassName("govuk-button");
        private By ContactField = By.Name("PrimaryContact"); //EmployerContact
        private By PhoneNumberField = By.Id("Phone");  //EmployerContactPhone
        private By EmailField = By.Id("Email"); //EmployerContactEmail

        //Error Message Locators
        private By EnterContactNameError = By.LinkText("You must enter a contact name for placements");
        private By EnterEmailError = By.LinkText("You must enter a contact email for placements");
        private By EnterPhoneNumberError = By.LinkText("You must enter a contact telephone number for placements");
        private By EnterLongerContactError = By.LinkText("You must enter a contact name using 2 or more characters");
        //check and remove comment
        //You must enter a contact name using 99 characters or less
        private By EnterShorterContactError = By.LinkText("You must enter a contact name that is 100 characters or fewer");
        private By EnterCharactersInContactError = By.LinkText("You must enter a contact name using only letters, hyphens and apostrophes");
        private By EnterANumber = By.LinkText("You must enter a number");
        private By EnterPhoneNumber7CharactersLong = By.LinkText("You must enter a telephone number that has 7 or more numbers");
        
        //Actions
        public CheckEmployersDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private void EnterEmployerContactName(String name)
        {
            FormCompletionHelper.EnterText(ContactField, name);
        }

        private void EnterEmployerPhoneNumber(String number)
        {
            FormCompletionHelper.EnterText(PhoneNumberField, number);
        }

        private void EnterEmployerEmail(String email)
        {
            FormCompletionHelper.EnterText(EmailField, email);
        }

        private void ClickConfirmAndContinueButton()
        {
            FormCompletionHelper.ClickElement(ConfirmAndContinueButton);
        }

        //Behaviours
        internal ReferralCheckAnswersPage EnterEmployerContactDetailsAndContinueForAReferralJourney(string name, string email, string number) //ForAReferralJourney
        {
            EnterEmployerContactName(name);
            EnterEmployerEmail(email);
            EnterEmployerPhoneNumber(number);
            ClickConfirmAndContinueButton();
            ScenarioContext.Current["_EmployerContactName"] = name;
            ScenarioContext.Current["_EmployerContactEmail"] = email;
            ScenarioContext.Current["_EmployerContactNumber"] = number;
            return new ReferralCheckAnswersPage(webDriver);
        }

        internal OpportunityBasketProvisionGapPage EnterEmployerContactDetailsAndContinueForAProvisionGapJourney(string name, string email, string number) //ForAReferralJourney
        {
            EnterEmployerContactName(name);
            EnterEmployerEmail(email);
            EnterEmployerPhoneNumber(number);
            ClickConfirmAndContinueButton();
            ScenarioContext.Current["_EmployerContactName"] = name;
            ScenarioContext.Current["_EmployerContactEmail"] = email;
            ScenarioContext.Current["_EmployerContactNumber"] = number;
            return new OpportunityBasketProvisionGapPage(webDriver);
        }

        internal CheckEmployersDetailsPage ClearEmployerContactDetailsAndContinue()
        {
            FormCompletionHelper.ClearText(ContactField);
            FormCompletionHelper.ClearText(PhoneNumberField);
            FormCompletionHelper.ClearText(EmailField);
            ClickConfirmAndContinueButton();
            return this;
        }

        public CheckEmployersDetailsPage EnterInvalidEmployerContactNameAndContinue(string name)
        {
            EnterEmployerContactName(name);
            FormCompletionHelper.ClickElement(ConfirmAndContinueButton);
            return new CheckEmployersDetailsPage(webDriver);
        }

        public CheckEmployersDetailsPage EnterInvalidEmployerPhoneNumberAndContinue(string number)
        {
            EnterEmployerPhoneNumber(number);
            FormCompletionHelper.ClickElement(ConfirmAndContinueButton);
            return new CheckEmployersDetailsPage(webDriver);
        }

        //Assertions
        public void VerifyNoContactNameEnteredError(string expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterContactNameError, expectedErrorMessage);
        }

        public void VerifyNoEmailEnteredError(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterEmailError, expectedErrorMessage);
        }

        public void VerifyNoPhoneEnteredError(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterPhoneNumberError, expectedErrorMessage);
        }

        public void VerifyErrorContactNameTooShort(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterLongerContactError, expectedErrorMessage);
        }

        public void VerifyErrorContactNameTooLong(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterShorterContactError, expectedErrorMessage);
        }

        public void VerifyErrorPhoneNoMustContainNos(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterANumber, expectedErrorMessage);
        }

        public void VerifyErrorPhoneNoMustBeSevenChars(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterPhoneNumber7CharactersLong, expectedErrorMessage);
        }

        public void VerifyErrorContactNameCharactersOnly(String expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterCharactersInContactError, expectedErrorMessage);
        }

        public void VerifyEmployerDetails(string employerName)
        {
            String actualContactName = FormCompletionHelper.GetValueFromField(ContactField);
            String actualEmail = FormCompletionHelper.GetValueFromField(EmailField);
            String actualPhoneNumber = FormCompletionHelper.GetValueFromField(PhoneNumberField);

            List<Object[]> employerInfo = GetEmployerDetails(employerName);

            foreach (object[] employerdetails in employerInfo)
            {
                String expectedContactName = employerdetails[1].ToString();
                String expectedPhoneNo = employerdetails[2].ToString();
                String expectedEmail = employerdetails[3].ToString();

                PageInteractionHelper.VerifyText(expectedContactName, actualContactName);
                PageInteractionHelper.VerifyText(expectedEmail, actualEmail);
                PageInteractionHelper.VerifyText(expectedPhoneNo, actualPhoneNumber);

               ScenarioContext.Current["_EmployerContactName"] = actualContactName;
            }
        }

        private List<object[]> GetEmployerDetails(String employerName)
        {
            String query = ("select companyname, PrimaryContact, phone, email from employer where CompanyName = '" + employerName + "'");
            var queryResult = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());
            return queryResult;
        }
    }
}
