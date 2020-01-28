using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class SelectProvidersPage : BasePage
    {
        //Page Element Locators
        private static String PAGE_TITLE = "Select providers";
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

        //Error message Locators
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");
        private By ActualNoProviderSelectedError = By.LinkText("You must select at least one provider");
        private By ActualInvalidPostcodeError = By.LinkText("You must enter a real postcode");
        private By ActualNumberResultsDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[1]");
        private By ActualSkillsetDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[2]");
        private By ActualPostcodeDisplayed = By.XPath("//*[@id='main-content']/div[2]/div/h2/span[4]");        
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

        //Actions
        private void SelectSkillArea(String dropdownValue)
        {
            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, dropdownValue);
            // ScenarioContext.Current["_provisionGapTypeOfPlacement"] = dropdownValue;
        }        

        private void EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            ScenarioContext.Current["_provisionGapPostcode"] = postcode;
        }        

        private void ClearPostcode()
        {
            FormCompletionHelper.ClearText(PostcodeField);
        }

        /*private void SelectPostcodeRadius(String dropdownValue)
        {
            FormCompletionHelper.SelectFromDropDownByText(PostcodeRadius, dropdownValue);
            ScenarioContext.Current["_provisionGapPostcodeRadius"] = dropdownValue;
        }*/

        private void ClickSearchAgain()
        {
            FormCompletionHelper.ClickElement(SearchAgainButton);
        }

        private void SelectNoSuitableProviders()
        {
            FormCompletionHelper.ClickElement(ReportProvisionGapLink);
        }

        private void SelectProviders()
        {
            FormCompletionHelper.ClickElement(Provider1Checkbox);
            ProviderResultsHelper.SetProviderNames(providerName1);
        }

        private void ClickContinue()
        {
            FormCompletionHelper.ClickElement(ContinueButton);
        }

        //Behaviour
        public SelectProvidersPage EnterNewOpportunityDetailsAndSearchAgain(string skillArea, string postCode)
        {
            SelectSkillArea(skillArea);
            EnterPostcode(postCode);
            //SelectPostcodeRadius(radius);
            ClickSearchAgain();
            return new SelectProvidersPage(webDriver);
        }        

        public PlacementInformationPage SelectNoSuitableProviers()
        {
            SelectNoSuitableProviders();
            return new PlacementInformationPage(webDriver);
        }        

        public PlacementInformationPage SelectProvidersAndContinue()
        {
            SelectProviders();
            ClickContinue();
            return new PlacementInformationPage(webDriver);
        }

        public SelectProvidersPage EnterInvalidPostCodeAndSearchAgain()
        {
            EnterPostcode("B98");
            ClickSearchAgain();
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage ClearPostCodeAndSearchAgain()
        {
            ClearPostcode();
            ClickSearchAgain();
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage ContinueWithoutSelectingProviders()
        {
            ClickContinue();
            return new SelectProvidersPage(webDriver);
        }

        //Assertions
        public void VerifyPostcodeError (string ExpectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, ExpectedErrorMessage);
        }

        public void VerifyPostcodeDisplayed(String Postcode)
        {
            //String expectedPostcode = (string)ScenarioContext.Current["_provisionGapPostcode"];
            String expectedPostcode = Postcode;
            FormCompletionHelper.VerifyText(ActualPostcodeDisplayed, expectedPostcode);
        }

        public void VerifySkillsetDisplayed(String SkillArea)
        {
            //String expectedJobType = ((string)ScenarioContext.Current["_provisionGapTypeOfPlacement"]).ToLower();
            String expectedJobType = SkillArea.ToLower();
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
        
        public void VerifysHeadingShowsResults()
        {
            String ExpectedResultsHeading = "results in";
            String ActualResultHeading = webDriver.FindElement(ActualResultHeadingDisplayed).Text;
            PageInteractionHelper.VerifyText(ActualResultHeading, ExpectedResultsHeading);
        }

        public void VerifysHeadingShowsResult()
        {
            String ExpectedResultsHeading = "result in";
            String ActualResultHeading = webDriver.FindElement(ActualResultHeadingDisplayed).Text;
            PageInteractionHelper.VerifyText(ActualResultHeading, ExpectedResultsHeading);
        }

        /*public void VerifySearchRadius(String SearchRadius)
        {
            //String expSearchRadius = (String)ScenarioContext.Current["_provisionGapPostcodeRadius"];
            String expSearchRadius = SearchRadius;
            PageInteractionHelper.VerifyText(ActualSearchRadiusDisplayed, expSearchRadius);
        }    */            

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
