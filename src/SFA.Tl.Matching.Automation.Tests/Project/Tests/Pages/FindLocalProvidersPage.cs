using System;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class FindLocalProvidersPage : BasePage
    {
        //Page Locators
        private String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/find-providers";
        private static String PAGE_TITLE = "Set up placement opportunity";        
        private By SkillAreaDropdown = By.Id("SelectedRouteId");
        private By PostcodeField = By.Id("Postcode");
        private By SearchButton = By.ClassName("govuk-button");

        //ErrorMessages
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");
        
        public FindLocalProvidersPage(IWebDriver webDriver) : base(webDriver)
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

        private void SelectSkillFromDropdown(String dropdownValue)
        {
            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, dropdownValue);
        }

        private void EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            ScenarioContext.Current["_SearchPostcode"] = postcode;
        }

        private void ClickSearchButton()
        {
            FormCompletionHelper.ClickElement(SearchButton);
        }                

        //Behaviours
        public SelectProvidersPage EnterOpportunityDetailsAndSearchForProviders(String skill, String postCode)
        {
            SelectSkillFromDropdown(skill);
            EnterPostcode(postCode);            
            ClickSearchButton();
            return new SelectProvidersPage(webDriver);
        }

        public SelectProvidersPage EnterOpportunityDetailsAndSearchForProvidersSecondPass(String skill, String postCode)
        {
            SelectSkillFromDropdown(skill);
            EnterPostcode(postCode);
            ClickSearchButton();
            return new SelectProvidersPage(webDriver);
        }

        public FindLocalProvidersPage ClearPostcodeAndSearch()
        {
            FormCompletionHelper.ClearText(PostcodeField);
            ClickSearchButton();
            return this;
        }

        //Assertions
        public void VerifyPostcodeError(string expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, expectedErrorMessage);
        }        
    }
}
