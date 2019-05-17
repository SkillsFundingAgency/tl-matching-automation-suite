using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class WhoIsTheEmployerPage : BasePage
    {
        private static String PAGE_TITLE = "Who is the employer?";
        private By BusinessNameField = By.Name("CompanyName");
        private By ContinueButton = By.Id("tl-continue");
        private By EnterEmployerError = By.XPath("//*[@id='main-content']/div/div/div/div/ul/li/a");
        private String _expectedEnterEmployerError = "You must find and choose an employer";
        private String expectedPageURL = "https://test.industryplacementmatching.education.gov.uk/who-is-employer/";

        public WhoIsTheEmployerPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }
        
        public CheckEmployersDetailsPage ClickContinue()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
            return new CheckEmployersDetailsPage(webDriver);
        }

        public void ClearBusinessField()
        {
            FormCompletionHelper.ClearText(BusinessNameField);
        }

        public void VerifyNullEmployerError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(EnterEmployerError, _expectedEnterEmployerError);
        }

        public void AutoPopulateEmployer()
        {
            FormCompletionHelper.EnterText(BusinessNameField, "Abacus Childrens Nurseries");
            Thread.Sleep(2000);
            FormCompletionHelper.PressTabKey();           
        }

        public WhoIsTheEmployerPage EnterEmployer(String employerName)
        {
            FormCompletionHelper.EnterText(BusinessNameField, employerName);
            Thread.Sleep(2000);
            //FormCompletionHelper.PressTabKey(BusinessNameField);
            ScenarioContext.Current["_provisionGapEmployerName"] = employerName;
            return this;
        }

        public WhoIsTheEmployerPage clickContinue()
        { 
       
            FormCompletionHelper.EnterText(BusinessNameField, Constants.employerName);
            Thread.Sleep(6000);
            //FormCompletionHelper.PressTabKey();
            FormCompletionHelper.ClickElement(ContinueButton);

            return this;
        }

        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, expectedPageURL);
        }
    }
}
