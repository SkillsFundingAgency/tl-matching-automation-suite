using System;
using NUnit.Framework;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories;
using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System.Threading;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerFileUploadSteps : BaseTest
    {
        [Given(@"I am logged in as Administrator")]
        public void GivenIAmLoggedInAsAdministrator()
        {
            //TODO: Add Logic to OpenWeb browser and Navigate to Login screen and Login
            //ScenarioContext.Current.Pending();
        }

        [Given(@"I Navigate to File Upload Page")]
        public void GivenINevigateToFileUploadPage()
        {
            StartPage StartPage = new StartPage(webDriver);
            StartPage.ClickUploadLink();

        }

        [Given(@"I have cleared down the Employer table first")]
        public void GivenIHaveClearedDownTheEmployerTableFirst()
        {
            String DeleteEmployerQuery = "Delete FROM Employer";
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteEmployerQuery, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            //Confirm theProvider table is cleared down:
            String EmployerRecordCount = "Select Count(*) FROM Employer";
            var result = SqlDatabaseConncetionHelper.ReadDataFromDataBase(EmployerRecordCount, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            Assert.AreEqual(result[0][0], 0);
        }


        [Given(@"I Upload Employer File")]
        public void GivenIUploadEmployerFile()
        {
            FileUploadPage FileUploadPage = new FileUploadPage(webDriver);
            FileUploadPage.SelectEmployerFile();
            FileUploadPage.SelectEmployerFromDropdown();
            Thread.Sleep(3000);
                     
        }

        
        [When(@"I press Submit")]
        public void WhenIPressSubmit()
        {
            FileUploadPage FileUploadPage = new FileUploadPage(webDriver);
            FileUploadPage.ClickUploadLink();
            Thread.Sleep(1000);
        }
        

        [Then(@"the screen should display File Successfully Uploaded Message")]
        public void ThenTheScreenShouldDisplayFileSuccessfullyUploadedMessage()
        {
            FileUploadPage FileUploadPage = new FileUploadPage(webDriver);
            FileUploadPage.VerifyUploadSuccessMessage();

        }
        
        [Then(@"the Database should have a new employer named 1066 Enterprise")]
        public void ThenTheDatabaseShouldHaveANewEmployerNamed1066Enterprise()
        {
            Thread.Sleep(10000);
            var employerRepository = new EmployerRepository(new MatchingDbContext());
            var employer = employerRepository.GetByName("1066 Enterprise");

            Console.Write(employer.Email);
           // Thread.Sleep(10000);
           //// Assert.IsNotNull(employer);
           //// Assert.AreEqual(employer.CrmId, "35460a4b-383c-4dad-9305-e43decf239bc1");
           Assert.AreEqual(employer.AlsoKnownAs, "1066 Enterprise");
          //  Assert.AreEqual(employer.Email, "stephen.king@ldbgroup.co.uk");
            //Assert.AreEqual(employer.Owner, "Small Business Team CRM User");
            //Assert.AreEqual(employer.Phone, "01424205500");
            //Assert.AreEqual(employer.PostCode, "TN34 1UT");
            //Assert.AreEqual(employer.PrimaryContact, "IP Stephen King");
            //Assert.AreEqual(employer.Email, "stephen.king@ldbgroup.co.uk");
        }
    }
}
