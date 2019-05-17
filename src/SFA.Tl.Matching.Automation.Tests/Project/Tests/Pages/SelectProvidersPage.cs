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
        private String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/provider-results";
        private By Provider1Checkbox = By.Name("SelectedProvider[0].IsSelected");
        private By Provider2Checkbox = By.Name("SelectedProvider[1].IsSelected");
        private By providerName1 = By.XPath("//*[@id='main-content']//li[1]/div/div/label");
        private By providerName2 = By.XPath("//*[@id='main-content']//li[2]/div/div/label");
        private By ContinueButton = By.Id("tl-continue");
        private By SearchAgainButton = By.Name("resultsAction");
        private By SkillAreaDropdown = By.Name("SelectedRouteId");
        private By PostcodeField = By.Name("Postcode");
        private By PostcodeRadius = By.Id("SearchRadius");
        private By ReportProvisionGapLink = By.LinkText("No suitable providers? Let us know");
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");
        private By ActualNoProviderSelectedError = By.LinkText("You must select at least one provider");
        private By ActualInvalidPostcodeError = By.LinkText("You must enter a real postcode");
        private By ActualNumberResultsDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[1]");
        private By ActualSkillsetDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[2]");
        private By ActualPostcodeDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[4]");
        private By ActualSearchRadiusDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[3]");
        private By ActualResultsCount = By.Id("tl-search-count");
        


        public SelectProvidersPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);         
        }    
        
        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, ExpectedPageURL);
        }

        public PlacementInformationPage ClickReportProvisionGapLink()
        {
            FormCompletionHelper.ClickElement(ReportProvisionGapLink);
            return new PlacementInformationPage(webDriver);
        }

        public SelectProvidersPage ClickSearchAgain()
        {
            FormCompletionHelper.ClickElement(SearchAgainButton);
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage SelectSkillArea(String dropdownValue)
        {
            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, dropdownValue);
            ScenarioContext.Current["_provisionGapTypeOfPlacement"] = dropdownValue;
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage SelectSearchAgain()
        {
            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, Constants.skillArea);
            FormCompletionHelper.EnterText(PostcodeField, Constants.postCode);
            FormCompletionHelper.SelectFromDropDownByText(PostcodeRadius, Constants.radius);
            FormCompletionHelper.ClickElement(SearchAgainButton);

            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage SelectPostcodeRadius(String dropdownValue)
        {
            FormCompletionHelper.SelectFromDropDownByText(PostcodeRadius, dropdownValue);
            ScenarioContext.Current["_provisionGapPostcodeRadius"] = dropdownValue;
            return new SelectProvidersPage(webDriver);
        }

        public void ClearPostcode()
        {
            FormCompletionHelper.ClearText(PostcodeField);
        }

        public SelectProvidersPage EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            ScenarioContext.Current["_provisionGapPostcode"] = postcode;
            return new SelectProvidersPage(webDriver);
        }

        public void VerifyPostcodeError (string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, ExpectedErrorMessage);
        }

        public void VerifyPostcodeDisplayed()
        {
            String expectedPostcode = (string)ScenarioContext.Current["_provisionGapPostcode"];
            FormCompletionHelper.VerifyText(ActualPostcodeDisplayed, expectedPostcode);
        }

        public void VerifySkillsetDisplayed()
        {
            String expectedJobType = ((string)ScenarioContext.Current["_provisionGapTypeOfPlacement"]).ToLower();
            Console.WriteLine(expectedJobType);
            FormCompletionHelper.VerifyText(ActualSkillsetDisplayed, expectedJobType);
        }

        public void VerifyResultsCount()
        {
             int expResultsCount = (Int32)ScenarioContext.Current["SearchResultsCount"];
             PageInteractionHelper.VerifyText(ActualResultsCount, expResultsCount);
        }

        public void VerifyZeroResultsCount()
        {
            int expResultsCount = 0;
            PageInteractionHelper.VerifyText(ActualNumberResultsDisplayed, expResultsCount);
        }

        public void VerifySearchRadius()
        {
            String expSearchRadius = (String)ScenarioContext.Current["_provisionGapPostcodeRadius"];
            PageInteractionHelper.VerifyText(ActualSearchRadiusDisplayed, expSearchRadius);
        }

        public PlacementInformationPage ClickContinue()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
            return new PlacementInformationPage(webDriver);
        }

        public void SelectProviders()
        {
            SelectPostcodeRadius(Constants.radius);
            ClickSearchAgain();
            FormCompletionHelper.ClickElement(Provider1Checkbox);
            FormCompletionHelper.ClickElement(Provider2Checkbox);
            PageInteractionHelper.SetProviderNames(providerName1, providerName2);
        }

        public void VerifyProviderNotSelectedError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualNoProviderSelectedError, ExpectedErrorMessage);
        }

        public void VerifyInvalidPostcodeError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualInvalidPostcodeError, ExpectedErrorMessage);
        }
    }
}
