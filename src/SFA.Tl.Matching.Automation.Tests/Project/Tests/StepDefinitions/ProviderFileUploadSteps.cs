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
               
        [Given(@"I upload a Provider File")]
        public void GivenIuploadAProviderFile()
        {
            FileUploadPage FileUploadPage = new FileUploadPage(webDriver);
            FileUploadPage.SelectProviderFile();
            FileUploadPage.SelectProviderFromDropdown();
        }
        
        [Given(@"I have cleared down the Provider table first")]
        public void GivenIHaveClearedDownTheProviderTableFirst()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.ClearProviderTable();
        }

        [Then(@"the database should have a new Provider")]
        public void ThenTheDatabaseShouldHaveANewProvider()
        {
            FileUploadPage fileUploadPage = new FileUploadPage(webDriver);
            fileUploadPage.VerifyNewProviderCreated();
        }
    }
}
