using System;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.StepDefinitions

{
    [Binding]
    public class ProviderFileUploadSteps : BaseTest
    {
        FileUploadPage FileUploadPage = new FileUploadPage(webDriver);


        [Given(@"I upload a Provider File")]
        public void GivenIuploadAProviderFile()
        {
            FileUploadPage.SelectProviderFile();
            FileUploadPage.SelectProviderFromDropdown();

        }
        
        [Given(@"I have cleared down the Provider table first")]
        public void GivenIHaveClearedDownTheProviderTableFirst()
        {
            String DeleteProviderQuery = "Delete FROM Provider";
            SqlDatabaseConncetionHelper.ExecuteDeleteSqlCommand(DeleteProviderQuery, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());

            //Confirm theProvider table is cleared down:
            String ProviderRecordCount = "Select Count(*) FROM Provider";
            var result = SqlDatabaseConncetionHelper.ReadDataFromDataBase(ProviderRecordCount, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            Assert.AreEqual(result[0][0], 0);
        }

        [Then(@"the database should have a new Provider")]
        public void ThenTheDatabaseShouldHaveANewProvider()
        {
            Thread.Sleep(10000);
            String ProviderRecordCount = "Select Count(*) FROM Provider";
            var result = SqlDatabaseConncetionHelper.ReadDataFromDataBase(ProviderRecordCount, Configurator.GetConfiguratorInstance().GetMathcingServiceConnectionString());
            Assert.AreEqual(341, result[0][0]);
        }
    }
}
