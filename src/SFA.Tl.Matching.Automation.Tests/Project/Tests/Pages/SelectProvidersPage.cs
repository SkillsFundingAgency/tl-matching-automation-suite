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
        private By ActualResultHeadingDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2");


        public SelectProvidersPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);         
        }    
        
        public SelectProvidersPage VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, ExpectedPageURL);
            return this;
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
           // ScenarioContext.Current["_provisionGapTypeOfPlacement"] = dropdownValue;
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

        public SelectProvidersPage ClearPostcode()
        {
            FormCompletionHelper.ClearText(PostcodeField);
            return this;
        }

        public SelectProvidersPage EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            ScenarioContext.Current["_provisionGapPostcode"] = postcode;
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifyPostcodeError (string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, ExpectedErrorMessage);
            return this;
        }

        public SelectProvidersPage VerifyPostcodeDisplayed(String Postcode)
        {
            //String expectedPostcode = (string)ScenarioContext.Current["_provisionGapPostcode"];
            String expectedPostcode = Postcode;
            FormCompletionHelper.VerifyText(ActualPostcodeDisplayed, expectedPostcode);
            return new SelectProvidersPage(webDriver);
        }


        public SelectProvidersPage VerifySkillsetDisplayed(String SkillArea)
        {
            //String expectedJobType = ((string)ScenarioContext.Current["_provisionGapTypeOfPlacement"]).ToLower();
            String expectedJobType = SkillArea.ToLower();
            Console.WriteLine(expectedJobType);
            FormCompletionHelper.VerifyText(ActualSkillsetDisplayed, expectedJobType);
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifyResultsCount()
        {
             int expResultsCount = (Int32)ScenarioContext.Current["SearchResultsCount"];
             PageInteractionHelper.VerifyText(ActualResultsCount, expResultsCount);
             return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifyZeroResultsCount()
        {
            int expResultsCount = 0;
            PageInteractionHelper.VerifyText(ActualNumberResultsDisplayed, expResultsCount);
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifysHeadingShowsResults()
        {
            String ExpectedResultsHeading = "results in";
            PageInteractionHelper.VerifyText(ActualResultHeadingDisplayed, ExpectedResultsHeading);
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifysHeadingShowsResult()
        {
            String ExpectedResultsHeading = "result in";
            PageInteractionHelper.VerifyText(ActualResultHeadingDisplayed, ExpectedResultsHeading);
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifySearchRadius(String SearchRadius)
        {
            //String expSearchRadius = (String)ScenarioContext.Current["_provisionGapPostcodeRadius"];
            String expSearchRadius = SearchRadius;
            PageInteractionHelper.VerifyText(ActualSearchRadiusDisplayed, expSearchRadius);
            return new SelectProvidersPage(webDriver);
        }

        public PlacementInformationPage ClickContinue()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
            return new PlacementInformationPage(webDriver);
        }

        public SelectProvidersPage SelectProviders()
        {
            SelectPostcodeRadius(Constants.radius);
            ClickSearchAgain();
            FormCompletionHelper.ClickElement(Provider1Checkbox);
            ProviderResultsHelper.SetProviderNames(providerName1, providerName2);
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage VerifyProviderNotSelectedError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualNoProviderSelectedError, ExpectedErrorMessage);
            return this;
        }

        public SelectProvidersPage VerifyInvalidPostcodeError(string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualInvalidPostcodeError, ExpectedErrorMessage);
            return this;
        }
    }
}
