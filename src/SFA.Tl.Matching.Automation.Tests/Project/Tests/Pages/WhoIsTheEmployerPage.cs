using System;
using System.Threading;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class WhoIsTheEmployerPage : BasePage
    {
        //Page Locators
        private String expectedPageURL = "https://test.industryplacementmatching.education.gov.uk/who-is-employer/";
        private static String PAGE_TITLE = "Who is the employer?";
        private By BusinessNameField = By.Name("CompanyName");
        private By ContinueButton = By.Id("tl-continue");

        //Error Message Locators
        //check this
        private By EnterEmployerError = By.XPath("//*[@id='main-content']/div/div/div/div/ul/li/a");
        private By ActualNullEmployerError = By.LinkText("You must find and choose an employer");
        
        //Actions
        public WhoIsTheEmployerPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        public WhoIsTheEmployerPage VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, expectedPageURL);
            return this;
        }

        private void EnterBusinessName(String empName)
        {
            FormCompletionHelper.EnterText(BusinessNameField, empName);
            Thread.Sleep(6000);            
        }

        private void ClickContinue()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
        }        

        //Behaviours
        public CheckEmployersDetailsPage EnterEmployerBusinessNameAndContinue(String employerName)
        {
            EnterBusinessName(employerName);
            ScenarioContext.Current["_provisionGapEmployerName"] = employerName;
            ClickContinue();
            return new CheckEmployersDetailsPage(webDriver);
        }

        public WhoIsTheEmployerPage EnterNoEmployerBusinessNameAndContinue()
        {
            ClickContinue();
            return new WhoIsTheEmployerPage(webDriver);
        }

        //Assertions
        public void VerifyNullEmployerError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualNullEmployerError, ExpectedErrorMessage);
        }
    }
}
