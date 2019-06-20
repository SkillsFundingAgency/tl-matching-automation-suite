using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SFA.Tl.Matching.Automation.Tests.Project.Framework.Helpers;
using SFA.Tl.Matching.Automation.Tests.Project.Tests.TestSupport;

namespace SFA.Tl.Matching.Automation.Tests.Project.Tests.Pages
{
    public class FindLocalProvidersPage : BasePage
    {
        private static String PAGE_TITLE = "Find local providers";
        private By SearchButton = By.ClassName("govuk-button");
        private By SkillAreaDropdown = By.Id("SelectedRouteId");
        private By PostcodeField = By.Id("Postcode");
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");
        private String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/find-providers";

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

        public SelectProvidersPage ClickSearchButton()
        {
           FormCompletionHelper.ClickElement(SearchButton);
            return new SelectProvidersPage(webDriver);
        }

        public FindLocalProvidersPage SelectFromDropdown(String dropdownValue)
        {
           FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, dropdownValue);
            return this;
        }

        public FindLocalProvidersPage EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
            return new FindLocalProvidersPage(webDriver);
        }

        public FindLocalProvidersPage ClearPostcode()
        {
            FormCompletionHelper.ClearText(PostcodeField);
            return this;
        }

        public FindLocalProvidersPage VerifyPostcodeError (string expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, expectedErrorMessage);
            return this;
        }

        public FindLocalProvidersPage AutoPopulateFields()
        {
            FormCompletionHelper.EnterText(PostcodeField, "B43 6JN");
            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, "Care services");
            return this;
        }
    }
}
