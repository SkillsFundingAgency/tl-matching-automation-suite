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

        public FindLocalProvidersPage(IWebDriver webDriver) : base(webDriver)
        {
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return PageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }



        private By SearchButton = By.ClassName("govuk-button");
        private By SkillAreaDropdown = By.Id("SelectedRouteId");
        private By PostcodeField = By.Id("Postcode");
        private By ActualPostcodeError = By.LinkText("You must enter a postcode");
        private String ExpectedPageURL = "https://test.industryplacementmatching.education.gov.uk/find-providers";
      

        public void VerifyPageURL()
        {
            PageInteractionHelper.VerifyPageURL(webDriver.Url, ExpectedPageURL);
        }


        public void ClickSearchButton()
        {
           FormCompletionHelper.ClickElement(SearchButton);
        }

        public void SelectFromDropdown(String dropdownValue)
        {
           FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, dropdownValue);
        }

               
        public void EnterPostcode(string postcode)
        {
            FormCompletionHelper.EnterText(PostcodeField, postcode);
        }

        public void ClearPostcode()
        {
            FormCompletionHelper.ClearText(PostcodeField);
        }

        public void VerifyPostcodeError (string expectedErrorMessage)
        {
            FormCompletionHelper.VerifyText(ActualPostcodeError, expectedErrorMessage);
        }

        public void AutoPopulateFields()
        {
            FormCompletionHelper.EnterText(PostcodeField, "B20 3HQ");
            FormCompletionHelper.SelectFromDropDownByText(SkillAreaDropdown, "Care services");
        }
    }
}
