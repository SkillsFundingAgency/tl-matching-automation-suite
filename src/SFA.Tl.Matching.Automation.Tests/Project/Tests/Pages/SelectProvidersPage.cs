using System;
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
    public class SelectProvidersPage : BasePage
    {
        private static String PAGE_TITLE = "Select providers";

        public SelectProvidersPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }



        private By SearchAgainButton = By.Name("resultsAction");
        private By SkillAreaDropdown = By.Name("SelectedRouteId");
        private By PostcodeField = By.Name("Postcode");
        private By PostcodeRadius = By.Id("SearchRadius");
        private By ReportProvisionGapLink = By.LinkText("tell us that there are no suitable providers");
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");
        private By ActualNumberResultsDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[1]");
        private By ActualSkillsetDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[2]");
        private By ActualPostcodeDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[4]");
        private By ActualRadiusDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[3]");
        private String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/provider-results";

         //String ExpectedPostcode = ScenarioContext.Current.Get<String>("Postcode");
         //String ExpectedSkillset = ScenarioContext.Current.Get<String>("SkillArea");
         String ExpectedPostcode = "B20 3HQ";
         String ExpectedSkillset = "Care services";


        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, ExpectedPageURL);
        }


        public void ClickReportProvisionGapLink()
        {
           FormCompletionHelper.ClickElement(ReportProvisionGapLink);
        }

        public void ClickSearchAgain()
        {
            FormCompletionHelper.ClickElement(SearchAgainButton);
        }

        public void SelectSkillset(String dropdownValue)
        {

            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, dropdownValue);
            ScenarioContext.Current["_provisionGapTypeOfPlacement"] = dropdownValue;

        }


        public void SelectPostcodeRadius(String dropdownValue)
        {

            FormCompletionHelper.SelectFromDropDownByText(PostcodeRadius, dropdownValue);
            ScenarioContext.Current["_provisionGapPostcodeRadius"] = dropdownValue;
        }

        public void ClearPostcode()
        {
            FormCompletionHelper.ClearText(PostcodeField);
        }

        public void EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            ScenarioContext.Current["_provisionGapPostcode"] = postcode;
        }

        public void VerifyPostcodeError (string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, ExpectedErrorMessage);
        }

        public void VerifyPostcodeDisplayed()
        {
            FormCompletionHelper.VerifyText(ActualPostcodeDisplayed, ExpectedPostcode);
        }

        public void VerifySkillsetDisplayed()
        {
            FormCompletionHelper.VerifyText(ActualSkillsetDisplayed, ExpectedSkillset);
        }

    }
}
