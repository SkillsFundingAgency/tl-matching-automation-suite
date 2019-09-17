using System;
using NUnit.Framework;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Repositories;
using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using System.Threading;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerFileUploadSteps : BaseTest
    {
        [Given(@"I Navigate to File Upload Page")]
        public void GivenINevigateToFileUploadPage()
        {
            StartPage startPage = new StartPage(webDriver);
            startPage.StartUploadingEmployerOrProviderData();
        }

        [Given(@"I have cleared down the Employer table first")]
        public void GivenIHaveClearedDownTheEmployerTableFirst()
        {
            String DeleteEmployerQuery = "Delete FROM Employer";
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteEmployerQuery, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());

            //Confirm theProvider table is cleared down:
            String EmployerRecordCount = "Select Count(*) FROM Employer";
            var result = SqlDatabaseConncetionHelper.ReadDataFromDataBase(EmployerRecordCount, Configurator.GetConfiguratorInstance().GetMatchingServiceConnectionString());
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
            Thread.Sleep(10000);
            Assert.AreEqual(employer.AlsoKnownAs, "1066 Enterprise");
        }
    }
}
