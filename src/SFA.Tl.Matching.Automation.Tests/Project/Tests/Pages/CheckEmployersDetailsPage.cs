﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class CheckEmployersDetailsPage : BasePage
    {
        private static String PAGE_TITLE = "Check employer’s details";
        
        private By ConfirmAndContinueButton = By.ClassName("govuk-button");
        private By ContactField = By.Name("EmployerContact");
        private By PhoneNumberField = By.Id("EmployerContactPhone");
        private By EmailField = By.Id("EmployerContactEmail");
        private By EnterContactNameError = By.LinkText("You must enter a contact name for placements");
        private By EnterEmailError = By.LinkText("You must enter a contact email for placements");
        private By EnterPhoneNumberError = By.LinkText("You must enter a contact telephone number for placements");
        private By EnterLongerContactError = By.LinkText("You must enter a contact name using 2 or more characters");
        private By EnterShorterContactError = By.LinkText("You must enter a contact name using 99 characters or less");
        private By EnterCharactersInContactError = By.LinkText("You must enter a contact name using only letters, hyphens and apostrophes");
        private By EnterANumber = By.LinkText("You must enter a number");
        private By EnterPhoneNumber7CharactersLong = By.LinkText("You must enter a telephone number that has 7 or more numbers");
        

        public CheckEmployersDetailsPage(IWebDriver webDriver) : base(webDriver)
        {
           // SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }
                     
        public CheckAnswersPage ClickConfirmAndContinueButton()
        {
           FormCompletionHelper.ClickElement(ConfirmAndContinueButton);
            return new CheckAnswersPage(webDriver);
        }

        public void ClearFields()
        {
            FormCompletionHelper.ClearText(ContactField);
            FormCompletionHelper.ClearText(PhoneNumberField);
            FormCompletionHelper.ClearText(EmailField);
        }

        public void EnterContactName(String name)
        {
            FormCompletionHelper.EnterText(ContactField, name);
        }

        public void EnterPhoneNumber(String name)
        {
            FormCompletionHelper.EnterText(PhoneNumberField, name);
        }

        public void VerifyNoContactNameEnteredError(String expectedErrorMessage)
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

        public CheckEmployersDetailsPage VerifyEmployerDetails()
        {
            String employerName = Constants.employerName;
            String actualContactName = FormCompletionHelper.GetValueFromField(ContactField);
            Console.WriteLine("contact name"+actualContactName);
            String actualEmail = FormCompletionHelper.GetValueFromField(EmailField);
            Console.WriteLine("email name" + actualEmail);
            String actualPhoneNumber = FormCompletionHelper.GetValueFromField(PhoneNumberField);
            Console.WriteLine("phone no" + actualPhoneNumber);

            List<Object[]> employerInfo = GetEmployerDetails(employerName);

            foreach (object[] employerdetails in employerInfo)
            {

                String expectedContactName = employerdetails[1].ToString();
                String expectedPhoneNo = employerdetails[2].ToString();
                String expectedEmail = employerdetails[3].ToString();

                PageInteractionHelper.AssertText(expectedContactName, actualContactName);
                PageInteractionHelper.AssertText(expectedEmail, actualEmail);
                PageInteractionHelper.AssertText(expectedPhoneNo, actualPhoneNumber);

               ScenarioContext.Current["_EmployerContactName"] = actualContactName;
            }
            return new CheckEmployersDetailsPage(webDriver);
        }


        private List<object[]> GetEmployerDetails(String employerName)
        {
            String query = ("select companyname, PrimaryContact, phone, email from employer where CompanyName = '" + employerName + "'");

            var queryResult = SqlDatabaseConncetionHelper.ReadDataFromDataBase(query, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            return queryResult;
        }
    }
}